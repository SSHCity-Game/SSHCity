using Godot;
using System;
using System.Collections.Generic;
using SshCity.Scenes.Plan;

public class MainPlan : Node2D
{
    private PlanInitial _planInitial;
    private string str_planInitial = "PlanInitial";
    
    public override void _Ready()
    {
        _planInitial = (PlanInitial) GetNode(str_planInitial);
        
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
