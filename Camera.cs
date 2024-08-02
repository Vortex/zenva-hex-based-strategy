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

    // Mouse states
    bool mouseWheelScrollingUp = false;
    bool mouseWheelScrollingDown = false;


    public override void _PhysicsProcess(double delta)
    {
        // Map controls
        if (Input.IsActionPressed("map_right"))
        {
           this.Position += new Vector2(velocity, 0);
        }

        if (Input.IsActionPressed("map_left")) {
            this.Position += new Vector2(-velocity, 0);
        }

        if (Input.IsActionPressed("map_down")) {
            this.Position += new Vector2(0, velocity);
        }

        if (Input.IsActionPressed("map_up")) {
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
