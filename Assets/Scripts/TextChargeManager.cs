using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChargeManager : MonoBehaviour {

	public UIManager uim;
	public PoleController pl;
	private Text text;
	float currentTime = 0.0f;
	const string ChargePrefix = "Charge : ";

	void Start () {
		text = this.GetComponent<Text>();
		currentTime = 0.0f;
		text.text = ChargePrefix + currentTime + " %";		
	}

	void Update () {
		currentTime = pl.passTime * 100;
		text.text = ChargePrefix + currentTime + " %";	
		if (uim.rst) {
			Start ();
			uim.rst = false;
		}
	}
}
