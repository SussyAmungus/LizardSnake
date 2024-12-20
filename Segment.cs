using Godot;
using System;

public partial class Segment : Area2D
{

	public Vector2 lastPos;
	public float lastRot;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.TopLevel = true;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void setPos(Vector2 newpos, double delta){
		
		lastPos = this.Position;
		
	
		this.Position = this.Position.Lerp(newpos, (float)0.05);
		

	}

	public void setRot(float rad, double delta){
		
		lastRot = this.Rotation;

		this.Rotation =Mathf.LerpAngle(this.Rotation,rad, (float)1);
		
	
		//this.Position = this.Position.Lerp(newpos, (float)0.05);
		

	}
}
