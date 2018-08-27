using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour {

	[SerializeField] private GameObject wall;
	[SerializeField] float wallHeight;
	private bool _isActive;
	private GameObject _wall;

	void Awake(){
		_isActive = false;
		_wall = Instantiate (wall);
		_wall.transform.position = transform.position+(new Vector3(0.0f,wallHeight,0.0f));
	}
	void Update(){
		if (_isActive == false) {
			_wall.SetActive (false);
		}
		if (_isActive == true) {
			_wall.SetActive (true);
		}
	}
	public bool IsActive{
		get{return _isActive;}
		set{_isActive=value;}
	}
}
