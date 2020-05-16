using System;
using Godot;
using Godot.Collections;

namespace SshCity.Game.Plan
{
    public partial class Vehicules: Area2D
    {
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

			if (isMoving)
			{
				if ((direction == Vehicules.Direction.RIGHT && this.Position >= arrive) ||
					(direction == Vehicules.Direction.LEFT && this.Position <= arrive) ||
					(direction == Vehicules.Direction.TOP && this.Position >= arrive) ||
					(direction == Vehicules.Direction.BOTTOM && this.Position <= arrive))
				{
					Vector2 positionActuel = _planInitial.TileMap2.WorldToMap(this.Position);
					Vector2 NextCase = Vehicules.DirectionToVector2(direction) + new Vector2(-1, -1);
					if (Routes.IsRoute(_planInitial.GetBlock(_planInitial.TileMap2,
							(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y))
						&& !Routes.IsCroisement(_planInitial.GetBlock(_planInitial.TileMap2,
							(int) positionActuel.x + (int) NextCase.x, (int) positionActuel.y + (int) NextCase.y)))
					{
						Vector2 nextBlock = positionActuel + Vehicules.DirectionToVector2(direction);
						_deplacement = (_planInitial.TileMap2.MapToWorld(nextBlock) + Decallage) - this.Position;
						arrive = _planInitial.TileMap2.MapToWorld(nextBlock) + Decallage;
					}
					else
					{
						isMoving = false;
						_deplacement = new Vector2(0, 0);
					}
				}
			}

			if (!isMoving && Input.IsActionPressed("ui_right"))
			{
				MovingDirection((Vehicules.Direction.RIGHT, "NE"));
			}

			if (!isMoving && Input.IsActionPressed("ui_left"))
			{
				MovingDirection((Vehicules.Direction.LEFT, "SW"));
			}

			if (!isMoving && Input.IsActionPressed("ui_down"))
			{
				MovingDirection((Vehicules.Direction.BOTTOM, "SE"));
			}

			if (!isMoving && Input.IsActionPressed("ui_up"))
			{
				MovingDirection((Vehicules.Direction.TOP, "NW"));
			}

			this.Position += _deplacement * delta;
		}

		public void CollisionCamion()
		{
			this.Hide();
		}
    }
}