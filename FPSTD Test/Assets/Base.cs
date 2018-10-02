using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

	private Life _life;
	void Start () {
		
	}

	void Awake(){
		_life = GetComponent<Life> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
