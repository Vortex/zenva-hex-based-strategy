using Godot;
using System;

public partial class TerrainTileUi : Panel
{
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
	}

}
