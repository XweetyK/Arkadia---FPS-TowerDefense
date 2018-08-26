using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsManager : MonoBehaviour {

	[SerializeField] private int wallsCant;
	[SerializeField] private float wallHeight;
	[SerializeField] private GameObject wallPrefab;
	private GameObject[] walls;
	private Vector3 _originalPos;

	void Start () {
		walls= new GameObject[wallsCant];
		for (int i = 0; i < wallsCant; i++) {
			walls [i] = Instantiate (wallPrefab);
			walls [i].transform.position = new Vector3 (0+ i * 2, wallHeight, 100);
		}
	}

	public GameObject FreeCheck(){
		for (int i = 0; i < wallsCant; i++) {
			if (walls [i].GetComponent<WallClass> ().Placed == false) {
				walls [i].GetComponent<WallClass> ().Placed = true;
				return walls [i];
			}
		}
		return null;
	}
}
