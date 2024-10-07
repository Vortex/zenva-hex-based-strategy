using Godot;
using System;

public partial class UiManager : Node2D
{
	PackedScene terrainUiScene;

	TerrainTileUi terrainUi;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		terrainUiScene = ResourceLoader.Load<PackedScene>("terrain_tile_ui.tscn");
	}

	public void SetTerrainUI(Hex h)
	{
		if (terrainUi is not null) terrainUi.QueueFree();

		terrainUi = (TerrainTileUi)terrainUiScene.Instantiate();
		terrainUi.SetHex(h);
		AddChild(terrainUi);
	}
}
