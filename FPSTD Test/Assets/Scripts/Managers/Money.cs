using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

	[SerializeField] private int _initMoney;
	private int _moneyCant;

	void Awake () {
	}
	void Start(){
		_moneyCant = _initMoney;
	}

	public int MoneyCant{
		get {return _moneyCant;}
	}
	public void MoneySum(int cant){
		_moneyCant += cant;
	}
	public void MoneyDisc(int cant){
		_moneyCant -= cant;
	}
}