using System;
using Godot;
using SshCity.Game.Plan;

namespace SshCity.Game.Vehicules
{
    public partial class Vehicules
    {
	    private bool Croisement; //Si la voiture est devant un croisment 
	    private Vector2 BlocCroisment; //Savoit position bloc croisment
	    private Vector2[] arriveCroisment;
	    private Direction[] directionCroisement;
	    private string[] animationCroisment;
	    private bool isMovingCroisment;
	    private bool Virage = false;
	    private int WhichVirage;

	    /// <summary>
	    /// Indique si un deplacemetn à un croisment est valide ou pas 
	    /// </summary>
	    /// <param name="dir">La direction a verifie</param>
	    /// <returns>Deplacment possible ou non</returns>
	    private bool VerifDirectionCroisment(Direction dir)
	    {
		    switch (dir)
		    {
			    case Direction.TOP:
			    {
				    Vector2 CaseVerifie = BlocCroisment - new Vector2(0, 1);
				    int bloc = _planInitial.GetBlock(_planInitial.TileMap2, (int) CaseVerifie.x, (int) CaseVerifie.y);
				    if (Routes.IsRoute(bloc))
				    {
					    return true;
				    }
				    break;
			    }
			    case Direction.BOTTOM:
			    {
				    Vector2 CaseVerifie = BlocCroisment + new Vector2(0, 1);
				    int bloc = _planInitial.GetBlock(_planInitial.TileMap2, (int) CaseVerifie.x, (int) CaseVerifie.y);
				    if (Routes.IsRoute(bloc))
				    {
					    return true;
				    }
				    break;
			    }
			    case Direction.LEFT:
			    {
				    Vector2 CaseVerifie = BlocCroisment - new Vector2(1, 0);
				    int bloc = _planInitial.GetBlock(_planInitial.TileMap2, (int) CaseVerifie.x, (int) CaseVerifie.y);
				    if (Routes.IsRoute(bloc))
				    {
					    return true;
				    }
				    break;
			    }
			    case Direction.RIGHT:
			    {
				    Vector2 CaseVerifie = BlocCroisment + new Vector2(1, 0);
				    int bloc = _planInitial.GetBlock(_planInitial.TileMap2, (int) CaseVerifie.x, (int) CaseVerifie.y);
				    if (Routes.IsRoute(bloc))
				    {
					    return true;
				    }
				    break;
			    }
		    }

		    return false;
	    }
        public override void _Process(float delta)
		{
			base._Process(delta);
			
			//Set, en focntion de la direction et de l'animation passe en parametre,
			//la nouvelle direction du vehicule, son animaion, son decallage, sa case d'arrive.
			Action<(Direction direction1, string anim)> MovingDirection = para =>
			{
				Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(Position);
				Vector2 NextCase = DirectionToVector2(para.direction1) + new Vector2(-1, -1);
				if (Routes.IsRoute(_planInitial.GetBlock(_planInitial.TileMap2,
					(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y)))
				{
					_animatedSprite.Animation = para.anim;
					_collisionShape2D.Rotation =  CollisionAngle[_animatedSprite.Animation];
					Decallage = DecallageDico[_animatedSprite.Animation];
					isMoving = true;
					Vector2 nextBlock = positionActuel + DirectionToVector2(para.direction1);
					_deplacement = (_planInitial.TileMap2.MapToWorld(nextBlock) + Decallage) - Position;
					arrive = _planInitial.TileMap2.MapToWorld(nextBlock) + Decallage;
					direction = para.direction1;
				}
			};
			
			//Set le mouvement du vehicule lors d'un croisment 
			Action<(Vector2 posActuel, Vector2 aucroisement, Vector2 aprescroisement, string animavt, string animapres,
					Vector2 decallageDansCroisement, string[] animcroisment, Direction[]dircroisement)>
				MovingCroisementSwitch =
					tuple =>
					{
						Vector2 AuCroisement =
							_planInitial.TileMap2.MapToWorld(tuple.posActuel + tuple.aucroisement) +
							DecallageDico[tuple.animavt];
						Vector2 ApresCroisement =
							_planInitial.TileMap2.MapToWorld(tuple.posActuel + tuple.aprescroisement) +
							DecallageDico[tuple.animapres];
						arriveCroisment = new[]
						{
							AuCroisement - tuple.decallageDansCroisement,
							ApresCroisement
						};
						animationCroisment = tuple.animcroisment;
						directionCroisement = tuple.dircroisement;
					};
			
			Action<Direction> MovingCroisement = direction1 =>
			{
				bool WillDoSmth = VerifDirectionCroisment(direction1);
				Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(Position);
				if (WillDoSmth)
				{
					switch (_animatedSprite.Animation)
					{
						case "NE":
						{
							switch (direction1)
							{
								case Direction.BOTTOM:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(1, 0),
										new Vector2(1, 1),
										"NE",
										"SE",
										new Vector2(100, 50),
										new[] {"NE", "SE"},
										new[] {Direction.RIGHT, Direction.BOTTOM}));
									break;
								}
								case Direction.TOP:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(1, 0),
										new Vector2(1, -1),
										"NE",
										"NW",
										new Vector2(0, 0),
										new[] {"NE", "NW"},
										new[] {Direction.RIGHT, Direction.TOP}));
									break;
								}
								case Direction.RIGHT:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(1, 0),
										new Vector2(2, 0),
										"NE",
										"NE",
										new Vector2(0, 0),
										new[] {"NE", "NE"},
										new[] {Direction.RIGHT, Direction.RIGHT}));
									break;
								}
								default:
								{
									return;
								}
							}
							break;
						}
						case "SE":
						{
							switch (direction1)
							{
								case Direction.LEFT:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(0, 1),
										new Vector2(-1, 1),
										"SE",
										"SW",
										new Vector2(-80, 80),
										new[] {"SE", "SW"},
										new[] {Direction.BOTTOM, Direction.LEFT}));
									break;
								}
								case Direction.BOTTOM:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(0, 1),
										new Vector2(0, 2),
										"SE",
										"SE",
										new Vector2(0, 0),
										new[] {"SE", "SE"},
										new[] {Direction.BOTTOM, Direction.BOTTOM}));
									break;
								}
								case Direction.RIGHT:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(0, 1),
										new Vector2(1, 1),
										"SE",
										"NE",
										new Vector2(0, 0),
										new[] {"SE", "NE"},
										new[] {Direction.BOTTOM, Direction.RIGHT}));
									break;
								}
								default:
								{
									return;
								}
							}
							break;
						}
						case "SW":
						{
							switch (direction1)
							{
								case Direction.LEFT:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(-1, 0),
										new Vector2(-2, 0),
										"SW",
										"SW",
										new Vector2(0, 0),
										new[] {"SW", "SW"},
										new[] {Direction.LEFT, Direction.LEFT}));
									break;
								}
								case Direction.BOTTOM:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(-1, 0),
										new Vector2(-1, 1),
										"SW",
										"SE",
										new Vector2(40, 40),
										new[] {"SW", "SE"},
										new[] {Direction.LEFT, Direction.BOTTOM}));
									break;
								}
								case Direction.TOP:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(-1, 0),
										new Vector2(-1, -1),
										"SW",
										"NW",
										new Vector2(0, 0),
										new[] {"SW", "NW"},
										new[] {Direction.LEFT, Direction.TOP}));
									break;
								}
								default:
								{
									return;
								}
							}
							break;
						}
						case "NW":
						{
							switch (direction1)
							{
								case Direction.LEFT:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(0, -1),
										new Vector2(-1, -1),
										"NW",
										"SW",
										new Vector2(-80, 80),
										new[] {"NW", "SW"},
										new[] {Direction.TOP, Direction.LEFT}));
									break;
								}
								case Direction.TOP:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(0, -1),
										new Vector2(0, -2),
										"NW",
										"NW",
										new Vector2(0, 0),
										new[] {"NW", "NW"},
										new[] {Direction.TOP, Direction.TOP}));
									break;
								}
								case Direction.RIGHT:
								{
									MovingCroisementSwitch((positionActuel,
										new Vector2(0, -1),
										new Vector2(1, -1),
										"NW",
										"NE",
										new Vector2(0, 0),
										new[] {"NW", "NE"},
										new[] {Direction.TOP, Direction.RIGHT}));
									break;
								}
								default:
								{
									return;
								}
							}
							break;
						}
					}
					
					_deplacement = arriveCroisment[0] - Position;
					arrive = arriveCroisment[0];
					direction = directionCroisement[0];
					Croisement = false;
					isMovingCroisment = true;
					isMoving = true;
				}
			};
			Action<int> MovingVirage = bloc =>
			{
				switch (bloc)
				{
					case Ref_donnees.route_virage_bas:
					{
						switch (_animatedSprite.Animation)
						{
							case "SE":
							{
								MovingCroisement(Direction.LEFT);
								break;
							}
							case "NE":
							{
								MovingCroisement(Direction.TOP);
								break;
							}
						}
						break;
					}
					case Ref_donnees.route_virage_haut:
					{
						switch (_animatedSprite.Animation)
						{
							case "SW":
							{
								MovingCroisement(Direction.BOTTOM);
								break;
							}
							case "NW":
							{
								MovingCroisement(Direction.RIGHT);
								break;
							}
						}
						break;
					}
					case Ref_donnees.route_virage_gauche:
					{
						switch (_animatedSprite.Animation)
						{
							case "SW":
							{
								MovingCroisement(Direction.TOP);
								break;
							}
							case "SE":
							{
								MovingCroisement(Direction.RIGHT);
								break;
							}
						}
						break;
					}
					case Ref_donnees.route_virage_droit:
					{
						switch (_animatedSprite.Animation)
						{
							case "NW":
							{
								MovingCroisement(Direction.LEFT);
								break;
							}
							case "NE":
							{
								MovingCroisement(Direction.BOTTOM);
								break;
							}
						}
						break;
					}
				}
			};
			
			if (isMoving && !Croisement) //Si le vehicule est en mouvement et que l'on n'est pas a un croisement
			{
				if ((direction == Direction.RIGHT && Position >= arrive) ||
					(direction == Direction.LEFT && Position <= arrive) ||
					(direction == Direction.TOP && Position >= arrive) ||
					(direction == Direction.BOTTOM && Position <= arrive)) //Si le vehicule est arrive au bloc suivant
				{
					Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(Position);
					Vector2 NextCase = DirectionToVector2(direction) + new Vector2(-1, -1); // Position du bloc suivant. new Vector2(-1, -1) pour difference dans le TileSet
					if (_planInitial.GetBlock(_planInitial.TileMap1,(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y) == -1) //Enleve le vehicule quand il sort de la map
					{
						PlanInitial.NbCar -= 1;	
						this.QueueFree();
					}

					if (!isMovingCroisment && Routes.IsRoute(_planInitial.GetBlock(_planInitial.TileMap2,
						                       (int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y))
					                       && !Routes.IsCroisement(_planInitial.GetBlock(_planInitial.TileMap2,
						                       (int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y))
					                       &&!Routes.IsVirage(_planInitial.GetBlock(_planInitial.TileMap2,
						                       (int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y))) //Si le bloc suivant est une route mais pas un croisment ni un virage
					{
						Vector2 nextBlock = positionActuel + DirectionToVector2(direction);
						_deplacement = (_planInitial.TileMap2.MapToWorld(nextBlock) + Decallage) - Position;
						arrive = _planInitial.TileMap2.MapToWorld(nextBlock) + Decallage;
					}
					else if(isMovingCroisment) // Si le vehicule réalise un deplacement croisement
					{
						_deplacement = arriveCroisment[1] - Position;
						arrive = arriveCroisment[1];
						direction = directionCroisement[1];
						_animatedSprite.Animation = animationCroisment[1];
						_collisionShape2D.Rotation =  CollisionAngle[_animatedSprite.Animation];
						Croisement = false;
						isMovingCroisment = false;
						isMoving = true;
						Decallage = DecallageDico[_animatedSprite.Animation];
					}
					else if (Routes.IsCroisement(_planInitial.GetBlock(_planInitial.TileMap2,
                             							(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y))
							&& !Routes.IsVirage(_planInitial.GetBlock(_planInitial.TileMap2,
														(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y))) //Si le bloc suivant est un croisment mais pas un virage
					{
						Croisement = true;
						isMoving = false;
						_deplacement = new Vector2(0, 0);
						BlocCroisment = new Vector2((int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y);
					}
					else if(Routes.IsVirage(_planInitial.GetBlock(_planInitial.TileMap2, (int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y)))
						//Si le bloc suivant est un virage
					{
						isMoving = false;
						_deplacement = new Vector2(0, 0);
						BlocCroisment = new Vector2((int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y);
						WhichVirage = _planInitial.GetBlock(_planInitial.TileMap2,
							(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y);
						MovingVirage(WhichVirage);
					}
					else //sinon le vehicule arrete de rouler
					{
						isMoving = false;
						_deplacement = new Vector2(0, 0);
					}
				}
			}

			//input deplacement vehicule quand il n'est pas autonome en fonction des fleches claviers pressé.
			if (!_paused && !isMoving && !Autonome && Input.IsActionPressed("ui_right")) // Gauche
			{
				if (Croisement)
				{
					MovingCroisement(Direction.RIGHT);
				}
				else
					MovingDirection((Direction.RIGHT, "NE"));
			}

			if (!_paused && !isMoving && !Autonome && Input.IsActionPressed("ui_left"))//droite
			{
				if (Croisement)
				{
					MovingCroisement(Direction.LEFT);
				}
				else
				{
					MovingDirection((Direction.LEFT, "SW"));
				}
			}

			if (!_paused && !isMoving && !Autonome && Input.IsActionPressed("ui_down"))//bas
			{
				if (Croisement)
				{
					MovingCroisement(Direction.BOTTOM);
				}
				else
				{
					MovingDirection((Direction.BOTTOM, "SE"));
				}
			}

			if (!_paused && !isMoving && !Autonome && Input.IsActionPressed("ui_up"))//Haut
			{
				if (Croisement)
				{
					MovingCroisement(Direction.TOP);
				}
				else
				{
					MovingDirection((Direction.TOP, "NW"));
				}
			}

			//Si c'est un vehicule autonome, il va choisir une direction pour faire bouger le vehicule quand celui ci ne bouge pas
			if (!_paused && Autonome && !isMoving)
			{
				int randNumber = rand.Next(0, 4);
				Direction direction = ListDirection[randNumber];
				if (Croisement)
				{
					MovingCroisement(direction);
				}
				else
				{
					MovingDirection((direction, DirectionToAnim[direction]));
				}
			}
			
			//Deplace le vehicule. Si _paused alors le vehicule ne bouge plus
			if (!_paused)
			{
				Position += _deplacement * delta;
			}

		}
    }
}