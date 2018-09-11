using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
	[SerializeField] private GameObject _fortress;
	[SerializeField] private int _damage;
	[SerializeField] private GameModeManager _gmManager;
	private Life _lifeManager;

	void Start(){
		_lifeManager = _fortress.GetComponent<Life> ();
	}
	void Update(){
		if (_lifeManager.LifeGetter<=0) {
			Debug.Log ("LIFEUPDATER");
			_gmManager.GameMode = GameModeManager.GAMEMODE.GAMELOSE;
		}
	}
	void OnTriggerEnter(Collider enemy){
		enemy.GetComponent<EnemyWalker> ().Destroyer ();
		_lifeManager.LifeGetter -= _damage;
	}
}
