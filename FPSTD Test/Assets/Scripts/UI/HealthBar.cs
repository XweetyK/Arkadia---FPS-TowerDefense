using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	[SerializeField] private Image _bar;
	private Life _lifeManager;
	private float _startLife;
	private float _updatedLife;
	[SerializeField]private bool _isBase;

	void Start(){
		_lifeManager = gameObject.GetComponent<Life> ();
		_startLife = _lifeManager.LifeGetter;
		_updatedLife = _lifeManager.LifeGetter;
	}
	void Update(){
		if (!_isBase) {
			_updatedLife = _lifeManager.LifeGetter;
			_bar.fillAmount = (float)_updatedLife / _startLife;
		} else {
			_updatedLife = _lifeManager.LifeGetter;
			_bar.fillAmount = 1.0f-((float)_updatedLife / _startLife);
		}
	}
}
