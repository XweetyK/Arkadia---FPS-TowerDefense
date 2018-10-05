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

	void Awake(){
		_nma = GetComponent<NavMeshAgent> ();
		_target = GameObject.FindGameObjectWithTag ("Target");
		_money = FindObjectOfType<Money>();
	}
	void Start(){
		_life = GetComponent<Life> ();
	}
	void Update(){
		checkHealth ();
	}
	void checkHealth(){
		if (_life.LifeGetter <= 0) {
			_money.MoneySum (_moneyCant);
			Destroy (gameObject);
		}
	}
	public void Walk(){
		_nma.destination = _target.transform.position;
	}
	public void Destroyer(){
		Destroy (gameObject,_destroyerDelay);
	}
}