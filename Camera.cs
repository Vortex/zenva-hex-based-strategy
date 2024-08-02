using Godot;
using System;

public partial class Camera : Camera2D
{
    [Export]
    int velocity = 15;

    [Export]
    float zoomSpeed = 0.05f;

    [Export]
    float maxZoom = 3f;

    [Export]
    float minZoom = 0.1f;



    // Map boundaries
    float leftBound, rightBound, topBound, bottomBound;

    // Map reference
    HexTileMap map;

    // Mouse states
    bool mouseWheelScrollingUp = false;
    bool mouseWheelScrollingDown = false;

    public override void _Ready()
    {
        map = GetNode<HexTileMap>("../HexTileMap");

        // Set map boundaries
        leftBound = ToGlobal(map.MapToLocal(new Vector2I(0, 0))).X + 100;
        rightBound = ToGlobal(map.MapToLocal(new Vector2I(map.width, 0))).X - 100;
        topBound = ToGlobal(map.MapToLocal(new Vector2I(0, 0))).Y + 50;
        bottomBound = ToGlobal(map.MapToLocal(new Vector2I(0, map.height))).Y - 50;
    }


    public override void _PhysicsProcess(double delta)    
    {
        // Map controls
        if (Input.IsActionPressed("map_right") && this.Position.X < rightBound)
        {
           this.Position += new Vector2(velocity, 0);
        }

        if (Input.IsActionPressed("map_left") && this.Position.X > leftBound) {
            this.Position += new Vector2(-velocity, 0);
        }

        if (Input.IsActionPressed("map_down") && this.Position.Y < bottomBound) {
            this.Position += new Vector2(0, velocity);
        }

        if (Input.IsActionPressed("map_up") && this.Position.Y > topBound) {
            this.Position += new Vector2(0, -velocity);
        }

        // Zoom controls
        if (Input.IsActionPressed("map_zoom_in") || mouseWheelScrollingUp) {
            if (this.Zoom < new Vector2(maxZoom, maxZoom))
                this.Zoom += new Vector2(zoomSpeed, zoomSpeed);
        }

        if (Input.IsActionPressed("map_zoom_out") || mouseWheelScrollingDown) {
            if (this.Zoom > new Vector2(minZoom, minZoom))
                this.Zoom -= new Vector2(zoomSpeed, zoomSpeed);
        }

        if (Input.IsActionJustReleased("mouse_zoom_in"))
            mouseWheelScrollingUp = true;

        if (!Input.IsActionJustReleased("mouse_zoom_in"))
            mouseWheelScrollingUp = false;

        if (Input.IsActionJustReleased("mouse_zoom_out"))
            mouseWheelScrollingDown = true;

        if (!Input.IsActionJustReleased("mouse_zoom_out"))
            mouseWheelScrollingDown = false;
    }
}
