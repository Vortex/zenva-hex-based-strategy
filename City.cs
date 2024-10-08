using Godot;
using System;
using System.Collections.Generic;

public partial class City : Node2D
{

	public static Dictionary<Hex, City> invalidTiles = new Dictionary<Hex, City>();

	public HexTileMap map;
	public Vector2I centerCoordinates;

	public List<Hex> territory;
	public List<Hex> borderTilePool;

	public Civilization civ;

	// Gameplay constant
	public static int POPULATION_THRESHOLD_INCREASE = 15;

	// City name
	public string name;

	// Population
	public int population = 1;
	public int populationGrowthThreshold;
	public int populationGrowthTracker;

	// Resources
	public int totalFood;
	public int totalProduction;


	// Scene nodes
	Label label;
	Sprite2D sprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		label = GetNode<Label>("Label");
		sprite = GetNode<Sprite2D>("Sprite");

		territory = new List<Hex>();
		borderTilePool = new List<Hex>();
	}

	public void ProcessTurn()
	{
		populationGrowthTracker += totalFood;
		if (populationGrowthTracker > populationGrowthThreshold)
		{
			population++;
			populationGrowthTracker = 0;
			populationGrowthThreshold += POPULATION_THRESHOLD_INCREASE;

			// Grow territory

		}
	}

	public void AddTerritory(List<Hex> territoryToAdd)
	{
		foreach (Hex h in territoryToAdd)
		{
			h.ownerCity = this;
		}
		territory.AddRange(territoryToAdd);
		CalculateTerritoryResourceTotals();
	}

	public void CalculateTerritoryResourceTotals()
	{
		totalFood = 0;
		totalProduction = 0;

		foreach (Hex h in territory)
		{
			totalFood += h.food;
			totalProduction += h.production;
		}
	}

	public void SetCityName(string newName)
	{
		name = newName;
		label.Text = newName;
	}

	public void SetIconColor(Color c)
	{
		sprite.Modulate = c;
	}

}
