﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShooter : MonoBehaviour {

	[SerializeField] private float lenght = 7;
	[SerializeField] float wallHeight;
	[SerializeField] private LayerMask layer;
	[SerializeField] private Material _newMat;
	[SerializeField] private Material _oldMat;
	[SerializeField] private GameObject hoverWall;
	[SerializeField] private GameObject hoverFalse;
	[SerializeField] private GameObject managerPrefab;
	[SerializeField] private GameModeManager _GMmanager;
	private GameObject tile;
	private GameObject _wall;
	private GameObject _hoverWall;
	private GameObject _hoverFalse;
	private bool tiled;
	private WallsManager _manager;
	private Money _money;

	void Awake(){
		_hoverWall = Instantiate (hoverWall);
		_hoverWall.transform.position = (new Vector3 (1000,1000,1000));
		_hoverFalse = Instantiate (hoverFalse);
		_hoverFalse.transform.position = (new Vector3 (1000,1020,1000));
		_manager = managerPrefab.GetComponent<WallsManager> ();
		_money = FindObjectOfType<Money> ();
	}

	void Update(){
		tiled = false;
		if (_GMmanager.GameMode == GameModeManager.GAMEMODE.WALLBUILDER) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, transform.forward, out hit, lenght, layer)) {
				GameObject _tile = hit.transform.gameObject;
				if (InputManager.Instance.GetFire1Button()) {
					if (_money.MoneyCant >= 100) {
						if (_tile.GetComponent<TileManager> ().SavedWall == null) {
							_wall = _manager.FreeCheck ();
							_tile.GetComponent<TileManager> ().SavedWall = _wall;
							_wall.transform.position = _tile.transform.position + (new Vector3 (0, wallHeight, 0));
						}
					}
				}
				if (InputManager.Instance.GetFire2Button()) {
					if (_tile.GetComponent<TileManager> ().SavedWall != null) {
						_manager.ReturnWall (_tile.GetComponent<TileManager> ().SavedWall);
						_tile.GetComponent<TileManager> ().SavedWall = null;
					}
				}
				if (tile != hit.collider.gameObject) {
					if (tile != null) {
						tile.GetComponent<Renderer> ().material = _oldMat;
					}
					tile = hit.collider.gameObject;
					tile.GetComponent<Renderer> ().material = _newMat;
					if (_money.MoneyCant != 0) {
						_hoverWall.transform.position = tile.transform.position + (new Vector3 (0.0f, wallHeight, 0.0f));
						_hoverFalse.transform.position = (new Vector3 (1000, 1000, 1000));
					} else {
						_hoverFalse.transform.position = tile.transform.position + (new Vector3 (0.0f, wallHeight, 0.0f));
						_hoverWall.transform.position = (new Vector3 (1000, 1000, 1000));
					}
				}
			} else {
				if (tile != null) {
					tile.GetComponent<Renderer> ().material = _oldMat;
					tile = null;
					_hoverWall.transform.position = (new Vector3 (1000, 1000, 1000));
					_hoverFalse.transform.position = (new Vector3 (1000, 1000, 1000));
				}
			}
		}
		if (_GMmanager.GameMode == GameModeManager.GAMEMODE.DESTROYER) {
			if (tiled == false) {
				if (tile != null) {
					tile.GetComponent<Renderer> ().material = _oldMat;
				}
				_hoverWall.transform.position = (new Vector3 (1000, 1000, 1000));
				_hoverFalse.transform.position = (new Vector3 (1000, 1000, 1000));
				tiled = true;
			}
		}
	}
	void OnDrawGizmos(){
		Gizmos.DrawRay(transform.position, transform.forward*lenght);
	}
}
