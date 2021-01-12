using Godot;
using System;

public class PipeSpawner : Node2D
{
    private PackedScene pipeTop = ResourceLoader.Load("res://Assets/Obstacles/BodyTop.tscn") as PackedScene;
    private PackedScene pipeBottom = ResourceLoader.Load("res://Assets/Obstacles/BodyBottom.tscn") as PackedScene;
    [Export] NodePath spawnLocationPath;
    Node spawnLocation;
    [Export] int screenHeight;
    [Export] int screenWidth;
    [Export] int minimumShown;
    [Export] int verticalPipeDistance;
    [Export] float distanceBetweenPipes;
    private float pipeDistanceIteration = 0;
    private float topPipeHeight;
    private float bottomPipeHeight;
    

    public override void _Ready()
    {
        spawnLocation = GetNode<Node>(spawnLocationPath);
    }

    private void _on_PipeSpawnTimer_timeout()
    {
        float randomHeight = getRandomHeight();

        spawnNextBottom(randomHeight);
        spawnNextTop(randomHeight);
    }

    public float getRandomHeight()
    {
        int minHeight = minimumShown + verticalPipeDistance;
        int maxHeight = screenHeight - minimumShown;

        float randomHeight = new Random().Next(minHeight, maxHeight);

        //GD.Print("Min: " + minHeight + " Max: " + maxHeight);

        return randomHeight;
    }

    public void spawnNextTop(float randomHeight)
    {
        float newHeight = randomHeight - verticalPipeDistance;
        StaticBody2D newTop = pipeTop.Instance() as StaticBody2D;
        newTop.Position = new Vector2(pipeDistanceIteration, newHeight);
        spawnLocation.AddChild(newTop);


        pipeDistanceIteration += distanceBetweenPipes;

        //GD.Print(newTop.Position.x + " " + newTop.Position.y);
    }

    public void spawnNextBottom(float randomHeight)
    {
        StaticBody2D newBottom = pipeBottom.Instance() as StaticBody2D;
        newBottom.Position = new Vector2(pipeDistanceIteration, randomHeight);
        spawnLocation.AddChild(newBottom);

        //GD.Print(newBottom.Position.x + " " + newBottom.Position.y);
    }
}
