using Godot;
using System;

public class MenuSpeciaux : Node
{
    private Menu_Achat _menu_achat;

    private const string _str_menu_achat = "Menu_Achat";


    public override void _Ready()
    {
        _menu_achat = (Menu_Achat) GetNode(_str_menu_achat);
        _menu_achat.Hide();
    }

    public void CloseMenuSpeciaux()
    {
        _menu_achat.Hide();
    }

    public void OpenMenuSpeciaux()
    {
        _menu_achat.Show();
    }
    
}