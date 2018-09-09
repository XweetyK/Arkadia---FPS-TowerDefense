using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField] private Image _bar;
	private Life _lifeManager;
	private int _startLife;
	private int _updatedLife;

	void Start(){
		_lifeManager = gameObject.GetComponent<Life> ();
		_startLife = _lifeManager.LifeGetter;
		_updatedLife = _lifeManager.LifeGetter;
	}
	void Update(){
		_updatedLife = _lifeManager.LifeGetter;
		_bar.fillAmount = (float)_updatedLife / _startLife;
	}
}
