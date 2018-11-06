using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {
	[SerializeField]protected float _fireRate = 0f;
	[SerializeField]protected float _damage = 0f;
	[SerializeField]protected float _piercing = 0f;
	[SerializeField]protected int _magSize = 0;
	[SerializeField]protected float _range = 0f;
	[SerializeField]protected string _name = "BLANK";
	[SerializeField]protected GameObject _bullet;
	[SerializeField]protected bool _automatic;
	protected GameObject bullet;

	public abstract void shoot ();
	public float fireRate{
		get{ return _fireRate;}
		set{fireRate = value;}
	}
	public int magSize{
		get{ return _magSize;}
		set{_magSize = value;}
	}
	public float range{
		get{ return _range;}
	}
	public bool automatic{
		get{ return _automatic;}
	}
}