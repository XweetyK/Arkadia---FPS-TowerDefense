using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour {

	[SerializeField] private float _enemyHeight=0.5f;
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private int _enemiesWave1Cant = 3;
	[SerializeField] private int _enemiesWave2Cant = 5;
	[SerializeField] private int _enemiesWave3Cant = 7;
	[SerializeField] private int _enemiesWave4Cant = 10;
	private GameObject[] _enemiesWave1;
	private GameObject[] _enemiesWave2;
	private GameObject[] _enemiesWave3;
	private GameObject[] _enemiesWave4;
	void Start () {
		_enemiesWave1 = new GameObject[_enemiesWave1Cant];
		for (int i = 0; i < _enemiesWave1Cant; i++) {
			_enemiesWave1 [i] = Instantiate (_enemyPrefab);
			_enemiesWave1 [i].transform.position = new Vector3 (0 + i * 6, _enemyHeight, 100);
		}
		_enemiesWave2 = new GameObject[_enemiesWave2Cant];	
		for (int i = 0; i < _enemiesWave2Cant; i++) {
			_enemiesWave2 [i] = Instantiate (_enemyPrefab);
			_enemiesWave2 [i].transform.position = new Vector3 (0 + i * 6	, _enemyHeight, 100);
		}
		_enemiesWave3 = new GameObject[_enemiesWave3Cant];	
		for (int i = 0; i < _enemiesWave3Cant; i++) {
			_enemiesWave3 [i] = Instantiate (_enemyPrefab);
			_enemiesWave3 [i].transform.position = new Vector3 (0 + i * 6, _enemyHeight, 100);
		}
		_enemiesWave4 = new GameObject[_enemiesWave4Cant];	
		for (int i = 0; i < _enemiesWave4Cant; i++) {
			_enemiesWave4 [i] = Instantiate (_enemyPrefab);
			_enemiesWave4 [i].transform.position = new Vector3 (0 + i * 6, _enemyHeight, 100);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
