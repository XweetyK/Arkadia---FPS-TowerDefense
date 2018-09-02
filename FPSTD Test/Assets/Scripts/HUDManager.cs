using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	[SerializeField] Text WallCount;
	[SerializeField] WallsManager _WManager;
	private int _Wcount;
	void Update () {
		_Wcount = _WManager.freeWallCount;
		WallCount.text = "Turrets: " + (_Wcount.ToString ());
	}
}
