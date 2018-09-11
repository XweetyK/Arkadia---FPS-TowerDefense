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

	void Update(){
		if (_gameModeManager.GameMode != GameModeManager.GAMEMODE.GAMELOSE || _gameModeManager.GameMode != GameModeManager.GAMEMODE.GAMEWIN) {
			_waveActive = _enemyWaveSpawner.SpawnerStatus;
			if (!_waveActive) {
				_gameModeManager.GameMode = GameModeManager.GAMEMODE.WALLBUILDER;
				if (Input.GetButtonDown ("Jump")) {
					_gameModeManager.GameMode = GameModeManager.GAMEMODE.DESTROYER;
					_enemyWaveSpawner.Activated ();
					if (_gameModeManager.GameMode == GameModeManager.GAMEMODE.GAMELOSE || _gameModeManager.GameMode != GameModeManager.GAMEMODE.GAMEWIN) {
						Debug.Log ("CHANGESCENE");
						Invoke ("ChangeScene", _sceneDelay);
						_ENDGAME.color.a++;
					}
				}
			}
		} else {
			Debug.Log ("INVOKE");
			Invoke ("ChangeScene", _sceneDelay);
			_ENDGAME.color.a++;
		}
		Debug.Log (_gameModeManager.GameMode);
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
