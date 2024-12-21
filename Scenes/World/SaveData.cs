using Godot;
using Godot.Collections;
using System.IO;
using System;

public partial class SaveData : Node
{
	// Called when the node enters the scene tree for the first time.
private string pather;
	
Godot.Collections.Dictionary loadedDataDict;
	
	public override void _Ready()
	{

		pather = ProjectSettings.GlobalizePath("user://");
		//Godot.Collections.Dictionary data = new Godot.Collections.Dictionary();

		//data.Add("highscore", 0);

		//string json = Json.Stringify(data);

		if(!Directory.Exists(pather)){
			GD.Print("Allready had this data json");
			Directory.CreateDirectory(pather);

		Godot.Collections.Dictionary data = new Godot.Collections.Dictionary();

		data.Add("highscore", 0);

		string json = Json.Stringify(data);

		SaveTextToFile(pather, "SaveGame.json", json);
		}

	


		string loadedData = LoadTextFromFile(pather, "SaveGame.json");

	
		Json jsonLoader = new Json();

		Error error = jsonLoader.Parse(loadedData);

		if(error != Error.Ok){

			GD.Print(error);
			return;
		}


		//this is the dictionary that we can use
		loadedDataDict = (Godot.Collections.Dictionary)jsonLoader.Data;

	}

	public void RestartGame(){

	}

	public void FlySave(){
	
		string json = Json.Stringify(loadedDataDict);

		GD.Print("Trying to save this file" + json);

		SaveTextToFile(pather, "SaveGame.json",json);

	}

	public double getHighscore(){

		GD.Print("GETTING HIGHEST SCORE" + loadedDataDict["highscore"].AsDouble());
		return loadedDataDict["highscore"].AsDouble();

	}

	public void setHighscore(double num){

		loadedDataDict["highscore"] = num;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private string LoadTextFromFile(string path, string fileName){
		string data = null;
		path = Path.Join(path, fileName);
		if(!File.Exists(path))return null;

		try{

			data = File.ReadAllText(path);
			GD.Print(data);
		}catch (System.Exception e){

			GD.Print(e);
		}

		return data;
	}


	private void SaveTextToFile(string path, string fileName, string data){


		//Code redundent NGL (look at start)
		if(!Directory.Exists(path)){
			GD.Print("Allready had this data json");
			Directory.CreateDirectory(path);

		}
		
		path = Path.Join(path, fileName);

		try{
		//this is the offical code to save the stringed json to the file
			File.WriteAllText(path, data);
			GD.Print(data);
		}catch (System.Exception e){

			GD.Print(e);
		}




	}


	
}
