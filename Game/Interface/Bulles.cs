using Godot;
using System;
using System.Collections.Generic;
using SshCity.Game.Buildings;

public class Bulles : Node2D
{
    private AnimatedSprite _bulleImage;

    private const string _strBulleImage = "Incident";

    public void Init(TypeIncident typeIncident, Vector2 position)
    {
        Position = position;
        _bulleImage = (AnimatedSprite) GetNode(_strBulleImage);
        _bulleImage.Animation = TypeIncidentToAnim[typeIncident];
    }
    
    public override void _Ready()
    {
        //_bulleImage = (AnimatedSprite) GetNode(_strBulleImage);
        //this.Hide();
    }

    public enum TypeIncident
    {
        ROUTE,
    }
    
    public static Dictionary<TypeIncident, string> TypeIncidentToAnim = new Dictionary<TypeIncident, string>()
    {
        {TypeIncident.ROUTE, "Route"}
    };
}
