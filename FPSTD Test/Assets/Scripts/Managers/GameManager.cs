using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameModeManager _gameModeManager;
	[SerializeField] private EnemyWaveSpawner _enemyWaveSpawner;
	private bool _waveActive =false;

	void Update(){
		_waveActive = _enemyWaveSpawner.SpawnerStatus;
		if (!_waveActive) {
			_gameModeManager.GameMode = GameModeManager.GAMEMODE.WALLBUILDER;
			if (Input.GetButtonDown("Jump")) {
				_gameModeManager.GameMode = GameModeManager.GAMEMODE.DESTROYER;
				_enemyWaveSpawner.Activated ();
			}
		}
	}
}
