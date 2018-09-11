using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

	[SerializeField] private int _life=12;
	[SerializeField] private float _delay;
	void Update (){
		if (_life <= 0) {
			Destroy (gameObject,_delay);
		}
	}
	public int LifeGetter{
		get{ return _life; }
		set{ _life = value; }
	}
	public void Damager(int damage){
		_life -= damage;
	}
}
