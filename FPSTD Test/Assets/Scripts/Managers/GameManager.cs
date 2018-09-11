using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameModeManager _gameModeManager;
	[SerializeField] private EnemyWaveSpawner _enemyWaveSpawner;
	[SerializeField] private float _sceneDelay;
	[SerializeField] private Image _ENDGAME;
	private bool _waveActive =false;
	private GameModeManager.GAMEMODE _lastGameMode;

	void Update(){
		_waveActive = _enemyWaveSpawner.SpawnerStatus;
		switch (_gameModeManager.GameMode) {
		case GameModeManager.GAMEMODE.WALLBUILDER:
			if (Input.GetButtonDown ("Jump")) {
				_gameModeManager.GameMode = GameModeManager.GAMEMODE.DESTROYER;
				_enemyWaveSpawner.Activated ();
				Debug.Log ("Destroyer");
			}
			break;
		case GameModeManager.GAMEMODE.DESTROYER:
			if (!_waveActive) {
				_gameModeManager.GameMode = GameModeManager.GAMEMODE.WALLBUILDER;
				Debug.Log ("Wallbuilder");
			}
			break;
		case GameModeManager.GAMEMODE.GAMEWIN:
		case GameModeManager.GAMEMODE.GAMELOSE:
			Debug.Log ("CHANGESCENE");
			ChangeScene();
			_ENDGAME.color.a++;
			break;
		}
	}
	private void ChangeScene(){
		switch (_gameModeManager.GameMode) {
		case GameModeManager.GAMEMODE.GAMEWIN:
			SceneManager.LoadScene ("GAMEWIN");
			break;
		case GameModeManager.GAMEMODE.GAMELOSE:
			Debug.Log ("GAMELOSE");
			SceneManager.LoadScene ("GAMELOSE");
			break;
		}
	}
}
