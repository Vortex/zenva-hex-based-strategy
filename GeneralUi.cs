using Godot;
using System;

public partial class GeneralUi : Panel
{

	int turns = 0;

	Label turnLabel;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		turnLabel = GetNode<Label>("TurnLabel");
		turnLabel.Text = $"Turn: {turns}";
	}

	public void IncrementTurnCounter()
	{
		turns++;
		turnLabel.Text = $"Turn: {turns}";
	}

}
