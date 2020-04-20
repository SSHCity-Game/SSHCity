using Godot;
using System;

public class DeleteVerif : Panel
{
    private Button _buttonOui;
    private Button _buttonNon;
    private bool _verif = false;

    private const string _str_buttonOui = "Titre/ButtonOui";
    private const string _str_buttonNon = "Titre/ButtonNon";
    
    public override void _Ready()
    {
        _buttonOui = (Button) GetNode(_str_buttonOui);
        _buttonNon = (Button) GetNode(_str_buttonNon);
        _buttonOui.Connect("pressed", this, nameof(ButtonOuiPressed));
        _buttonNon.Connect("pressed", this, nameof(ButtonNonPressed));
        AddUserSignal("DeleteVerifOui");
        AddUserSignal("DeleteVerfiNon");
        this.Hide();
    }

    public void ButtonOuiPressed()
    {
        EmitSignal("DeleteVerifOui");
        Hide();
    }

    public void ButtonNonPressed()
    {
        EmitSignal("DeleteVerifNon");
        Hide();
    }

    public override void _Process(float delta)
    {
        base._Process(delta);
        if (_verif)
        {
            
        }
    }
}
