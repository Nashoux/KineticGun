using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineticGun : MonoBehaviour {

	List<BlockMove.Force> myForces = new List<BlockMove.Force>();

	bool stocked = false;
	LayerMask myMask;

	Quaternion myVectorRot;

	void Start () {
		myForces.Clear ();
		myForces.Add(new BlockMove.Force(new Vector3(1,0,0), new Vector3( transform.rotation.x, transform.rotation.y, transform.rotation.z) , 0.5f));
		myMask = 5;

		//myMask = ~myMask;
		Debug.Log(transform.parent);
	}
	
	void Update ()	{

		myVectorRot = transform.rotation;

		if (Input.GetKeyDown (KeyCode.Joystick1Button5) || Input.GetMouseButtonDown (1)) {
			RaycastHit hit; 
			if (Physics.Raycast (transform.position, Camera.main.transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, myMask) && (hit.collider.GetComponent<BlockMove> () || hit.collider.GetComponent<BlockAlreadyMoving> ())) {
			
				if (hit.collider.GetComponent<BlockMove> ()) {
					myForces.Add (hit.collider.GetComponent<BlockMove> ().myForce);
				} else {
					myForces.Add (hit.collider.GetComponent<BlockAlreadyMoving> ().myForce);
				}			
			}
		}

//		if(Input.GetKeyDown(KeyCode.Joystick1Button4)){
//
//			RaycastHit hit; 
//			if (Physics.Raycast (transform.position, Camera.main.transform.TransformDirection(Vector3.forward),  out hit, Mathf.Infinity, myMask) && (hit.collider.GetComponent<BlockMove>() || hit.collider.GetComponent<BlockAlreadyMoving>())) {
//
//				float result = Mathf.InverseLerp (0.9f, 9000, hit.distance);
//				result = Mathf.Lerp (0.90f, 10, result);
//			
//				myForces.Add(hit.collider.GetComponent<BlockMove> ().myForce);
//
//				BlockMove.Force intermediaryForce = myForces [myForces.Count - 1];
//				intermediaryForce.speed /= result;
//				myForces [myForces.Count - 1] = intermediaryForce;
//			}
//
//		}

		float triger1 = Input.GetAxis ("trigger1");

		if ((triger1 > 0.2f || Input.GetMouseButtonDown (0)) && !stocked) {
			stocked = true;
			RaycastHit hit; 
			if (Physics.Raycast (transform.position, Camera.main.transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, myMask) && hit.collider.GetComponent<BlockMove> ()) {

				hit.collider.GetComponent<BlockMove> ().changeMyForce (myForces [myForces.Count - 1]);
				myForces.RemoveAt (myForces.Count - 1);
			}
		} else if (triger1 < 0.2f) {
			stocked = false;
		}

		if (Input.GetMouseButtonDown (2)) {
			Debug.Log ("0");
			if (transform.parent == null) {
				Debug.Log ("1");
				RaycastHit hit; 
				if (Physics.Raycast (transform.position, Camera.main.transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, myMask) && (hit.collider.GetComponent<BlockMove> () || hit.collider.GetComponent<BlockAlreadyMoving> ())) {
					Quaternion rotation = transform.rotation;

					Debug.Log (rotation.eulerAngles);

					transform.SetParent(hit.transform,true);

					transform.rotation = rotation;
					//transform.localRotation = Quaternion.identity;
				}

			} else {
				Quaternion rotation = transform.rotation;
				transform.SetParent( null, true );

				RaycastHit hit; 
				if (Physics.Raycast (transform.position, Camera.main.transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, myMask) && (hit.collider.GetComponent<BlockMove> () || hit.collider.GetComponent<BlockAlreadyMoving> ())) {
					transform.SetParent(hit.transform,true);
				
				}
			}
		}

	}

	void LateUpdate (){
		
		//transform.rotation = myVectorRot;

		}
	


}
