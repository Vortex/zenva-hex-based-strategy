using Godot;
using System;
using System.Collections.Generic;

public partial class TerrainTileUi : Panel
{
	public static Dictionary<TerrainType, string> terrainTypeStrings = new Dictionary<TerrainType, string>
	{
		{ TerrainType.PLAINS, "Plains" },
		{ TerrainType.BEACH, "Beach" },
		{ TerrainType.DESERT, "Desert" },
		{ TerrainType.MOUNTAIN, "Mountain" },
		{ TerrainType.ICE, "Ice" },
		{ TerrainType.WATER, "Water" },
		{ TerrainType.SHALLOW_WATER, "Shallow Water" },
		{ TerrainType.FOREST, "Forest" },
	};

	// Data hex
	Hex h = null;

	// UI Components
	TextureRect terrainImage;
	Label terrainLabel, foodLabel, productionLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		terrainImage = GetNode<TextureRect>("TerrainImage");
		terrainLabel = GetNode<Label>("TerrainLabel");
		foodLabel = GetNode<Label>("FoodLabel");
		productionLabel = GetNode<Label>("ProductionLabel");
	}

	public void SetHex(Hex h)
	{
		this.h = h;

		foodLabel.Text = $"Food: {h.food}";
		productionLabel.Text = $"Production: {h.production}";
		terrainLabel.Text = $"Terrain: {terrainTypeStrings[h.terrainType]}";
	}

}
