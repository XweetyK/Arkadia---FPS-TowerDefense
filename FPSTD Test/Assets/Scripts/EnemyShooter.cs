using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour {

	[SerializeField] private GameObject _bullet;
	[SerializeField] private int _bulletCont;
	[SerializeField] private GameModeManager _GMmanager;
	GameObject bullet;

	void Update () {
		if (_GMmanager.GameMode == GameModeManager.GAMEMODE.DESTROYER) {
			if (Input.GetButtonDown ("Fire1") && _bulletCont > 0) {
				Invoke ("Shoot",0f);
			}
		}
	}
	public void Shoot(){
		bullet = Instantiate (_bullet);
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
		_bulletCont--;
	}
	public int BulletCont{
		get{return _bulletCont;}
		set{ _bulletCont = value; }
	}
}
