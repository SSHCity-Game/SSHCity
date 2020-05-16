using System;
using System.Linq.Expressions;
using Godot;
using Godot.Collections;

namespace SshCity.Game.Plan
{
    public partial class Vehicules: Area2D
    {
	    private bool Croisement = false; //Si la voiture est devant un croisment 
	    private Vector2 BlocCroisment; //Savoit quel bloc croisment est devant le camion
	    private Vector2[] arriveCroisment;
	    private Direction[] directionCroisement;
	    private string[] animationCroisment;
	    private bool isMovingCroisment = false;

	    private bool VerifDirectionCroisment(Direction dir, Vector2 position)
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
			Action<(Direction direction1, string anim)> MovingDirection = para =>
			{
				Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(this.Position);
				Vector2 NextCase = Vehicules.DirectionToVector2(para.direction1) + new Vector2(-1, -1);
				if (Routes.IsRoute(_planInitial.GetBlock(_planInitial.TileMap2,
					(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y)))
				{
					_animatedSprite.Animation = para.anim;
					Decallage = DecallageDico[_animatedSprite.Animation];
					isMoving = true;
					Vector2 nextBlock = positionActuel + DirectionToVector2(para.direction1);
					_deplacement = (_planInitial.TileMap2.MapToWorld(nextBlock) + Decallage) - this.Position;
					arrive = _planInitial.TileMap2.MapToWorld(nextBlock) + Decallage;
					direction = para.direction1;
				}
			};

			if (isMoving && !Croisement)
			{
				if ((direction == Vehicules.Direction.RIGHT && this.Position >= arrive) ||
					(direction == Vehicules.Direction.LEFT && this.Position <= arrive) ||
					(direction == Vehicules.Direction.TOP && this.Position >= arrive) ||
					(direction == Vehicules.Direction.BOTTOM && this.Position <= arrive))
				{
					Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(this.Position);
					Vector2 NextCase = Vehicules.DirectionToVector2(direction) + new Vector2(-1, -1);
					if (!isMovingCroisment && Routes.IsRoute(_planInitial.GetBlock(_planInitial.TileMap2,
							(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y))
						&& !Routes.IsCroisement(_planInitial.GetBlock(_planInitial.TileMap2,
							(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y)))
					{
						Vector2 nextBlock = positionActuel + Vehicules.DirectionToVector2(direction);
						_deplacement = (_planInitial.TileMap2.MapToWorld(nextBlock) + Decallage) - this.Position;
						arrive = _planInitial.TileMap2.MapToWorld(nextBlock) + Decallage;
					}
					else if(isMovingCroisment)
					{
						_deplacement = arriveCroisment[1] - this.Position;
						arrive = arriveCroisment[1];
						direction = directionCroisement[1];
						_animatedSprite.Animation = animationCroisment[1];
						Croisement = false;
						isMovingCroisment = false;
						isMoving = true;
						Decallage = DecallageDico[_animatedSprite.Animation];
					}
					else if (Routes.IsCroisement(_planInitial.GetBlock(_planInitial.TileMap2,
                             							(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y)))
					{
						Croisement = true;
						isMoving = false;
						_deplacement = new Vector2(0, 0);
						BlocCroisment = new Vector2((int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y);
					}
					else
					{
						isMoving = false;
						_deplacement = new Vector2(0, 0);
					}
				}
			}

			Action<Direction> MovingCroisement = direction1 =>
			{
				bool WillDoSmth = VerifDirectionCroisment(direction1, BlocCroisment);
				Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(this.Position);
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
									Vector2 AuCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(1, 0)) +
										DecallageDico["NE"];
									Vector2 ApresCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(1, 1)) +
										DecallageDico["SE"];
									arriveCroisment = new[]
									{
										AuCroisement-new Vector2(100, 50),	
										ApresCroisement
									};
									animationCroisment = new[] {"NE", "SE"};
									directionCroisement = new[] {Direction.RIGHT, Direction.BOTTOM};
									break;
								}
								case Direction.TOP:
								{
									Vector2 AuCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(1, 0)) +
										DecallageDico["NE"];
									Vector2 ApresCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(1, -1)) +
										DecallageDico["NW"];
									arriveCroisment = new[]
									{
										AuCroisement,	
										ApresCroisement
									};
									animationCroisment = new[] {"NE", "NW"};
									directionCroisement = new[] {Direction.RIGHT, Direction.TOP};
									break;
								}
								case Direction.RIGHT:
								{
									Vector2 AuCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(1, 0)) +
										DecallageDico["NE"];
									Vector2 ApresCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(2, 0)) +
										DecallageDico["NE"];
									arriveCroisment = new[]
									{
										AuCroisement,	
										ApresCroisement
									};
									animationCroisment = new[] {"NE", "NE"};
									directionCroisement = new[] {Direction.RIGHT, Direction.RIGHT};
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
									Vector2 AuCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(0, 1)) +
										DecallageDico["SE"];
									Vector2 ApresCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(-1, 1)) +
										DecallageDico["SW"];
									arriveCroisment = new[]
									{
										AuCroisement-new Vector2(-80, 80),	
										ApresCroisement
									};
									animationCroisment = new[] {"SE", "SW"};
									directionCroisement = new[] {Direction.BOTTOM, Direction.LEFT};
									break;
								}
								case Direction.BOTTOM:
								{
									Vector2 AuCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(0, 1)) +
										DecallageDico["SE"];
									Vector2 ApresCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(0, 2)) +
										DecallageDico["SE"];
									arriveCroisment = new[]
									{
										AuCroisement,	
										ApresCroisement
									};
									animationCroisment = new[] {"SE", "SE"};
									directionCroisement = new[] {Direction.BOTTOM, Direction.BOTTOM};
									break;
								}
								case Direction.RIGHT:
								{
									Vector2 AuCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(0, 1)) +
										DecallageDico["SE"];
									Vector2 ApresCroisement =
										_planInitial.TileMap2.MapToWorld(positionActuel + new Vector2(1, 1)) +
										DecallageDico["NE"];
									arriveCroisment = new[]
									{
										AuCroisement,	
										ApresCroisement
									};
									animationCroisment = new[] {"SE", "NE"};
									directionCroisement = new[] {Direction.BOTTOM, Direction.RIGHT};
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
					
					_deplacement = arriveCroisment[0] - this.Position;
					arrive = arriveCroisment[0];
					direction = directionCroisement[0];
					Croisement = false;
					isMovingCroisment = true;
					isMoving = true;
				}
			};
			
			//input deplacement inital
			if (!isMoving && Input.IsActionPressed("ui_right"))
			{
				if (Croisement)
				{
					MovingCroisement(Direction.RIGHT);
				}
				else
					MovingDirection((Vehicules.Direction.RIGHT, "NE"));
			}

			if (!isMoving && Input.IsActionPressed("ui_left"))
			{
				if (Croisement)
				{
					MovingCroisement(Direction.LEFT);
				}
				else
				{
					MovingDirection((Vehicules.Direction.LEFT, "SW"));
				}
			}

			if (!isMoving && Input.IsActionPressed("ui_down"))
			{
				if (Croisement)
				{
					MovingCroisement(Direction.BOTTOM);
				}
				else
				{
					MovingDirection((Vehicules.Direction.BOTTOM, "SE"));
				}
			}

			if (!isMoving && Input.IsActionPressed("ui_up"))
			{
				if (Croisement)
				{
					MovingCroisement(Direction.TOP);
				}
				else
				{
					MovingDirection((Vehicules.Direction.TOP, "NW"));
				}
			}

			this.Position += _deplacement * delta;
		}
    }
}