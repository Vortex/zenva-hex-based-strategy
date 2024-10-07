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

	public static Dictionary<TerrainType, Texture2D> terrainTypeImages = new Dictionary<TerrainType, Texture2D>();

	public static void LoadTerrainImages()
	{
		Texture2D plains = ResourceLoader.Load<Texture2D>("res://textures/plains.jpg");
		Texture2D beach = ResourceLoader.Load<Texture2D>("res://textures/beach.jpg");
		Texture2D desert = ResourceLoader.Load<Texture2D>("res://textures/desert.jpg");
		Texture2D mountain = ResourceLoader.Load<Texture2D>("res://textures/mountain.jpg");
		Texture2D ice = ResourceLoader.Load<Texture2D>("res://textures/ice.jpg");
		Texture2D ocean = ResourceLoader.Load<Texture2D>("res://textures/ocean.jpg");
		Texture2D shallow = ResourceLoader.Load<Texture2D>("res://textures/shallow.jpg");
		Texture2D forest = ResourceLoader.Load<Texture2D>("res://textures/forest.jpg");

		terrainTypeImages = new Dictionary<TerrainType, Texture2D>
		{
			{ TerrainType.PLAINS, plains },
			{ TerrainType.BEACH, beach },
			{ TerrainType.DESERT, desert },
			{ TerrainType.MOUNTAIN, mountain },
			{ TerrainType.ICE, ice },
			{ TerrainType.WATER, ocean },
			{ TerrainType.SHALLOW_WATER, shallow },
			{ TerrainType.FOREST, forest },
		};
	}


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

		terrainImage.Texture = terrainTypeImages[h.terrainType];
		foodLabel.Text = $"Food: {h.food}";
		productionLabel.Text = $"Production: {h.production}";
		terrainLabel.Text = $"Terrain: {terrainTypeStrings[h.terrainType]}";
	}

}
