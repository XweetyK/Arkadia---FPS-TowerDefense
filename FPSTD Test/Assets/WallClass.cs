using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClass : MonoBehaviour {
	private bool _isPlaced=false;

	public bool Placed{
		get{return _isPlaced;}
		set{_isPlaced = value;}
	}
}
