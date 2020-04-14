using Godot;
using System;

public class Boutique : CanvasLayer
{
    private Panel _background;
    private Label _title;

    private const string _str_background = "Background";
    private const string _str_title = "Title";

    public override void _Ready()
    {
        _background = (Panel) GetNode(_str_background);
        _title = (Label) GetNode(_str_title);
    }

    public void OpenShop()
    {
        _background.Show();
        _title.Show();
    }

    public void CloseShop()
    {
        _background.Hide();
        _title.Hide();
    }
}
