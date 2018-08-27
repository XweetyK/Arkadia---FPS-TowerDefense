using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWalker : MonoBehaviour {
	private NavMeshAgent nma;

	public Transform target;

	void Awake()
	{
		nma = GetComponent<NavMeshAgent> ();
	}
	public void Walk(){
		nma.destination = target.position;
	}
}