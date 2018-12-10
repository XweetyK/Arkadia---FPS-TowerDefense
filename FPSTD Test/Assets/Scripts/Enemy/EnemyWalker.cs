﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalker : MonoBehaviour {
	private NavMeshAgent _nma;
	private GameObject[] _target;
	private Life _life;
	private Money _money;
	[SerializeField] private float _destroyerDelay=0.5f;
	[SerializeField] private int _moneyCant=50;
	[SerializeField] private int _damage=10;
	private Animator _animation;
	private bool _alive;
	private int _rand =0;

	void Awake(){
		_nma = GetComponent<NavMeshAgent> ();
		_target = GameObject.FindGameObjectsWithTag ("Target");
		_money = FindObjectOfType<Money>();
		_animation = gameObject.GetComponentInChildren<Animator> ();
	}
	void Start(){
		_life = GetComponent<Life> ();
		_alive = true;
	}
	void Update(){
		_rand = Random.Range (0, _target.Length) == 0 ? 0 : _target.Length-1;
		checkHealth ();
	}
	void checkHealth(){
		if (_life.LifeGetter <= 0 && _alive == true) {
			_nma.isStopped = true;
			_alive = false;
			_animation.SetBool ("IsDead", true);
			_money.MoneySum (_moneyCant);
			Destroy (gameObject,2.0f);
		}
	}
	public void Walk(bool _MultiTarget){
		if (_MultiTarget) {
			_nma.destination = _target [_rand].transform.position;
		} else {
			_nma.destination = _target [0].transform.position;
		}
	}
	public void Destroyer(){
		Destroy (gameObject,_destroyerDelay);
	}
	public bool Alive{
		get{ return _alive; }
	}
	public int Damage{
		get{ return _damage; }
	}
}