using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export] public int speed = 200;
    
    public Vector2 velocity = new Vector2();
    
    //chose arbitrary temporary values for the following:
    int ceiling=50;
    int gravity=10;
    int upward_vel=20;
    int max_downward_vel=100;

    
    public void GetInput()
    {
        velocity.x+=(float)(0.1);
        velocity.y+=5;
        
        if (Input.IsActionPressed("right"))
            velocity.x += 1;

        if (Input.IsActionPressed("left"))
            velocity.x -= 1;

        if (Input.IsActionPressed("down"))
            velocity.y += 1;

        if (Input.IsActionJustPressed("up"))
            velocity.y-=200;

        velocity = velocity.Normalized() * speed;
    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        velocity = MoveAndSlide(velocity);
    }
}
