using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

	[SerializeField] private GameModeManager _GMmanager;
	[SerializeField] private int _maxBullets = 20;
	[SerializeField] private float _fireRate = 0.3f;
	[SerializeField] private Gun _weapon;
	[SerializeField] private GameObject _ammoDisplay;
	[SerializeField] Transform originalPos;
	[SerializeField] Transform reloadingPos;
	private AudioSource _reloadSound;
	private float nextFire = 0.0f;
	private int _bulletCont;
	private bool _reloading = false;
	private bool input;
	void Start() {
		updateStats ();
		_reloadSound = GetComponent<AudioSource> ();
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
		_bulletCont = _maxBullets;
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
				_reloadSound.Play ();
			}
			Debug.Log (_bulletCont);
			if(_reloading == false && _bulletCont == 0){
				Debug.Log ("0 bullets reload");
				Invoke ("Reload", _weapon.reloadTime);
				_reloading = true;
				_reloadSound.Play ();
			}
		}
		if (_reloading) {
			Debug.Log ("Reloading");
			_weapon.gameObject.transform.position = Vector3.MoveTowards (_weapon.gameObject.transform.position, reloadingPos.position,0.50f * Time.deltaTime);
			//_ammoDisplay.transform.localEulerAngles += new Vector3 (0, 0, 12);
		}
	}
	public void updateStats(){
		_fireRate = _weapon.fireRate;
		_maxBullets = _weapon.magSize;
	}
	public void Shoot(){
		_weapon.GetComponent<AudioSource> ().Play ();
		_weapon.shoot ();
		_bulletCont--;
	}
	public void Reload() {
		_bulletCont = _maxBullets;
		_weapon.gameObject.transform.position = originalPos.position;
		_reloading = false;
		if (_ammoDisplay) {
			
		}
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
