using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject FocusObj;
	public GameObject ControledCamera;

	private Vector3 CameraOffsetTransform = new Vector3(0.0f, 30f, 0.0f);

	void Start () {
		ResetController ();
	}


	// Update is called once per frame
	void LateUpdate () {

		InputManagment ();

		FocusObj.transform.position = transform.position;

	}

	Vector3 OffsetTransformUpdate(){

		return CameraOffsetTransform;

	}
		
	public void ResetController(){

		ResetOffset ();

		ResetCameraTransform ();

	}

	void ResetOffset (){

		CameraOffsetTransform = new Vector3(0.0f, 30f, 0.0f);

	}


	void ResetCameraTransform (){

		ControledCamera.transform.position = CameraOffsetTransform;

	}

	void InputManagment(){

		if (Input.GetKey (KeyCode.Z) == true) {
			CameraOffsetTransform = CameraOffsetTransform + new Vector3(0.0f, 5.0f, 0.0f);
			ControledCamera.transform.position = CameraOffsetTransform;
		};
		if (Input.GetKey (KeyCode.X) == true) {
			CameraOffsetTransform = CameraOffsetTransform - new Vector3(0.0f, 5.0f, 0.0f);
			ControledCamera.transform.position = CameraOffsetTransform;
		};
		//if (Input.GetKey (KeyCode.Space) == true) {
		//	ResetOffset ();
		//	ControledCamera.transform.position = CameraOffsetTransform;
		//};
			
	}

}
