using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShooter : MonoBehaviour {

	[SerializeField] private float lenght = 7;
	[SerializeField] float wallHeight;
	[SerializeField] private LayerMask layer;
	[SerializeField] private Material _newMat;
	[SerializeField] private Material _oldMat;
	[SerializeField] private GameObject hoverWall;
	[SerializeField] private GameObject managerPrefab;
	private GameObject tile;
	private GameObject _hoverWall;
	WallsManager _manager;

	void Awake(){
		_hoverWall = Instantiate (hoverWall);
		_hoverWall.transform.position = (new Vector3 (1000,1000,1000));
		_manager = managerPrefab.GetComponent<WallsManager> ();
	}

	void Update(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, lenght, layer)) {
			Transform _wall = hit.collider.GetComponent<Transform> ();
			if (Input.GetButtonDown ("Fire1")) {
				_manager.FreeCheck ().transform.position = _wall.position+(new Vector3(0,wallHeight,0));
			}
			if (Input.GetButtonDown ("Fire2")) {
				
			}
			if (tile != hit.collider.gameObject) {
				if (tile != null) {
					tile.GetComponent<Renderer> ().material = _oldMat;
				}
				tile = hit.collider.gameObject;
				tile.GetComponent<Renderer> ().material = _newMat;
				_hoverWall.transform.position = tile.transform.position+(new Vector3(0.0f,wallHeight,0.0f));
			}
		} else {
			if (tile != null) {
				tile.GetComponent<Renderer> ().material = _oldMat;
				tile = null;
				_hoverWall.transform.position = (new Vector3 (1000,1000,1000));
			}
		}
	}
	void OnDrawGizmos(){
		Gizmos.DrawRay(transform.position, transform.forward*lenght);
	}
}
