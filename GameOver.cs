using Godot;
using System;

public class GameOver : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode("RestartButton").Connect("pressed", this, nameof(_OnRestartPressed));
    }

    public void _OnRestartPressed()
    {
        GetTree().ChangeScene("res://MainScene.tscn");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
