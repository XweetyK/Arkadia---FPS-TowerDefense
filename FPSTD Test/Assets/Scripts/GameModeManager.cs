using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour {

	public enum GAMEMODE{WALLBUILDER,DESTROYER};
	private GAMEMODE _gameMode;
	void Awake(){
		_gameMode = GAMEMODE.WALLBUILDER;
	}

	public GAMEMODE GameMode{
		get {return _gameMode;}
		set { _gameMode = value; }
	}
}
