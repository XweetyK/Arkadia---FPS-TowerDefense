using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsManager : MonoBehaviour {

	[SerializeField] private int _MaxTurrets;
	[SerializeField] private float wallHeight=0.5f;
	[SerializeField] private GameObject wallPrefab;
	[SerializeField] private EnemyWaveSpawner _WaveManager;
	private GameObject[] walls;
	private GameObject waveManager;
	private Money _money;

	void Awake(){
		_money = FindObjectOfType<Money> ();
	}

	void Start () {
		walls= new GameObject[_MaxTurrets];
		for (int i = 0; i < _MaxTurrets; i++) {
			walls [i] = Instantiate (wallPrefab);
			walls [i].transform.position = new Vector3 (0+ i * 2, wallHeight, 100);
			walls [i].GetComponent<WallClass> ().OriginalPos = walls [i].transform.position;
		}
	}
		

	void OnEnable()
	{
		GameManager.GetInstance ().AddListener (OnWaveEndEvent, GameManager.GameEvent.WaveEnd);
	}

	void OnDisable()
	{
		if (GameManager.GetInstance ()) {
			GameManager.GetInstance ().RemoveListener (OnWaveEndEvent, GameManager.GameEvent.WaveEnd);
		}
	}


	void OnWaveEndEvent(GameManager.GameEvent evt)
	{
		if (_MaxTurrets > 0 && walls [walls.Length - 1].GetComponent<WallClass> ().Placed == false) {
			_money.MoneySum (100);
		}
	}
	public GameObject FreeCheck(){
		for (int i = 0; i < _MaxTurrets; i++) {
			if (walls [i].GetComponent<WallClass> ().Placed == false) {
				walls [i].GetComponent<WallClass> ().Placed = true;
				_money.MoneyDisc (100);
				return walls [i];
			}
		}
		return null;
	}
	public void ReturnWall (GameObject returned){
		for (int i = 0; i < _MaxTurrets; i++) {
			if (walls [i] == returned) {
				walls [i].transform.position = walls [i].GetComponent<WallClass> ().OriginalPos;
				walls [i].GetComponent<WallClass> ().Placed = false;
				_money.MoneySum (100);
			}
		}
	}
}
