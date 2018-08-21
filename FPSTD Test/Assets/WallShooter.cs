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
	private GameObject tile;
	private GameObject _hoverWall;

	void Awake(){
		_hoverWall = Instantiate (hoverWall);
		_hoverWall.transform.position = (new Vector3 (1000,1000,1000));
	}

	void Update(){
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, lenght, layer)) {
			WallSpawn _wall = hit.collider.GetComponent<WallSpawn> ();
			if (Input.GetButtonDown ("Fire1")) {
				_wall.IsActive = true;
			}
			if (Input.GetButtonDown ("Fire2")) {
				_wall.IsActive = false;
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
