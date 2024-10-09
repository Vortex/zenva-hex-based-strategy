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
		CleanUpBorderPool();

		populationGrowthTracker += totalFood;
		if (populationGrowthTracker > populationGrowthThreshold)
		{
			population++;
			populationGrowthTracker = 0;
			populationGrowthThreshold += POPULATION_THRESHOLD_INCREASE;

			// Grow territory
			AddRandomNewTile();
			map.UpdateCivTerritoryMap(civ);
		}
	}

	public void CleanUpBorderPool()
	{
		List<Hex> toRemove = new List<Hex>();
		foreach (Hex b in borderTilePool)
		{
			if (invalidTiles.ContainsKey(b) && invalidTiles[b] != this)
			{
				toRemove.Add(b);
			}
		}

		foreach (Hex b in toRemove)
		{
			borderTilePool.Remove(b);
		}
	}

	public void AddRandomNewTile()
	{
		if (borderTilePool.Count > 0)
		{
			Random r = new Random();

			int index = r.Next(borderTilePool.Count);
			this.AddTerritory(new List<Hex> { borderTilePool[index] });

			borderTilePool.RemoveAt(index);
		}
	}

	public void AddTerritory(List<Hex> territoryToAdd)
	{
		foreach (Hex h in territoryToAdd)
		{
			h.ownerCity = this;

			// Add new border hexes to the border pool
			AddValidNeighborsToBorderPool(h);

		}
		territory.AddRange(territoryToAdd);
		CalculateTerritoryResourceTotals();
	}

	public void AddValidNeighborsToBorderPool(Hex h)
	{
		List<Hex> neighbors = map.GetSurroundingHexes(h.coordinates);

		foreach (Hex n in neighbors)
		{
			if (IsValidNeighborTile(n))
			{
				borderTilePool.Add(n);
			}

			invalidTiles[n] = this;
		}
	}

	public bool IsValidNeighborTile(Hex h)
	{
		if (h.terrainType == TerrainType.WATER ||
		h.terrainType == TerrainType.SHALLOW_WATER ||
		h.terrainType == TerrainType.ICE ||
		h.terrainType == TerrainType.MOUNTAIN)
		{
			return false;
		}

		if (h.ownerCity != null && h.ownerCity.civ != null)
		{
			return false;
		}

		if (invalidTiles.ContainsKey(h) && invalidTiles[h] != this)
		{
			return false;
		}

		return true;
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
