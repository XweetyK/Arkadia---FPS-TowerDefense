using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsManager : MonoBehaviour {

	[SerializeField] private int wallsCant;
	[SerializeField] private float wallHeight;
	[SerializeField] private GameObject wallPrefab;
	private GameObject[] walls;
	private int _freeWallCount;

	void Start () {
		walls= new GameObject[wallsCant];
		for (int i = 0; i < wallsCant; i++) {
			walls [i] = Instantiate (wallPrefab);
			walls [i].transform.position = new Vector3 (0+ i * 2, wallHeight, 100);
			walls [i].GetComponent<WallClass> ().OriginalPos = walls [i].transform.position;
			_freeWallCount = wallsCant;
		}
	}

	public GameObject FreeCheck(){
		for (int i = 0; i < wallsCant; i++) {
			if (walls [i].GetComponent<WallClass> ().Placed == false) {
				walls [i].GetComponent<WallClass> ().Placed = true;
				_freeWallCount--;
				return walls [i];
			}
		}
		return null;
	}
	public void ReturnWall (GameObject returned){
		for (int i = 0; i < wallsCant; i++) {
			if (walls [i] == returned) {
				walls [i].transform.position = walls [i].GetComponent<WallClass> ().OriginalPos;
				walls [i].GetComponent<WallClass> ().Placed = false;
				_freeWallCount++;
			}
		}
	}
	public int freeWallCount{
		get{ return _freeWallCount; }
		set{_freeWallCount += value;}
	}
}
