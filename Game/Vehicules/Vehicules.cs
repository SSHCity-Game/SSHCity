using System;
using System.Collections.Generic;
using Godot;
using SshCity.Game.Plan;

namespace SshCity.Game.Vehicules
{
    public partial class Vehicules: Area2D
    {
        private const string _strAnimatedSprite = "AnimatedSprite";
        private const string _strCollsionShape2D = "CollisionShape2D";
        private const string _strCollisionShapeAutonome = "AutonomeZone";
        private Sprite _invincible;
        private const string _strInvincible = "Invincible";
        private AnimatedSprite _animatedSprite;
        private CollisionShape2D _collisionShape2D;
        private CollisionShape2D _collisionShapeAutonome;
        private Vector2 _deplacement;
        private PlanInitial _planInitial;
        private Vector2 arrive;
        private bool Autonome;
        private static Random rand = new Random();
        private bool _paused = false;
        private bool _stopArea2DCreat = false;
        private Timer _timer;
        private const string _strTimer = "Timer";
        private bool _stopAccident = false;
        private bool _mouseIn = false;
        private bool _controleVehicule = false;
        private Type _type;

        public enum Direction
        {
            TOP,
            LEFT,
            BOTTOM,
            RIGHT
        }
        
        public static List<Direction> ListDirection = new List<Direction>()
        {
            {Direction.TOP},
            {Direction.BOTTOM},
            {Direction.RIGHT},
            {Direction.LEFT}
        };

        public enum Type
        {
            CAMION,
            AMBULANCE,
            VOITURE,
            VOITURECOURSE,
            POLICE,
            SPORTIVE,
            LUXE,
            SUV,
            LIVRAISON,
            HATCHBACK,
            TAXI,
            TRACTEURPOLICE,
            TRACTOPEL,
            TRACTEUR,
            VOITURETRUCK,
            VAN
        }

        /// <summary>
        /// Permet avec la direction du vehicule d'avoir le vecteur a ajouter par rapport à sa position pour aller sur le bloc suivant
        /// </summary>
        /// <param name="dir">Direction du vehicule</param>
        /// <returns>Le vecteur a ajouté pour aller sur le bloc suivant</returns>
        public static Vector2 DirectionToVector2(Direction dir)
        {
            return dir switch
            {
                Direction.BOTTOM => new Vector2(0, 1),
                Direction.TOP => new Vector2(0, -1),
                Direction.LEFT => new Vector2(-1, 0),
                Direction.RIGHT => new Vector2(1, 0),
                _ => throw new ArgumentException()
            };
        }
        /// <summary>
        ///Choisis l'animation du vehicule (son orientation) par rapport à la route au depart
        /// </summary>
        Godot.Collections.Dictionary<int, string>  WhichAnimation = new Godot.Collections.Dictionary<int, string>()
        {
            {Ref_donnees.route_left, "NE"},
            {Ref_donnees.route_right, "SE"},
            {Ref_donnees.route_bord_haut_gauche, "NE"},
            {Ref_donnees.route_bord_haut_droit, "SE"},
            {Ref_donnees.route_bord_bas_gauche, "NW"},
            {Ref_donnees.route_bord_bas_droit, "SW"},
            {Ref_donnees.route_T_bas_droite, "SE"},
            {Ref_donnees.route_T_bas_gauche, "SW"},
            {Ref_donnees.route_T_haut_droit, "NE"},
            {Ref_donnees.route_T_haut_gauche, "NW"},
            {-1, "NE"}
        };
        
        private Vector2 Decallage;

        /// <summary>
        /// Converti une animation en décallage du vehicule pour qu'il soit centre sur la route
        /// </summary>
        Godot.Collections.Dictionary<string, Vector2> DecallageDico = new Godot.Collections.Dictionary<string, Vector2>()
        {
            {"NE", new Vector2(100, 230)},
            {"NW", new Vector2(70, 220)},
            {"SE", new Vector2(-20, 150)},
            {"SW", new Vector2(175, 150)}
        };

        
        /// <summary>
        /// Converti l'animation en angle pour faire touner le collisionShape2D
        /// </summary>
        Godot.Collections.Dictionary<string, int> CollisionAngle = new Godot.Collections.Dictionary<string, int>()
        {
            {"NE", 27},
            {"NW", -27},
            {"SE", -27},
            {"SW", 27}
        };
        
        /// <summary>
        /// Converti la direction en animation
        /// </summary>
        Godot.Collections.Dictionary<Direction, string> DirectionToAnim = new Godot.Collections.Dictionary<Direction, string>()
        {
            {Direction.TOP, "NW"},
            {Direction.BOTTOM, "SE"},
            {Direction.LEFT, "SW"},
            {Direction.RIGHT, "NE"}
        };

        /// <summary>
        /// Converti le type d'un vehicule en son animatedSprite qui lui correspond
        /// </summary>
        Godot.Collections.Dictionary<Type, SpriteFrames> AnimatedSpriteType = new Godot.Collections.Dictionary<Type, SpriteFrames>()
        {
            {Type.AMBULANCE, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Ambulance_animatedSprite.tres") as SpriteFrames},
            {Type.CAMION, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Camion_animatedSprite.tres") as SpriteFrames},
            {Type.VOITURE, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Voiture_animatedSprite.tres") as SpriteFrames},
            {Type.POLICE, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Police_animatedSprite.tres") as SpriteFrames},
            {Type.SPORTIVE, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/VoitureSport_animatedSprite.tres") as SpriteFrames},
            {Type.LUXE, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Luxe_animatedSprite.tres") as SpriteFrames},
            {Type.SUV, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/SUV_animatedSprite.tres") as SpriteFrames},
            {Type.LIVRAISON, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Livraison_animatedSprite.tres") as SpriteFrames},
            {Type.HATCHBACK, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/HatchBack_animatedSprite.tres") as SpriteFrames},
            {Type.VOITURECOURSE, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/VoitureCourse_animatedSprite.tres") as SpriteFrames},
            {Type.TAXI, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Taxi_animatedSprite.tres") as SpriteFrames},
            {Type.TRACTEURPOLICE, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/TracteurPolice_animatedSprite.tres") as SpriteFrames},
            {Type.TRACTOPEL, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Tractopel_animatedSprite.tres") as SpriteFrames},
            {Type.TRACTEUR, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Tracteur_animatedSprite.tres") as SpriteFrames},
            {Type.VOITURETRUCK, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/VoitureTruck_animatedSprite.tres") as SpriteFrames},
            {Type.VAN, ResourceLoader.Load("res://Game/Vehicules/ANimatedSpriteVehicules/Van_animatedSprite.tres") as SpriteFrames},
        };
        
        private Direction direction;
        private bool isMoving = false;

        /// <summary>
        /// Correspond au constructeur du Vehicule
        /// </summary>
        /// <param name="planInitial">PlanInitial afin de convertir les coordonne</param>
        /// <param name="position">position ou est set le vehicule</param>
        /// <param name="type">type du vehicule pose</param>
        /// <param name="autonome">choisir si le vehicule se direige tout seul ou manuellement</param>
        public void Init(PlanInitial planInitial, Vector2 position, Type type, bool autonome=false)
        {
            _type = type;
            _animatedSprite = (AnimatedSprite) GetNode(_strAnimatedSprite);
            _collisionShape2D = (CollisionShape2D) GetNode(_strCollsionShape2D);
            Autonome = autonome; //Determine si le vehicule se deplace tout seul ou s'il faut que le joueur le dirige avec les fleches
            this._planInitial = planInitial;
            SpriteFrames spriteFrames = AnimatedSpriteType[type]; //Charge l'animatedSprite, donc l'image du vehicule, en fonction du type rentre en parametre
            _animatedSprite.Frames = spriteFrames; //Set l'animatedSprite
            int blocRoute = planInitial.GetBlock(planInitial.TileMap2, (int) position.x, (int) position.y); //Recupere l'index du bloc route sur le quel est le vehicule
            _animatedSprite.Animation = WhichAnimation[blocRoute]; //Set l'animation en fonction du bloc route
            Decallage = DecallageDico[_animatedSprite.Animation]; //Decallage du vehicule en fonction de l'animation pour qu'il soit centre sur la route
            _collisionShape2D.Rotation =  CollisionAngle[_animatedSprite.Animation]; // Rotation du CollisionShape2D en fonction de l'anmation pour qu'il soit centré sur le vehicule
            Connect("area_entered", this, nameof(Collision));//Connect la collision
            Connect("area_exited", this, nameof(EndCollision));//Connect la resolution de l'accident
            this.Position = planInitial.TileMap2.MapToWorld(position + new Vector2(1, 1)) + Decallage; //Set la position du vehicule. LE new Vector2(1, 1) correspond au decallage du tileset
            _collisionShapeAutonome = (CollisionShape2D) GetNode(_strCollisionShapeAutonome);
            if (!autonome)
            {
                CollisionMask = 8;
                CollisionLayer = 4;
                Connect("mouse_entered", this, nameof(MouseEntered));
                Connect("mouse_exited", this, nameof(MouseExited));
            }
            else
            {
                GetChild(3).QueueFree();
            }
        }
        
        public override void _Ready()
        {
            base._Ready();
            _timer = (Timer) GetNode(_strTimer);
            _timer.Connect("timeout", this, nameof(TimeOut));
            _invincible = (Sprite) GetNode(_strInvincible);
        }

        public void MouseEntered()
        {
            _mouseIn = true;
        }

        public void MouseExited()
        {
            _mouseIn = false;
        }

        /// <summary>
        /// Fonction connectée à l'area2D lorsqu'une area2D rentre dans celle-ci
        /// Lorsque le vehicule rentre en collision soit avec un autre vehicule soit avec une zone accident
        /// </summary>
        /// <param name="area2D">L'area2D venant de rentrer dans l'area2D</param>
        public void Collision(Area2D area2D)
        {
            if (_type == Type.AMBULANCE)
            {
                if (area2D.CollisionMask == 7)
                {
                    Accident accident = (Accident) area2D;
                    if (accident.Visi)
                    {
                        incidents.Nbaccident--;
                        accident.QueueFree();
                        menu_incident.Accident.Hide();
                        Interface.Xp += 50;
                    }
                }
            }
            else if (!_stopArea2DCreat && !_stopAccident && _type != Type.AMBULANCE && _type != Type.POLICE && _type != Type.CAMION)
            {
                if (area2D.CollisionMask == 1)
                {
                    if (incidents.Nbaccident < incidents.MAX_ACCIDENT+1)
                    {
                        incidents.Nbaccident++;
                        Vector2 position = _planInitial.TileMap2.WorldToMap(Position) - new Vector2(1, 1);
                        PlanInitial.AddZoneAccident(Position, true);
                        PlanInitial.NbCar -= 1;
                        menu_incident.Accident.Show();
                        QueueFree();
                    }
                }
                else
                {
                    PlanInitial.AddZoneAccident(Position, false);
                    _paused = true;
                    _stopArea2DCreat = true;
                }
            }
        }

        /// <summary>
        /// Fonction connectée à l'area2D lorsqu'une area2D sors de celle-ci
        /// Permet de detecte la fin d'un accident et de remettre en route les vehicules
        /// </summary>
        /// <param name="area2D">L'area2D qui vient de sortir</param>
        public void EndCollision(Area2D area2D)
        {
            if (area2D.CollisionMask == 7 && _type != Type.AMBULANCE && _type != Type.POLICE && _type != Type.CAMION) //Tets si l'area2D est une area2D Accident
            {
                _stopArea2DCreat = false;
                _paused = false;
                _stopAccident = true;
                _invincible.Show();
                _timer.Start();
            }
        }

        /// <summary>
        /// Fonction connecté au timer lors du timeout
        /// Met fin a l'invincibilité d'un vehicule 
        /// </summary>
        public void TimeOut()
        {
            _stopAccident = false;
            _invincible.Hide(); 
        }
        
        /// <summary>
        /// Liste des differents types de Vehicules
        /// Est utilise afin de choisir un type de vehicule aleatoirement
        /// </summary>
        public static List<Type> ListTypeVehicules = new List<Type>()
        {
            {Type.SUV},
            {Type.VAN},
            {Type.LUXE},
            {Type.TAXI},
            {Type.SPORTIVE},
            {Type.VOITURE},
            {Type.TRACTEUR},
            {Type.HATCHBACK},
            {Type.LIVRAISON},
            {Type.TRACTOPEL},
            {Type.VOITURETRUCK},
            {Type.VOITURECOURSE},
        };
    }
}