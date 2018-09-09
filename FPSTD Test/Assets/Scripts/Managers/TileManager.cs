using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
	private GameObject _savedWall=null;
	public GameObject SavedWall{
		get{ return _savedWall; }
		set{ _savedWall = value; }
	}
}
