using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	[SerializeField] Text _text;
	[SerializeField] Text _guideTxt;
	[SerializeField] EnemyShooter _BManager;
	[SerializeField] GameModeManager _GmManager;
	[SerializeField] GameObject _CanvasAndroid;
	[SerializeField] GameObject _Button1WB;
	[SerializeField] GameObject _Button2WB;
	[SerializeField] GameObject _Button3WB;
	[SerializeField] GameObject _Button1DT;
	[SerializeField] GameObject _Button2DT;
	[SerializeField] GameObject _Button3DT;

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
		switch (_GmManager.GameMode) {
		case GameModeManager.GAMEMODE.WALLBUILDER:
			if (_isAndroid) {
				_Button1WB.SetActive (true);
				_Button2WB.SetActive (true);
				_Button3WB.SetActive (true);
				_Button1DT.SetActive (false);
				_Button2DT.SetActive (false);
				_Button3DT.SetActive (false);
				_guideTxt.text = "Start Wave";
			} else {
				_guideTxt.text = "Space: Start Wave";
			}
			_Wcount = _money.MoneyCant;
			_text.text = "Money: " + (_Wcount.ToString ());
			break;
		case GameModeManager.GAMEMODE.DESTROYER:
			if (_isAndroid) {
				_Button1WB.SetActive (false);
				_Button2WB.SetActive (false);
				_Button3WB.SetActive (false);
				_Button1DT.SetActive (true);
				_Button2DT.SetActive (true);
				_Button3DT.SetActive (true);
				_guideTxt.text = "Reload";
			}
			else {
				_guideTxt.text = "Shift: Switch Base";
			}
			_Bcount = _BManager.BulletCont;
			_text.text = "Bullets: " + (_Bcount.ToString ());
			break;
		}
	}
}
