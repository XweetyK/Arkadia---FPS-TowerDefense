using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	[SerializeField] Text _text;
	[SerializeField] EnemyShooter _BManager;
	[SerializeField] GameModeManager _GmManager;
	private Money _money;
	private int _Wcount;
	private int _Bcount;
	void Awake(){
		_money = FindObjectOfType<Money> ();
	}
	void Update () {
		switch (_GmManager.GameMode) {
		case GameModeManager.GAMEMODE.WALLBUILDER:
			_Wcount = _money.MoneyCant;
			_text.text = "Money: " + (_Wcount.ToString ());
			break;
		case GameModeManager.GAMEMODE.DESTROYER:
			_Bcount = _BManager.BulletCont;
			_text.text = "Bullets: " + (_Bcount.ToString ());
			break;
		}
	}
}
