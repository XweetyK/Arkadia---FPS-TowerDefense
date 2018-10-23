using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	[SerializeField] private float _life=12;
	void Update (){
	}
	public float LifeGetter{
		get{ return _life; }
		set{ _life = value; }
	}
	public void Damager(float damage){
		_life -= damage;
	}
}
