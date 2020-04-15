using Godot;
using System;

public class MenuSante : Node
{

    private Menu_Achat _menu_achat;

    private const string _str_menu_achat = "Menu_Achat";
    
    public override void _Ready()
    {
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _menu_achat.Hide();
    }
    
    public void CloseMenuSante()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuSante()
    {
        _menu_achat.Show();
    }
}
