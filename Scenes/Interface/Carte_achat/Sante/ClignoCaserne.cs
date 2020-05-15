using Godot;
using System;

public class ClignoCaserne : Panel
{
    public static TextureRect _cligno;
    
    public static bool cligno = true;
    
    public static bool Cligno
    {
        get => cligno;
        set => cligno = value;
    }
    
    public override void _Ready()
    {
        _cligno = (TextureRect) GetNode("Cligno");
        _cligno.Hide();
    }
}
