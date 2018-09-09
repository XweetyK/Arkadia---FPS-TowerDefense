using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooter : MonoBehaviour {

	[SerializeField] private GameObject _bulletPref;
	[SerializeField] private float _fireRate;
	[SerializeField] private float _maxDistance;
	[SerializeField] private float _rotSpeed;
	private GameObject[] _totalEnemies;
	private GameObject _actualTarget;
	private float _actualDistance;
	private int _nearest;
	private Vector3 _rot;
	private int _cont;
	private GameObject _bullet;
	private bool _active;

	void Start(){
		_totalEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
		_actualTarget = _totalEnemies [0];
		_cont = 0;
		_active = false;
	}
	void Update(){
		if (_actualTarget == null) {
			CheckDistance ();
			Debug.Log ("this happens");
		} else {
			if (Vector3.Distance (_actualTarget.transform.position, transform.position) > _maxDistance) {
				CheckDistance ();
			}
			if (_actualTarget != null) {
				Debug.Log (_actualTarget.gameObject.name);
				_rot = Vector3.RotateTowards (transform.forward, _actualTarget.transform.position, _rotSpeed * Time.deltaTime, 0.0f);
				transform.rotation = Quaternion.LookRotation (_rot);
			}
			if (Vector3.Distance (_actualTarget.transform.position, transform.position) < _maxDistance && !_active) {
				//Invoke ("Shoot", _fireRate);
				Debug.Log ("yep");
				_active = true;
			} else{
				_active = false;
			}
		}
	}
	private void CheckDistance(){
		while (_totalEnemies [_cont] == null) {
			_cont++;
		}
		_actualTarget = _totalEnemies [_cont];
	}
	/*private void Shoot(){
		if (_active) {
			_bullet = Instantiate (_bulletPref);
			_bullet.transform.position = transform.position;
			_bullet.transform.rotation = transform.rotation;
			Invoke ("Shoot", _fireRate);
		}
	}*/
}
