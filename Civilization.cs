using Godot;
using System;
using System.Collections.Generic;

public partial class Civilization : Node
{
	public int id;

	public List<City> cities;

	public Color territoryColor;
	public int territoryColorAltTileId;

	public string name;

	public bool playerCiv;

	public Civilization()
	{
		cities = new List<City>();
	}

}
