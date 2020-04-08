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
    private int position_zoom = 3;
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
                    if ((_camera2D.Position.x + _distanceDragged.x < Ref_donnees.x_left[position_zoom]) || (_camera2D.Position.x + _distanceDragged.x > Ref_donnees.x_right[position_zoom]))
                    {
                        _distanceDragged.x = 0;
                    }
                    if (_camera2D.Position.y + _distanceDragged.y < Ref_donnees.y_top[position_zoom]|| _camera2D.Position.y + _distanceDragged.y > Ref_donnees.y_bot[position_zoom])
                    {
                        _distanceDragged.y = 0;
                    }

                    _camera2D.Position += _distanceDragged;
                    _DraggingStart = inputEventMouse.Position;
                    if ((_camera2D.Position.x < Ref_donnees.x_left[position_zoom]))
                    {
                        _camera2D.Position = new Vector2(Ref_donnees.x_left[position_zoom], _camera2D.Position.y);
                    }

                    if (_distanceDragged.x > Ref_donnees.x_right[position_zoom])
                    {
                        _camera2D.Position = new Vector2(Ref_donnees.x_right[position_zoom], _camera2D.Position.y);

                    }
                    if (_camera2D.Position.y < Ref_donnees.y_top[position_zoom])
                    {
                        _camera2D.Position = new Vector2(_camera2D.Position.y, Ref_donnees.y_top[position_zoom]);
                    }
                    if (_camera2D.Position.y > Ref_donnees.y_bot[position_zoom])
                    {
                        _camera2D.Position = new Vector2(_camera2D.Position.y, Ref_donnees.y_bot[position_zoom]);
                    }
                }
                break;
            }
        }

        if (Input.IsActionPressed("Zoom+"))
        {
            float x_zoom = (float)(_camera2D.Zoom.x - Ref_donnees.zoom_coef);
            float y_zoom = (float)(_camera2D.Zoom.y - Ref_donnees.zoom_coef);
            if (x_zoom < (Ref_donnees.zoom_in_max))
            {
                x_zoom = Ref_donnees.zoom_in_max;
            }
            if (y_zoom < Ref_donnees.zoom_in_max)
            {
                y_zoom = Ref_donnees.zoom_in_max;
            }
            _camera2D.Zoom = new Vector2(x_zoom, y_zoom);
            if (position_zoom > 0)
            {
                position_zoom -= 1;
            }
        }
        if (Input.IsActionPressed("Zoom-"))
        {
            float x_zoom = (float)(_camera2D.Zoom.x + Ref_donnees.zoom_coef);
            float y_zoom = (float)(_camera2D.Zoom.y + Ref_donnees.zoom_coef);
            if (x_zoom > Ref_donnees.zoom_out_max)
            {
                x_zoom = (Ref_donnees.zoom_out_max);
            }
            if (y_zoom > Ref_donnees.zoom_out_max)
            {
                y_zoom = Ref_donnees.zoom_out_max;
            }
            _camera2D.Zoom = new Vector2(x_zoom, y_zoom);
            if (position_zoom<8)
            {
                position_zoom += 1;
            }
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
