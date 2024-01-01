namespace CMSGame
{
	[SceneTree]
	internal partial class BattleScene : Node2D
	{
		public const int TileSize = 64;

		private readonly Dictionary<Vector2I, BattleUnitSprite> _position2unit = new();

		private readonly HashSet<BattleUnitSprite> _sprites = new();

		private BattleUnitSprite? _selectedSprite = null;

		public override void _Ready()
		{
			// 设置控件
			SetupSprites();
			SetupCamera();

			// 连接信号
			SelectionMarker.SelectionChanged += (gridPosition) =>
			{
				SelectionHintBox.ShowText(BattleTileMap.GetBattleTileData(gridPosition));
				_selectedSprite = _position2unit.ContainsKey(gridPosition) ? _position2unit[gridPosition] : null;
				CharacterStatusBox.ShowInfo(_selectedSprite);
			};
		}

		private void SetupSprites()
		{
			foreach (var child in Units.GetChildren())
			{
				if (child is BattleUnitSprite sprite)
				{
					_sprites.Add(sprite);
					_position2unit[sprite.GridPosition] = sprite;
				}
			}
		}

		private void SetupCamera()
		{
			var used = BattleTileMap.GetUsedRect().Grow(-1);
			Rect2I cameraArea = new()
			{
				Position = used.Position * TileSize,
				End = used.End * TileSize
			};
			BattleCamera.Limit = cameraArea;
		}

		public override void _Input(InputEvent @event)
		{
			if (@event is InputEventMouse mouseEvent)
			{
				HandleMouseInput(mouseEvent);
			}
			else if (@event is InputEventKey keyEvent)
			{
				HandleKeyboardInput(keyEvent);
			}
		}

		public void HandleMouseInput(InputEventMouse mouseEvent)
		{
			// 选择
			if (mouseEvent.IsActionPressed(InputActions.Select))
			{
				var globalPosition = BattleCamera.GetScreenCenterPosition() - GetViewport().GetWindow().Size / 2 + mouseEvent.GlobalPosition;
				var localPositionToTileMap = globalPosition - BattleTileMap.Position;
				var gridPosition = BattleTileMap.LocalToMap(localPositionToTileMap);
				TryMoveSelectionMarkerTo(gridPosition);
			}

			// 取消选择
			if (mouseEvent.IsActionPressed(InputActions.Deselect))
			{
				_selectedSprite = null;
			}

			// 鼠标镜头拖动
			if ((mouseEvent.ButtonMask & MouseButtonMask.Middle) != 0)
			{
				if (InputActions.IsMiddleMouseDragging)
				{
					var dragDistance = mouseEvent.Position - InputActions.LastMiddleMouseDragEvent!.Position;
					BattleCamera.Pan(-dragDistance);
				}
				InputActions.LastMiddleMouseDragEvent = mouseEvent;
			}
			else
			{
				if (InputActions.IsMiddleMouseDragging)
				{
					InputActions.LastMiddleMouseDragEvent = null;
				}
			}
		}

		public void HandleKeyboardInput(InputEventKey keyEvent)
		{
			// 暂停菜单
			if (keyEvent.IsActionPressed(InputActions.BattlePause))
			{
				PauseMenu.Visible = !PauseMenu.Visible;
			}

			// 是否为方向输入
			foreach (var kv in InputActions.MoveDirections)
			{
				var action = kv.Key;
				var direction = kv.Value;
				if (keyEvent.IsAction(action) && keyEvent.Pressed == true)
				{
					TryMoveSelectionMarkerTo(SelectionMarker.GridPosition + direction);
					BattleCamera.ShootOn(SelectionMarker.Position);
				}
			}
		}

		protected void TryMoveSelectionMarkerTo(Vector2I gridPosition)
		{
			var tileData = BattleTileMap!.GetCellTileData(0, gridPosition);
			var isBoundary = tileData.GetCustomData("is_boundary").As<bool>();
			if (!isBoundary)
				SelectionMarker.MoveTo(gridPosition);
		}

		private void DisplayMarksOfUnit(BattleUnitSprite unit)
		{
		}

		private void GetMarksOfUnit(BattleUnitSprite unit)
		{
		}
	}
}
