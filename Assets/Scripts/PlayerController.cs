using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

	public GameObject cItemStart;
	public GameObject cItemEnd;
	public float ForceModifyer;
	public Vector3 StartLocation;
	public float MaxRbMagnitude;
	public Text ScoreText;
	public GameObject PanelGameHud;
	public GameObject PanelLevelCompleted;

	public Text PanelLevelCompletedResultText;

	public Text TimerMin;
	public Text TimerSec;

	private Rigidbody rb;

	private float dx;
	private float dy;
	private float dz;

	private int score;
	private int cItemQuantity;
	private bool cItemEndIsPick;
	private bool EndLevel;

	private bool TimerStarted;
	private float TimerCounter;
	private int Min, Sec;

	void Start(){

		score = 0;
		cItemQuantity = 4;
		cItemEndIsPick = false;
		EndLevel = false;

		Time.timeScale = 1f;

		UpdateUI (EndLevel);

		rb = GetComponent<Rigidbody> ();

		ResetPlayer ();

		InitializeTimer ();
	}

	void Update(){
		InputManagment ();
		TickTimer ();
		UpdateTimerUI ();
	}

	void FixedUpdate(){

		if (MaxRbMagnitude > rb.velocity.magnitude) {
			rb.AddForce (dx * ForceModifyer, dy * ForceModifyer, dz * ForceModifyer);
		}

		if (score == cItemQuantity && !cItemEndIsPick) {
			cItemEnd.SetActive (true);
		};

		if (EndLevel) {
			//Scene scene = SceneManager.GetActiveScene ();
			//SceneManager.LoadScene (scene.name);

			Time.timeScale = 0f;
			PanelGameHud.SetActive (false);

			string textMin = "000" + Min;
			string textSec = "00" + Sec;

			PanelLevelCompletedResultText.text = textMin.Substring (textMin.Length - 3, 3) + "." + textSec.Substring (textSec.Length - 2, 2);;
			PanelLevelCompleted.SetActive (true);

		};
	}

	void OnTriggerEnter(Collider collider){

		//Debug.Log ("hit " + collider.gameObject.tag);
		switch (collider.gameObject.tag) {
		case "cItem":
			score++;
			UpdateTriggeredItem (collider);
			UpdateUI (EndLevel);
			cItemEnd.SetActive (score == cItemQuantity);
			break;
		//case "cItemStart":
		//	if (TimerStarted == false) {
		//		TimerStarted = true;
		//		UpdateTriggeredItem (collider);
		//	};
		//	break;
		case "cItemEnd":
			cItemEndIsPick = true;
			EndLevel = true;
			UpdateTriggeredItem (collider);
			UpdateUI (EndLevel);
			break;
		case "outLevel":
			ResetPlayer();
			break;
		};

	}

	void OnTriggerExit(Collider collider){

		//Debug.Log ("hit " + collider.gameObject.tag);
		switch (collider.gameObject.tag) {
		case "cItemStart":
			if (TimerStarted == false) {
				TimerStarted = true;
				UpdateTriggeredItem (collider);
			};
			break;
		};

	}

	public void InitializeTimer(){
		TimerStarted = false;
		TimerCounter = 0;
		UpdateTimerUI ();
	}

	public Vector3 GetForceVector(float ration){

		Vector3 RetValue = rb.velocity;

		return RetValue;
	
	}

	void PauseGame (){

		if (Time.timeScale == 0f) {
			Time.timeScale = 1f;
		}else{
			Time.timeScale = 0f;
		};

	}

	void ResetPlayer(){
	
		if (ForceModifyer == 0.0f) {
			ForceModifyer = 30;
		}

		ResetFocreDirectional ();
		ResetRigidVelocity ();
		ResetPlayerPosition (new Vector3(0.0f,0.0f,0.0f));
 			
	}

	void ResetFocreDirectional(){
		dx = 0.0f;
		dy = 0.0f;
		dz = 0.0f;
	}

	void ResetRigidVelocity(){
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero; 
	}

	void ResetPlayerPosition(Vector3 newPos){

		rb.isKinematic = true;

		if(newPos == new Vector3(0.0f,0.0f,0.0f)){
			transform.position = StartLocation;			
		}else{
			transform.position = newPos;
		};

		rb.isKinematic = false;
	}

	void InputManagment(){

		dx = Input.GetAxis ("Horizontal");
		dz = Input.GetAxis ("Vertical");

		//if (Input.GetKey (KeyCode.Space) == true) {
		//	ResetPlayer ();
		//};

		//if (Input.GetKey (KeyCode.CapsLock) == true) {
		if(Input.GetButtonDown("Submit") == true){
			PauseGame ();
		}

		if (Input.GetKey (KeyCode.F2) == true) {
			EndLevel = true;
		}

	}

	private void UpdateTriggeredItem (Collider collider){
		collider.gameObject.SetActive (false);
	}

	void UpdateUI(bool EndGame){
			ScoreText.text = "Score: " + score.ToString () + "/" + cItemQuantity.ToString ();
	}

	public void TickTimer(){
		if (TimerStarted == true) {
			TimerCounter += Time.deltaTime;
		};
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
