using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class del_CameraController : MonoBehaviour {

	public GameObject FocusObj;

	//private float offsetTransformRation = 0.0f;
	//private float offsetRotationRation = 10.0f;

	private Vector3 offsetTransform = new Vector3(0.0f, 15f, 0.0f);
	//private Quaternion offsetRotation = new Quaternion(90f, 0.0f, 0.0f, 0.0f);
	private Vector3 offsetRotation = new Vector3(90f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {
		ResetCamera ();
	}
		
	// Update is called once per frame
	void LateUpdate () {

		InputManagment ();

		transform.position = FocusObj.transform.position + OffsetTransformUpdate();
		transform.eulerAngles = offsetRotationUpdate ();
	}

	Vector3 OffsetTransformUpdate(){

		return offsetTransform;

	}

	Vector3 offsetRotationUpdate(){

		PlayerController PC = FocusObj.GetComponent<PlayerController> ();
		Vector3 ForceVector =  PC.GetForceVector (0.0f);

		//Solve this math!!!
		Vector3 RotationVector = new Vector3 (offsetRotation.x + ForceVector.x, offsetRotation.y + ForceVector.y, offsetRotation.z + ForceVector.z); //offsetRotation - PC.GetForceVector (0.0f);

		return RotationVector;

	}

	public void ResetCamera(){
		
		ResetOffset ();

		ResetCameraTransform ();
		ResetCameraRotation ();
			
	}

	void ResetOffset (){
		
		offsetTransform = new Vector3(0.0f, 15f, 0.0f);
		//private Quaternion offsetRotation = new Quaternion(90f, 0.0f, 0.0f, 0.0f);
		offsetRotation = new Vector3(90f, 0.0f, 0.0f);
				
	}


	void ResetCameraTransform (){
	
		transform.position = FocusObj.transform.position + offsetTransform;

	}

	void ResetCameraRotation (){
		transform.eulerAngles = offsetRotation;
	}

	void InputManagment(){

		if (Input.GetKey (KeyCode.Z) == true) {
			offsetTransform = offsetTransform + new Vector3(0.0f, 5.0f, 0.0f);
		};
		if (Input.GetKey (KeyCode.X) == true) {
			offsetTransform = offsetTransform - new Vector3(0.0f, 5.0f, 0.0f);
		};

	}

}
