using Chess1;
using Godot;
using System;

[Tool]
public partial class Square : ColorRect
{
	private bool _isWhite = false;

	[Export]
	public bool IsWhite { 
		get
		{
			return _isWhite; 
		}
		set
		{
			if (value)
			{
				_isWhite = true;
				Color = BoardVisuals.WhiteSquareColor;
			}
			else
			{
				_isWhite = false;
				Color = BoardVisuals.BlackSquareColor;
			}

		} 
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var config = new ConfigFile();

		// Store some values.
		config.SetValue("Player1", "player_name", "Steve");
		config.SetValue("Player1", "best_score", 10);
		config.SetValue("Player2", "player_name", "V3geta");
		config.SetValue("Player2", "best_score", 9001);

		// Save it to a file (overwrite if already exists).
		config.Save("scores.cfg");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
