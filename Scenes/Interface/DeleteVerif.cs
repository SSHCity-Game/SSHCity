using Godot;
using System;

public class DeleteVerif : Panel
{
    private Button _buttonOui;
    private Button _buttonNon;
    private static bool _verif = false;

    public static bool Verif
    {
        get => _verif;
        set => _verif = value;
    }

    private const string _str_buttonOui = "Titre/ButtonOui";
    private const string _str_buttonNon = "Titre/ButtonNon";
    
    public override void _Ready()
    {
        _buttonOui = (Button) GetNode(_str_buttonOui);
        _buttonNon = (Button) GetNode(_str_buttonNon);
        _buttonOui.Connect("pressed", this, nameof(ButtonOuiPressed));
        _buttonNon.Connect("pressed", this, nameof(ButtonNonPressed));
        this.Hide();
    }

    public void ButtonOuiPressed()
    {
        PlanInitial.DeleteSure = true;
        _verif = false;
        this.Hide();

    }

    public void ButtonNonPressed()
    {
        _verif = false;
        this.Hide();
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        if (_verif)
        {
            Show();
        }
    }
}
