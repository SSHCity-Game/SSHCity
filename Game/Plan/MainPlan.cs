using System.Collections.Generic;
using Godot;
using Godot.Collections;
using SshCity.Game;
using SshCity.Game.Plan;
using SshCity.Game.Sauvegarde;

public class MainPlan : Node2D
{
    private const string _str_music = "Musique";
    public static List<List<Vector2>> MontagneList = new List<List<Vector2>>();
    public static PlanInitial _planInitial;
    public static float zoom = (float) 1.25;
    public static Vector2 cameraPosition = new Vector2(1250, 810);
    private static List<(Vector2, int)> _listeBatiment = new List<(Vector2, int)>();
    private static List<(Vector2, int)> _listeNode = new List<(Vector2, int)>();
    public static bool incident = false;
    public static AudioStreamPlayer _musique;
    private static Vector2 _mairiePosition;

    public static Godot.Collections.Dictionary<Vector2, Vector2> BatimentsTiles =
        new Godot.Collections.Dictionary<Vector2, Vector2>();

    public Camera2D _camera2D;
    private Vector2 _distanceDragged;
    private Vector2 _DraggingStart;
    private MainMenu _mainMenu;
    private bool _mousePressed;
    private int position_zoom = 3;
    private string str_camera2D = "Camera2D";
    private string str_planInitial = "PlanInitial";

    public static Vector2 MairiePosition
    {
        get => _mairiePosition;
        set => _mairiePosition = value;
    }

    public static List<(Vector2, int)> ListeBatiment
    {
        get => _listeBatiment;
        set => _listeBatiment = value;
    }

    public override void _Input(InputEvent OneEvent)
    {
        base._Input(OneEvent);
        switch (OneEvent)
        {
            case InputEventMouseButton eventMouseButton:
            {
                if (eventMouseButton.IsActionPressed("ClickD"))
                {
                    _mousePressed = eventMouseButton.Pressed;
                    if (_mousePressed && !eventMouseButton.IsEcho())
                    {
                        _DraggingStart = GetViewport().GetMousePosition();
                    }
                }
                else
                {
                    _mousePressed = false;
                }

                break;
            }

            case InputEventMouse inputEventMouse:
            {
                if (_mousePressed)
                {
                    _distanceDragged = _DraggingStart - inputEventMouse.Position;
                    if ((_camera2D.Position.x + _distanceDragged.x < Ref_donnees.x_left[position_zoom]) ||
                        (_camera2D.Position.x + _distanceDragged.x > Ref_donnees.x_right[position_zoom]))
                    {
                        _distanceDragged.x = 0;
                    }

                    if (_camera2D.Position.y + _distanceDragged.y < Ref_donnees.y_top[position_zoom] ||
                        _camera2D.Position.y + _distanceDragged.y > Ref_donnees.y_bot[position_zoom])
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

                    cameraPosition = _camera2D.Position;
                }

                break;
            }
        }

        if (Input.IsActionPressed("Zoom+"))
        {
            float x_zoom = (float) (_camera2D.Zoom.x - Ref_donnees.zoom_coef);
            float y_zoom = (float) (_camera2D.Zoom.y - Ref_donnees.zoom_coef);
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
            float x_zoom = (float) (_camera2D.Zoom.x + Ref_donnees.zoom_coef);
            float y_zoom = (float) (_camera2D.Zoom.y + Ref_donnees.zoom_coef);
            if (x_zoom > Ref_donnees.zoom_out_max)
            {
                x_zoom = (Ref_donnees.zoom_out_max);
            }

            if (y_zoom > Ref_donnees.zoom_out_max)
            {
                y_zoom = Ref_donnees.zoom_out_max;
            }

            zoom = x_zoom;
            _camera2D.Zoom = new Vector2(x_zoom, y_zoom);
            if (position_zoom < 8)
            {
                position_zoom += 1;
            }
        }
    }

    public override void _Ready()
    {
        _planInitial = (PlanInitial) GetNode(str_planInitial);
        _mainMenu = (MainMenu) GetNode("MainMenu");
        _camera2D = (Camera2D) GetNode(str_camera2D);
        _musique = (AudioStreamPlayer) GetNode(_str_music);

        _planInitial.Hide();
        // Charge l'état du joueur (s'il est connecté ou non)
        var args = OS.GetCmdlineArgs();
        Player player;
        if (args.Length == 0)
        {
            // Utilisateur par défaut
            player = Player.CreateInstance();
            player.Email = "default@email.com";
            player.FirstName = "DefaultFirstName";
            player.LastName = "DefaultLastName";
            player.Token = null;
            player.Username = "DefaultUsername";
            player.GameId = "DefaultGameID";
        }
        else
        {
            var jsonUser = Marshalls.Base64ToUtf8(args[0]);
            var user = JSON.Parse(jsonUser).Result as Dictionary;
            player = Player.CreateInstance();
            player.Email = user["email"].ToString();
            player.Username = user["username"].ToString();
            player.LastName = user["lastName"].ToString();
            player.Token = user["token"].ToString();
            player.FirstName = user["firstName"].ToString();
            player.GameId = user["gameId"].ToString();
        }
    }

    public static void NewGame()
    {
        // Appeler sur le bouton nouvelle partie
        while (!Buildings.GenerateBuildings(_planInitial))
        {
            _planInitial = new PlanInitial();
        }

        Interface.Xp = 0;
        Montagnes.GenerateMontagne(_planInitial, ref MontagneList);
        Montagnes.GenerateMontagne(_planInitial, ref MontagneList);
        Montagnes.GenerateMontagne(_planInitial, ref MontagneList);

        //CREATION LACS
        Lacs.GenerateLac(_planInitial);
    }

    public static bool LoadGame()
    {
        // Appeller sur le bouton connexion
        var args = OS.GetCmdlineArgs();

        string game = null;
        if (args.Length > 1)
            game = Marshalls.Base64ToUtf8(args[1]);

        var loaded = SauvegardeManager.LoadGame(_planInitial, game);

        if (loaded)
        {
            _musique.Play();
        }

        return loaded;
    }

    public override void _Notification(int what)
    {
        if (what != MainLoop.NotificationWmQuitRequest)
            return;
        SauvegardeManager.SaveGame();
    }

    public static bool ExistBatiment(int indexBat)
    {
        bool found = false;
        int i = 0;
        int len = ListeBatiment.Count;
        while (!found && i < len)
        {
            (var pos, var bat) = ListeBatiment[i];
            if (bat == indexBat)
                found = true;
            i++;
        }

        return found;
    }
}