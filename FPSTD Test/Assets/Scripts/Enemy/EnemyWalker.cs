using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalker : MonoBehaviour {
	private NavMeshAgent _nma;
	private GameObject _target;
	private Life _life;
	[SerializeField] private float _destroyerDelay=0.5f;

	void Awake(){
		_nma = GetComponent<NavMeshAgent> ();
		_target = GameObject.FindGameObjectWithTag ("Target");
	}
	void Start(){
		_life = GetComponent<Life> ();
	}
	void checkHealth(){
		if (_life.LifeGetter <= 0) {
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