using Godot;
using System;
using System.ComponentModel;




public partial class Lizard : StaticBody2D
{

	
	//private bool candrop = true;

	private bool candrop = true;

	private LizardTail currSpawned = null;

	public double time = 0; 

	private PackedScene tail = ResourceLoader.Load<PackedScene>("res://Scenes/LizardTail/lizard_tail.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}



    public override void _UnhandledInput(InputEvent @event)
    {
        if(@event is InputEventKey keyEvent){

			
			if(keyEvent.Pressed && keyEvent.Keycode == Key.Space){
				dropTailer();

			}

		}
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

		
		float amount = 5;
		if(Input.IsKeyPressed(Key.W)){
			this.Position += new Vector2(0,-amount);
		}
		if(Input.IsKeyPressed(Key.S)){
			this.Position += new Vector2(0,amount);
		}
		if(Input.IsKeyPressed(Key.A)){
			this.Position += new Vector2(-amount,0);
		}
		if(Input.IsKeyPressed(Key.D)){
			this.Position += new Vector2(amount,0);
		}

		time = time + delta;

		if(IsInstanceValid(currSpawned) == false){

		candrop = true;

		}
		


	}
	public void dropTailer(){

		if(candrop == true){
			candrop = false;
			
		LizardTail tt = tail.Instantiate() as LizardTail;
		GetTree().Root.GetNode("World").AddChild(tt);
		tt.Position = this.Position + new Vector2(0,10);
		GD.Print("DroppedTail");

		currSpawned = tt;

		}
	}

	// public void resetDrop(double delta){

	// time = time + delta;

	// if(time > ){

	// 	candrop = true;
	// 	time = 0;
	// }

	// }
}
