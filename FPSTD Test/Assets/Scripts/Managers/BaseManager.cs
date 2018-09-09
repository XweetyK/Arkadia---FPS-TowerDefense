using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour {

	[SerializeField] private float _floorHeight;
	[SerializeField] private GameModeManager _gmManager;
	[SerializeField] private float _movingSpeed;
	private Vector3 _originalPos;
	private Vector3 _lowerPos;

	void Awake(){
		_originalPos = transform.position;
		_lowerPos=new Vector3(transform.position.x,_floorHeight,transform.position.z);
	}
	void Update(){
		switch (_gmManager.GameMode) {
		case GameModeManager.GAMEMODE.DESTROYER:
			MoveUp ();
			break;
		case GameModeManager.GAMEMODE.WALLBUILDER:
			MoveDown();
			break;
		}
	}
	public void MoveDown(){
		transform.position= Vector3.MoveTowards(transform.position,_lowerPos,_movingSpeed);
	}
	public void MoveUp(){
		transform.position= Vector3.MoveTowards(transform.position,_originalPos,_movingSpeed);
	}
}
