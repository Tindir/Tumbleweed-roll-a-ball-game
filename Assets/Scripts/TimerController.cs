using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEditor;
using UnityEngine.UI;
using System.Threading;

public class TimerController : MonoBehaviour {

	public Text TimerMin;
	public Text TimerSec;

	private float TimerCounter;
	private int Min, Sec;

	void Start(){
		Initialize ();

	}

	void Update () {
		TickTimer ();
		UpdateTimerUI ();
	}

	public void Initialize(){
		TimerCounter = 0;
		UpdateTimerUI ();
	}

	public void TickTimer(){
		TimerCounter += Time.deltaTime;
	}

	public void UpdateTimerUI(){

		TimerMinSec (TimerCounter);

		string textMin = "000" + Min;
		string textSec = "00" + Sec;

		TimerMin.text = textMin.Substring (textMin.Length - 3, 3);
		TimerSec.text = textSec.Substring (textSec.Length - 2, 2);

	}

	private void TimerMinSec(float CounterData){
		Min = (int)CounterData / 60;
		Sec = (int)CounterData - Min*60;
	}
}
