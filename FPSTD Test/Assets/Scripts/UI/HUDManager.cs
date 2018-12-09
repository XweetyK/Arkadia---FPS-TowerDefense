using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	[SerializeField] Text _moneyText;
	[SerializeField] Text _ammoText;
	[SerializeField] Text _guideTxt;
	[SerializeField] EnemyShooter _BManager;
	[SerializeField] GameModeManager _GmManager;
	[SerializeField] GameObject _CanvasAndroid;
	[SerializeField] GameObject _Button1WB;
	[SerializeField] GameObject _Button2WB;
	[SerializeField] GameObject _Button1DT;
	[SerializeField] GameObject _Button2DT;
	[SerializeField] GameObject _MovWB;
	[SerializeField] GameObject _Reload;
	[SerializeField] Image _ammoCounter;

	bool _isAndroid;
	private Money _money;
	private int _Wcount;
	private int _Bcount;

	void Awake(){
#if UNITY_ANDROID
	_isAndroid=true;
#else
	_isAndroid=false;
#endif

		_money = FindObjectOfType<Money> ();
	}
	void Update () {

		if (_isAndroid) {
			_CanvasAndroid.SetActive (true);
		} else {
			_CanvasAndroid.SetActive (false);
		}
		_Bcount = _BManager.BulletCont;
		_Wcount = _money.MoneyCant;
		_ammoText.text = (_Bcount.ToString ());
		_moneyText.text = "Money: " + (_Wcount.ToString ());


		switch (_GmManager.GameMode) {
		case GameModeManager.GAMEMODE.WALLBUILDER:
			if (_isAndroid) {
				_Button1WB.SetActive (true);
				_Button2WB.SetActive (true);
				_Button1DT.SetActive (false);
				_Button2DT.SetActive (false);
				_Reload.SetActive (false);
				_MovWB.SetActive (true);
				_guideTxt.text = "Start Wave";
			} else {
				_guideTxt.text = "Space: Start Wave";
			} 	
			break;
		case GameModeManager.GAMEMODE.DESTROYER:
			if (_isAndroid) {
				_Button1WB.SetActive (false);
				_Button2WB.SetActive (false);
				_Button1DT.SetActive (true);
				_Button2DT.SetActive (true);
				_Reload.SetActive (true);
				_MovWB.SetActive (false);
				_guideTxt.text = "Fight!";
			} else {
				_guideTxt.text = "Shift: Switch Base";
			}
			break;
		}

		if (_Bcount == 0){
			_ammoCounter.color = Color.red;
		}
		else if(_Bcount <= 6){
			_ammoCounter.color = Color.yellow;
		}
		else 
			_ammoCounter.color = Color.green;
	}
}
