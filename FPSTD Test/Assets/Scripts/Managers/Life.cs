using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	[SerializeField] private int _life=12;
	void Update (){
	}
	public int LifeGetter{
		get{ return _life; }
		set{ _life = value; }
	}
	public void Damager(int damage){
		_life -= damage;
	}
}
