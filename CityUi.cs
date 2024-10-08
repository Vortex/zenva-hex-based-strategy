using Godot;
using System;

public partial class CityUi : Panel
{

	Label cityName, population, food, production;

	// City data
	City city;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		cityName = GetNode<Label>("CityName");
		population = GetNode<Label>("Population");
		food = GetNode<Label>("Food");
		production = GetNode<Label>("Production");

	}

	public void SetCityUI(City city)
	{
		this.city = city;

		cityName.Text = city.name;
		population.Text = $"Population: {city.population}";
		food.Text = $"Food: {city.totalFood}";
		production.Text = $"Production: {city.totalProduction}";
	}
}