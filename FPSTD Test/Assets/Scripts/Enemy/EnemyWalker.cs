using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalker : MonoBehaviour {
	private NavMeshAgent _nma;
	private GameObject _target;
	private Life _life;
	private Money _money;
	[SerializeField] private float _destroyerDelay=0.5f;
	[SerializeField] private int _moneyCant=50;
	private Animator _animation;
	private bool _alive;

	void Awake(){
		_nma = GetComponent<NavMeshAgent> ();
		_target = GameObject.FindGameObjectWithTag ("Target");
		_money = FindObjectOfType<Money>();
		_animation = gameObject.GetComponentInChildren<Animator> ();
	}
	void Start(){
		_life = GetComponent<Life> ();
		_alive = true;
	}
	void Update(){
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
	public void Walk(){
		_nma.destination = _target.transform.position;
	}
	public void Destroyer(){
		Destroy (gameObject,_destroyerDelay);
	}
	public bool Alive{
		get{ return _alive; }
	}
}