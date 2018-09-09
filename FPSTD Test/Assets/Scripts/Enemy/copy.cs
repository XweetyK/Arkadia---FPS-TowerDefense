/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaveSpawner : MonoBehaviour {

	[SerializeField] private float _enemyHeight=0.5f;
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private int _enemiesWave1Cant = 3;
	[SerializeField] private int _enemiesWave2Cant = 5;
	[SerializeField] private int _enemiesWave3Cant = 7;
	[SerializeField] private int _enemiesWave4Cant = 10;
	[SerializeField] GameModeManager _manager;
	[SerializeField] Transform _spawnTarget;
	private GameObject[] _enemiesWave1;
	private GameObject[] _enemiesWave2;
	private GameObject[] _enemiesWave3;
	private GameObject[] _enemiesWave4;
	private int _actualWave;

	void Start () {
		_actualWave = 0;
		_enemiesWave1 = new GameObject[_enemiesWave1Cant];
		for (int i = 0; i < _enemiesWave1Cant; i++) {
			_enemiesWave1 [i] = Instantiate (_enemyPrefab);
			_enemiesWave1 [i].GetComponent<NavMeshAgent>().Warp(new Vector3 (0 + i * 2, _enemyHeight, 102));
		}
		_enemiesWave2 = new GameObject[_enemiesWave2Cant];	
		for (int i = 0; i < _enemiesWave2Cant; i++) {
			_enemiesWave2 [i] = Instantiate (_enemyPrefab);
			_enemiesWave2 [i].GetComponent<NavMeshAgent>().Warp(new Vector3 (0 + i * 2, _enemyHeight, 104));
		}
		_enemiesWave3 = new GameObject[_enemiesWave3Cant];	
		for (int i = 0; i < _enemiesWave3Cant; i++) {
			_enemiesWave3 [i] = Instantiate (_enemyPrefab);
			_enemiesWave3 [i].GetComponent<NavMeshAgent>().Warp(new Vector3 (0 + i * 2, _enemyHeight, 106));
		}
		_enemiesWave4 = new GameObject[_enemiesWave4Cant];	
		for (int i = 0; i < _enemiesWave4Cant; i++) {
			_enemiesWave4 [i] = Instantiate (_enemyPrefab);
			_enemiesWave4 [i].GetComponent<NavMeshAgent>().Warp(new Vector3 (0 + i * 2, _enemyHeight, 108));
		}
	}
	void Update(){
		if (_manager.GameMode == GameModeManager.GAMEMODE.DESTROYER) {
			Invoke ("Spawner", 0.5f);
		}
	}
	private void Spawner(){
		switch (_actualWave) {
		case 0:
			for (int i = 0; i < _enemiesWave1Cant; i++) {
				_enemiesWave1 [i].GetComponent<NavMeshAgent> ().Warp (_spawnTarget.position);
				_enemiesWave1 [i].GetComponent<EnemyWalker> ().Walk ();
			}
			break;
		case 1:
			for (int i = 0; i < _enemiesWave2Cant; i++) {
				_enemiesWave2 [i].GetComponent<NavMeshAgent>().Warp(_spawnTarget.position);
				_enemiesWave2 [i].GetComponent<EnemyWalker> ().Walk ();
			}
			break;
		case 2:
			for (int i = 0; i < _enemiesWave3Cant; i++) {
				_enemiesWave3 [i].GetComponent<NavMeshAgent>().Warp(_spawnTarget.position);
				_enemiesWave3 [i].GetComponent<EnemyWalker> ().Walk ();
			}
			break;
		case 3:
			for (int i = 0; i < _enemiesWave4Cant; i++) {
				_enemiesWave4 [i].GetComponent<NavMeshAgent>().Warp(_spawnTarget.position);
				_enemiesWave4 [i].GetComponent<EnemyWalker> ().Walk ();
			}
			break;
		}
	}
	public int Wave{
		get{ return _actualWave; }
		set{ _actualWave = value; }
	}
}*/