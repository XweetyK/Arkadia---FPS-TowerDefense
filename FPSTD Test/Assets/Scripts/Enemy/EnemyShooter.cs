using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

	[SerializeField] private GameObject _bullet;
	[SerializeField] private GameModeManager _GMmanager;
	[SerializeField] private int _maxBullets = 20;
	[SerializeField] private float _fireRate = 0.3f;
	private float nextFire = 0.0f;
	private int _bulletCont;
	private float _reloadTime = 3f;
	private bool _reloading = false;
	GameObject bullet;

	void Awake() {
		_bulletCont = _maxBullets;
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
	void Update () {
		if (_GMmanager.GameMode == GameModeManager.GAMEMODE.DESTROYER) {
			if (Input.GetButton ("Fire1") && _bulletCont > 0 && _reloading == false && Time.time > nextFire) {
				Shoot ();
				nextFire = Time.time + _fireRate;
			}
		}
		if(_reloading == false && _bulletCont != _maxBullets){
			if(Input.GetButtonDown("Reload")){
				Invoke ("Reload", _reloadTime);
				_reloading = true;
			}
			if(_reloading == false && _bulletCont == 0){
				Invoke ("Reload", _reloadTime);
				_reloading = true;
			}
		}	
	}
	public void Shoot(){
		bullet = Instantiate (_bullet);
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
		_bulletCont--;
	}
	public void Reload() {
		_bulletCont = _maxBullets;
		_reloading = false;
	}
	public int BulletCont{
		get{return _bulletCont;}
		set{ _bulletCont = value; }
	}
	public int maxBullets{
		get{return _maxBullets;}
		set{ _maxBullets = value;}
	}
	public float reloadTime{
		get{return _reloadTime;}
		set{ _reloadTime = value;}
	}
}
