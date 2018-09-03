using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	[SerializeField] Text _text;
	[SerializeField] WallsManager _WManager;
	[SerializeField] EnemyShooter _BManager;
	[SerializeField] GameModeManager _GmManager;
	private int _Wcount;
	private int _Bcount;
	void Update () {
		switch (_GmManager.GameMode) {
		case GameModeManager.GAMEMODE.WALLBUILDER:
			_Wcount = _WManager.freeWallCount;
			_text.text = "Turrets: " + (_Wcount.ToString ());
			break;
		case GameModeManager.GAMEMODE.DESTROYER:
			_Bcount = _BManager.BulletCont;
			_text.text = "Bullets: " + (_Bcount.ToString ());
			break;
		}
	}
}
