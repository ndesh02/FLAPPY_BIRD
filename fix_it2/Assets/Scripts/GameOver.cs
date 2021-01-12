using Godot;
using System;

public class GameOver : CanvasLayer
{
    PackedScene mainScene;

    public override void _Ready()
    {
        mainScene = ResourceLoader.Load<PackedScene>("res://Assets/Scenes/MainScene.tscn");
    }

    public void _on_restartButton_pressed()
    {
        GetTree().ChangeSceneTo(mainScene);
    }

    public void _on_quitButton_pressed()
    {
        GetTree().Quit();
    }


}
