using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

	[SerializeField] private GameModeManager _GMmanager;
	[SerializeField] private int _maxBullets = 20;
	[SerializeField] private float _fireRate = 0.3f;
	[SerializeField] private Gun _weapon;
	[SerializeField] Transform originalPos;
	[SerializeField] Transform reloadingPos;
	private float nextFire = 0.0f;
	private int _bulletCont;
	private bool _reloading = false;
	private bool input;
	void Start() {
		updateStats ();
	}

	void OnEnable()
	{
		GameManager.GetInstance ().AddListener (OnWaveStartEvent, GameManager.GameEvent.WaveStart);
	}

	void OnDisable()
	{
		if (GameManager.GetInstance ()) {
			GameManager.GetInstance ().RemoveListener (OnWaveStartEvent, GameManager.GameEvent.WaveStart);
		}
	}

	void OnWaveStartEvent(GameManager.GameEvent evt)
	{
		Reload ();
		Debug.Log ("OnWave Start");
	}

	void OnStart(){
		_fireRate = _weapon.fireRate;
	}
	void Update () {
		if (_GMmanager.GameMode == GameModeManager.GAMEMODE.DESTROYER) {
			if (_weapon.automatic) {
				input = InputManager.Instance.GetFire1Button();
			} else
				input = InputManager.Instance.GetFire1Button();
			if (input && _bulletCont > 0 && _reloading == false && Time.time > nextFire) {
				Shoot ();
				nextFire = Time.time + _fireRate;
			}
		}
		if(_reloading == false && _bulletCont != _maxBullets){
			if(InputManager.Instance.GetFire2Button()){
				Invoke ("Reload", _weapon.reloadTime);
				_reloading = true;
				_weapon.gameObject.transform.position = Vector3.MoveTowards (_weapon.gameObject.transform.position, reloadingPos.position,0.5f);
			}
			if(_reloading == false && _bulletCont == 0){
				Invoke ("Reload", _weapon.reloadTime);
				_reloading = true;
				_weapon.gameObject.transform.position = Vector3.MoveTowards (_weapon.gameObject.transform.position, reloadingPos.position,0.5f);
			}
		}	
	}
	public void updateStats(){
		_fireRate = _weapon.fireRate;
		_maxBullets = _weapon.magSize;
	}
	public void Shoot(){
		_weapon.shoot ();
		_bulletCont--;
	}
	public void Reload() {
		_bulletCont = _maxBullets;
		_reloading = false;
		_weapon.gameObject.transform.position = Vector3.MoveTowards (_weapon.gameObject.transform.position, originalPos.position,0.5f);
	}
	public int BulletCont{
		get{return _bulletCont;}
		set{ _bulletCont = value; }
	}
	public int maxBullets{
		get{return _maxBullets;}
		set{ _maxBullets = value;}
	}
}
