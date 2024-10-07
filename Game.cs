using Godot;
using System;

public partial class Game : Node
{
    [Export]
    FastNoiseLite noise;

    public override void _EnterTree()
    {
        TerrainTileUi.LoadTerrainImages();
    }
}
