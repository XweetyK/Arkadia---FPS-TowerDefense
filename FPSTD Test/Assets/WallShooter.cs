using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShooter : MonoBehaviour {

	[SerializeField] private int lenght;
	[SerializeField] private LayerMask layer;
	[SerializeField] private Material _newMat;
	[SerializeField] private Material _oldMat;
	GameObject tile;

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
			}
		} else {
			if (tile != null) {
				tile.GetComponent<Renderer> ().material = _oldMat;
				tile = null;
			}
		}
	}
	void OnDrawGizmos(){
		Gizmos.DrawRay(transform.position, transform.forward*lenght);
	}
}
