
using Godot;
using System.Collections.Generic;
using System;



public partial class snake : StaticBody2D
{

	private Vector2 Move = Vector2.Zero;

	private int moveDir = 0;

	public float speedS = (float) 3;

	public Lizard plr;

	private float rotSpeed = 2;

	private ShapeCast2D shapecast;

	private Vector2 target;

	[Export(PropertyHint.Layers2DPhysics)] public uint CameraColliderLayer;

	public List<Segment> myList = new List<Segment>();

	private PackedScene Seg = ResourceLoader.Load<PackedScene>("res://Scenes/Snake/Segment.tscn");

	private Vector2 lastHeadPos;
	public float lastHeadRot;

	[Signal]
	public delegate void RestartGameEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
			
		plr = GetTree().Root.GetNode("World").GetNode<Lizard>("Lizard2D");
		shapecast = this.GetNode<ShapeCast2D>("ShapeCast2D");

		GetNode<Area2D>("Area2D").Connect("area_entered", new Callable(this, "react"));

		

		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();
		addSegment();


	}

	public void addSegment(){

		Segment s = Seg.Instantiate() as Segment;
		this.AddChild(s);
		myList.Add(s);

	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		handleMove(delta);
		moveSegments(delta);//ALWAYS HAVE THIS AFTER HANDLE MOVE
		findTarget(delta);

	
		//speedS = (float)(speedS + delta * 0.1);
	
		
	}

	
	public void moveSegments(double delta){

		myList[0].setPos(lastHeadPos, delta);
		myList[0].setRot(lastHeadRot,delta);
		
		


		for(int i = 1; i < myList.Count; i++){
			myList[i].setPos(myList[i-1].lastPos, delta);
			myList[i].setRot(myList[i-1].lastRot,delta);
		}

	}


	private void handleMove(double delta){
	lastHeadPos = this.Position;
	lastHeadRot = this.Rotation;
	
		Vector2 between = target - this.Position;
		
		this.Position = this.Position + between.Normalized() * speedS;

		
		float rad = between.Angle();
		

		this.Rotation = Mathf.LerpAngle(this.Rotation, rad, (float) 0.02 );
	
	}

	private void findTarget(double delta){

		bool targetfound = false;

		if(shapecast.IsColliding()){

			Node2D collider = (Node2D)shapecast.GetCollider(0);
			
			if(collider is LizardTail){
				
				target = collider.Position;
				targetfound = true;
			}

		}


		if(targetfound == false){

			target = plr.Position;
		
		}
		
		
	}

	 private void react(Area2D area)
    {
        if(area.GetParent() is LizardTail){

			area.GetParent<LizardTail>().Destroy();
			speedS = (float)(speedS + 0.5);
		}
		if(area.GetParent() is Lizard){

			EmitSignal(SignalName.RestartGame);	
			//..//this.Position = new Vector2(0,0);
		}
    }




}
