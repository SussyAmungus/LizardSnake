using Godot;
using System;
using System.IO;

public partial class World : Node2D
{

	
	// Called when the node enters the scene tree for the first time.
	Timer timer;
	public RichTextLabel RT;
	public RichTextLabel RT2;

public float time = 0;
	public int Seconds = 0;
	public int MiliSeconds = 0;
	public double highestScore = 0.00;
	public override void _Ready()
	{
 	
		RT = GetNode<Control>("Control").GetNode<RichTextLabel>("RichTextLabel");
		RT2 = GetNode<Control>("Control").GetNode<RichTextLabel>("RichTextLabel2");
	


	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		time = time + ((float)delta);
	
		String e = String.Format("Time: {0:f2}", double.Parse(time.ToString()));
		GD.Print(e);
		RT.Text = (e);
		RT2.Text = String.Format("Highscore: {0:f2}",highestScore);

		if(time >= highestScore){

			highestScore = time;
		}
	}
}
