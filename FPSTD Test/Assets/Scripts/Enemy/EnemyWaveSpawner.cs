using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWaveSpawner : MonoBehaviour {

	[SerializeField] private float _enemyHeight=0.5f;
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private Transform[] _spawnTarget;
	[SerializeField] GameModeManager _manager;
	[SerializeField] int [] _enemyWavesCant;
	[SerializeField] float _spawnerDelay;
	[SerializeField] bool _multiPath;
	private GameObject[][] _enemyWave;
	private int _actualWave=-1;
	private int _waveCant;
	private bool _activeSpawner=false;
	private int _waveChecker;
	private int _rand;

	void Start(){
		_enemyWave = new GameObject[_enemyWavesCant.Length][];
		for (int i = 0; i < _enemyWavesCant.Length; i++) {
			_enemyWave [i] = new GameObject[_enemyWavesCant [i]];
			for (int j = 0; j < _enemyWavesCant[i]; j++) {
				_enemyWave [i] [j] = Instantiate (_enemyPrefab);
				_enemyWave [i] [j].GetComponent<NavMeshAgent>().Warp(new Vector3 (0 + j * 2, _enemyHeight, 102+i*2));
			}
		}
	}
	void Update(){
		_rand = Random.Range (0, _spawnTarget.Length) == 0 ? 0 : _spawnTarget.Length-1;
		if (_actualWave >= 0 && _actualWave < _enemyWave.Length) {
			_waveChecker = 0;
			for (int i = 0; i < _enemyWave[_actualWave].Length; i++) {
				if (_enemyWave [_actualWave] [i] == null) {
					_waveChecker++;
				}
			}
			if (_waveChecker == _enemyWave [_actualWave].Length) {
				_activeSpawner = false;
				if (_actualWave == _enemyWave.Length -1) {
					Debug.Log ("GameWinFromEnemy");
					_manager.GameMode = GameModeManager.GAMEMODE.GAMEWIN;
				}
			}
		}


	}
	public void Activated(){
		_activeSpawner = true;
		_waveCant = 0;
		_actualWave++;
		Invoke ("Spawner", _spawnerDelay);
	}
	private void Spawner(){
		if (_actualWave < _enemyWave.Length) {
			if (_waveCant != _enemyWave [_actualWave].Length) {
				if (_multiPath) {
					_enemyWave [_actualWave] [_waveCant].GetComponent<NavMeshAgent> ().Warp (_spawnTarget[_rand].position);
				} else {
					_enemyWave [_actualWave] [_waveCant].GetComponent<NavMeshAgent> ().Warp (_spawnTarget[0].position);
				}
				_enemyWave [_actualWave] [_waveCant].GetComponent<EnemyWalker> ().Walk (_multiPath);
				_waveCant++;
				Invoke ("Spawner", _spawnerDelay);

			}
		} else {
			_activeSpawner = false;
		}
	}
	public bool SpawnerStatus{
		get{ return _activeSpawner; }
	}
}