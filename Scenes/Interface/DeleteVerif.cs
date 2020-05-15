using Godot;

public class DeleteVerif : Panel
{
    private const string _str_buttonOui = "Titre/ButtonOui";
    private const string _str_buttonNon = "Titre/ButtonNon";
    private const string _str_suppr = "supprimer";
    private static bool _verif = false;
    private Button _buttonNon;
    private Button _buttonOui;
    private AudioStreamPlayer _supression;

    public static bool Verif
    {
        get => _verif;
        set => _verif = value;
    }

    public override void _Ready()
    {
        _buttonOui = (Button) GetNode(_str_buttonOui);
        _buttonNon = (Button) GetNode(_str_buttonNon);
        _supression = (AudioStreamPlayer) GetNode(_str_suppr);
        _buttonOui.Connect("pressed", this, nameof(ButtonOuiPressed));
        _buttonNon.Connect("pressed", this, nameof(ButtonNonPressed));
        this.Hide();
    }

    public void ButtonOuiPressed()
    {
        PlanInitial.DeleteSure = true;
        _verif = false;
        this.Hide();
        _supression.Play();
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