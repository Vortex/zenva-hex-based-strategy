using Godot;
using System;
using System.Collections.Generic;

public enum TerrainType
{
    PLAINS, WATER, DESERT, MOUNTAIN, ICE, SHALLOW_WATER, FOREST, BEACH
}

public class Hex {
    public readonly Vector2I coordinates;
    public TerrainType terrainType;

    public Hex(Vector2I coordinates)
    {
        this.coordinates = coordinates;
    }
} 

public partial class HexTileMap : Node2D
{
    [Export]
    public int width = 100;

    [Export]
    public int height = 60;

    // Map data
    TileMapLayer baseLayer, borderLayer, overlayLayer;

    Dictionary<Vector2I, Hex> mapData;
    Dictionary<TerrainType, Vector2I> terrainTextures;
   

    public override void _Ready()
    {
        baseLayer = GetNode<TileMapLayer>("BaseLayer");
        borderLayer = GetNode<TileMapLayer>("HexBordersLayer");
        overlayLayer = GetNode<TileMapLayer>("SelectionOverlay");

        // Initialize map data
        mapData = new Dictionary<Vector2I, Hex>();
        terrainTextures = new Dictionary<TerrainType, Vector2I>
        {
            { TerrainType.PLAINS, new Vector2I(0, 0) },
            { TerrainType.WATER, new Vector2I(1, 0)},
            { TerrainType.DESERT, new Vector2I(0, 1)},
            { TerrainType.MOUNTAIN, new Vector2I(1, 1)},
            { TerrainType.SHALLOW_WATER, new Vector2I(1, 2)},
            { TerrainType.BEACH, new Vector2I(0, 2)},
            { TerrainType.FOREST, new Vector2I(1, 3)},
            { TerrainType.ICE, new Vector2I(0, 3)},
        };

        GenerateTerrain();
    }

    public void GenerateTerrain()
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                baseLayer.SetCell(new Vector2I(x, y), 0, new Vector2I(0, 0));
                borderLayer.SetCell(new Vector2I(x, y), 2, new Vector2I(0, 0));
            }
        }
    }

    public Vector2 MapToLocal(Vector2I coords)
    {
        return baseLayer.MapToLocal(coords);
    }
}
