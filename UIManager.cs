using Godot;
using System;

public partial class UIManager : Node2D
{
	PackedScene terrainUiScene;
	PackedScene cityUiScene;

	TerrainTileUi terrainUi = null;
	CityUi cityUi = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		terrainUiScene = ResourceLoader.Load<PackedScene>("terrain_tile_ui.tscn");
		cityUiScene = ResourceLoader.Load<PackedScene>("city_ui.tscn");
	}

	public void HideAllPopups()
	{
		if (terrainUi is not null)
		{
			terrainUi.QueueFree();
			terrainUi = null;
		}

		if (cityUi is not null)
		{
			cityUi.QueueFree();
			cityUi = null;
		}
	}

	public void SetCityUI(City c)
	{
		HideAllPopups();


		cityUi = (CityUi)cityUiScene.Instantiate() as CityUi;
		AddChild(cityUi);

		cityUi.SetCityUI(c);

	}
	public void SetTerrainUI(Hex h)
	{
		HideAllPopups();

		terrainUi = (TerrainTileUi)terrainUiScene.Instantiate();
		AddChild(terrainUi);
		terrainUi.SetHex(h);
	}
}
