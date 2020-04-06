using Godot;
using System;
using System.Collections.Generic;
using SshCity.Scenes.Plan;

public class MainPlan : Node2D
{
    private PlanInitial _planInitial;
    private Camera2D _camera2D;
    private string str_planInitial = "PlanInitial";
    private string str_camera2D = "Camera2D";

    private bool _mousePressed;
    private Vector2 _DraggingStart;
    private Vector2 _distanceDragged;
    public override void _Input(InputEvent OneEvent)
    {
        base._Input(OneEvent);
        switch (OneEvent)
        {
            case InputEventMouseButton eventMouseButton:
            {
                _mousePressed = eventMouseButton.Pressed;
                if (_mousePressed && ! eventMouseButton.IsEcho())
                {
                    _DraggingStart = GetViewport().GetMousePosition();
                }
                break;
            }

            case InputEventMouse inputEventMouse:
            {
                
                if (_mousePressed)
                {
                    _distanceDragged = _DraggingStart - inputEventMouse.Position;
                    if ((_camera2D.Position.x + _distanceDragged.x < 510) || (_camera2D.Position.x + _distanceDragged.x > 2064))
                    {
                        _distanceDragged.x = 0;
                    }
                    if (_camera2D.Position.y + _distanceDragged.y < 300 || _camera2D.Position.y + _distanceDragged.y > 1348)
                    {
                        _distanceDragged.y = 0;
                    }

                    _camera2D.Position += _distanceDragged;
                    _DraggingStart = inputEventMouse.Position;
                }
                break;
            }
        }

        if (Input.IsActionPressed("Zoom+"))
        {
            _camera2D.Zoom = _camera2D.Zoom / 2;
        }
        if (Input.IsActionPressed("Zoom-"))
        {
            _camera2D.Zoom = _camera2D.Zoom * 2;
        }
    }
    
    public override void _Ready()
    {
        _planInitial = (PlanInitial) GetNode(str_planInitial);
        _camera2D = (Camera2D) GetNode(str_camera2D);

        Montagnes.GenerateMontagne(_planInitial);
        Montagnes.GenerateMontagne(_planInitial);
        while (!SshCity.Scenes.Plan.Buildings.GenerateBuildings(_planInitial))
        {
            _planInitial = new PlanInitial();
        }

        //CREATION LACS
        List<(int, int)> coordonnées = Lacs.GenerateLac(_planInitial);
        
        //CREATION SABLE
        Sable.GenerateSable(_planInitial, coordonnées);
        
    }
    
    
    
    //PERMET DE RECREER UNE MAP JUSTE EN CLIQUANT SUR ESPACE (POUR GAGNER DU TEMPS POUR TESTER, SERA SUPPRIME PAR LA SUITE)
    public override void _Process(float delta)
    {
        if (Input.IsKeyPressed((int)KeyList.Space))
        {
            GetTree().ReloadCurrentScene();
        }
    }

}
