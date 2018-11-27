using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public enum GameEvent
	{
		WaveEnd,
		WaveStart,

	}

	public delegate void OnEventDlg(GameEvent evt);

	[SerializeField] private GameModeManager _gameModeManager;
	[SerializeField] private EnemyWaveSpawner _enemyWaveSpawner;
	[SerializeField] private float _sceneDelay;
	[SerializeField] private Image _ENDGAME;
	[SerializeField] Text _waveTextW;
	[SerializeField] Text _waveTextB;

	private bool _waveStart;
	private bool _waveActive =false;
	private int _waveNum;
	private GameModeManager.GAMEMODE _lastGameMode;
	private SceneChange _scene;

	private Dictionary<GameEvent, List<OnEventDlg>> listeners = new Dictionary<GameEvent,List<OnEventDlg>> ();

	private static GameManager instance = null;

	public static GameManager GetInstance()
	{
		if (instance == null)
			instance = FindObjectOfType<GameManager> ();

		return instance;
	}

	void Awake()
	{
		if (instance)
			Destroy (this.gameObject);
		else
			instance = this;

		_waveStart = false;
		_waveNum = 0;
		_scene = FindObjectOfType<SceneChange> ();

	}

	void OnDisable()
	{
		instance = null;
	}

	public void AddListener (OnEventDlg callback, GameEvent evt)
	{
		if (!listeners.ContainsKey (evt))
			listeners [evt] = new List<OnEventDlg> ();

		listeners [evt].Add (callback);
	}

	public void RemoveListener (OnEventDlg callback, GameEvent evt)
	{
		if (listeners.ContainsKey (evt)) {
			listeners [evt].Remove(callback);
		}
	}

	private void CallListeners(GameEvent evt)
	{
		if (listeners.ContainsKey (evt)) {
			foreach (OnEventDlg callback in listeners[evt]) {
				callback (evt);
			}
		}
	}

	void Update(){
		_waveActive = _enemyWaveSpawner.SpawnerStatus;
		switch (_gameModeManager.GameMode) {
		case GameModeManager.GAMEMODE.WALLBUILDER:
			if (InputManager.Instance.GetJumpButton()) {
				_gameModeManager.GameMode = GameModeManager.GAMEMODE.DESTROYER;
				_enemyWaveSpawner.Activated ();
				_waveStart = true;
				TextChange ();
				CallListeners (GameEvent.WaveStart);
				Debug.Log ("Destroyer");
			}
			break;
		case GameModeManager.GAMEMODE.DESTROYER:
			if (!_waveActive) {
				_gameModeManager.GameMode = GameModeManager.GAMEMODE.WALLBUILDER;
				CallListeners (GameEvent.WaveEnd);
				Debug.Log ("Wallbuilder");
			}
			break;
		case GameModeManager.GAMEMODE.GAMEWIN:
		case GameModeManager.GAMEMODE.GAMELOSE:
			Debug.Log ("CHANGESCENE");
			ChangeScene();
			//_ENDGAME.color.a++;
			break;
		}
		if (Input.GetButtonDown ("Cancel")) {
			_scene.MainMenu ();
		}
	}
	private void ChangeScene(){
		switch (_gameModeManager.GameMode) {
		case GameModeManager.GAMEMODE.GAMEWIN:
			_scene.Win ();
			break;
		case GameModeManager.GAMEMODE.GAMELOSE:
			_scene.Lose ();
			break;
		}
	}
	private void TextChange(){
		if (_waveStart) {
			_waveNum++;
			_waveTextW.text = "Wave: " + (_waveNum.ToString ());
			_waveTextB.text = "Wave: " + (_waveNum.ToString ());
			_waveStart = false;
			Invoke ("TextChange", 1.0f);
		} else {
			_waveTextW.text = " ";
			_waveTextB.text = " ";
		}
	}
}
