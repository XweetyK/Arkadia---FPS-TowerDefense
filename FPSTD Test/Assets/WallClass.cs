using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClass : MonoBehaviour {
	private bool _isPlaced=false;
	private Vector3 _originalPos;

	public bool Placed{
		get{return _isPlaced;}
		set{_isPlaced = value;}
	}
	public Vector3 OriginalPos{
		get{ return _originalPos; }
		set{ _originalPos = value; }
	}
}
