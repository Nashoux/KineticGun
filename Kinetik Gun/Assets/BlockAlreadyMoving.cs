using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAlreadyMoving : MonoBehaviour {

	Vector3 positionStart;

	public BlockMove.Force myForce = new BlockMove.Force (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0), 0);

	enum mouvementType {noMouv, yy, xx, zz, xz, zx, xy, yx, yz, zy, xzy,zxy, specific }

	[SerializeField] mouvementType myNewMouv = mouvementType.noMouv;

	[SerializeField] float speed = 1;

	[SerializeField] Vector3 specificPos1;
	[SerializeField] Vector3 specificPos2;
	bool goToSpePos1 = false;

	List<Vector3> AllThePlace = new List<Vector3> ();
	[SerializeField] float timerReturn = 0;
	[SerializeField] float timerReturnBase = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		switch (myNewMouv) {

		case mouvementType.noMouv:

			break;

		case mouvementType.yy:

			StartCoroutine ("MouvToUpAndDown");

			myNewMouv = mouvementType.noMouv;

			break;

		case mouvementType.xx:
			StartCoroutine ("MouvToX");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.zz:
			StartCoroutine ("MouvToZ");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.xz:
			StartCoroutine ("DiagonalXZ");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.zx:
			StartCoroutine ("DiagonalZX");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.zxy:
			StartCoroutine ("DiagonalYZX");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.xzy:
			StartCoroutine ("DiagonalYXZ");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.zy:
			StartCoroutine ("DiagonalZY");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.yz:
			StartCoroutine ("DiagonalYZ");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.xy:
			StartCoroutine ("DiagonalXY");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.yx:
			StartCoroutine ("DiagonalYX");

			myNewMouv = mouvementType.noMouv;
			break;

		case mouvementType.specific:

			if (timerReturn > timerReturnBase) {
				ReturnToStart ();
			} else {
				timerReturn += Time.deltaTime;
			

				if (!goToSpePos1) {
					if (Vector3.Distance (transform.position, specificPos2) < 0.1f) {
						transform.position = Vector3.MoveTowards (transform.position, specificPos2, speed * Time.deltaTime);
					} else {
						goToSpePos1 = !goToSpePos1;
					}

				} else {
					if (Vector3.Distance (transform.position, specificPos1) < 0.1f) {
						transform.position = Vector3.MoveTowards (transform.position, specificPos1, speed * Time.deltaTime);
					} else {
						goToSpePos1 = !goToSpePos1;
					}
				}
			}

			break;

		}



		transform.position += myForce.direction * myForce.speed * Time.deltaTime;

		if(Input.GetKeyDown(KeyCode.R)){
			transform.position = positionStart;
			myForce = new BlockMove.Force (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0), 0);
		}
	}

	IEnumerator MouvToUpAndDown(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, 1, 0), new Vector3 (0, 0, 0), speed);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, 1, 0), new Vector3 (0, 0, 0), -speed);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, 1, 0), new Vector3 (0, 0, 0), speed);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("MouvToUpAndDown");

	}

	IEnumerator MouvToX(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 0, 0), new Vector3 (0, 0, 0), speed);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 0, 0), new Vector3 (0, 0, 0), -speed);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 0, 0), new Vector3 (0, 0, 0), speed);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("MouvToX");

	}

	IEnumerator MouvToZ(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, 0, 1), new Vector3 (0, 0, 0), speed);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, 0, 1), new Vector3 (0, 0, 0), -speed);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, 0, 1), new Vector3 (0, 0, 0), speed);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("MouvToZ");

	}

	IEnumerator DiagonalXZ(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 0, 1), new Vector3 (0, 0, 0), speed);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 0, 1), new Vector3 (0, 0, 0), -speed);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 0, 1), new Vector3 (0, 0, 0), speed);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("DiagonalXZ");
	}

	IEnumerator DiagonalZX(){

			for (float i = 0; i < 1; i += Time.deltaTime) {
				myForce = new BlockMove.Force (new Vector3 (-1, 0, -1), new Vector3 (0, 0, 0), 1);
				yield return new WaitForEndOfFrame ();
			}

			for (float i = 0; i < 2; i += Time.deltaTime) {
				myForce = new BlockMove.Force (new Vector3 (-1, 0, -1), new Vector3 (0, 0, 0), -1);
				yield return new  WaitForEndOfFrame ();
			}

			for (float i = 0; i < 1; i += Time.deltaTime) {
				myForce = new BlockMove.Force (new Vector3 (-1, 0, -1), new Vector3 (0, 0, 0), 1);
				yield return new  WaitForEndOfFrame ();
			}

			StartCoroutine ("DiagonalZX");

	}

	IEnumerator DiagonalYZX(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (-1, -1, -1), new Vector3 (0, 0, 0), 1);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (-1, -1, -1), new Vector3 (0, 0, 0), -1);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (-1, -1, -1), new Vector3 (0, 0, 0), 1);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("DiagonalYZX");

	}

	IEnumerator DiagonalYXZ(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 1, 1), new Vector3 (0, 0, 0), 1);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 1, 1), new Vector3 (0, 0, 0), -1);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 1, 1), new Vector3 (0, 0, 0), 1);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("DiagonalYXZ");

	}

	IEnumerator DiagonalZY(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, 1, 1), new Vector3 (0, 0, 0), 1);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, 1, 1), new Vector3 (0, 0, 0), -1);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, 1, 1), new Vector3 (0, 0, 0), 1);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("DiagonalZY");

	}

	IEnumerator DiagonalXY(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 1, 0), new Vector3 (0, 0, 0), 1);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 1, 0), new Vector3 (0, 0, 0), -1);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, 1, 0), new Vector3 (0, 0, 0), 1);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("DiagonalXY");

	}

	IEnumerator DiagonalYX(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, -1, 0), new Vector3 (0, 0, 0), 1);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, -1, 0), new Vector3 (0, 0, 0), -1);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (1, -1, 0), new Vector3 (0, 0, 0), 1);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("DiagonalYX");

	}

	IEnumerator DiagonalYZ(){

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, -1, 1), new Vector3 (0, 0, 0), 1);
			yield return new WaitForEndOfFrame ();
		}

		for (float i = 0; i < 2; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, -1, 1), new Vector3 (0, 0, 0), -1);
			yield return new  WaitForEndOfFrame ();
		}

		for (float i = 0; i < 1; i += Time.deltaTime) {
			myForce = new BlockMove.Force (new Vector3 (0, -1, 1), new Vector3 (0, 0, 0), 1);
			yield return new  WaitForEndOfFrame ();
		}

		StartCoroutine ("DiagonalYZ");

	}

	void OnCollisionEnter(){
		timerReturn = timerReturnBase + 1;
	}

	void ReturnToStart(){
		if (AllThePlace.Count > 0) {

			Debug.Log ("a");

			transform.position = Vector3.MoveTowards (transform.position, AllThePlace [AllThePlace.Count - 1], speed*Time.deltaTime);

			if (Vector3.Distance (transform.position, AllThePlace [AllThePlace.Count - 1]) < 0.2f) {
				AllThePlace.RemoveAt (AllThePlace.Count - 1);
			}
		}
	}

	public void changeMyForce ( BlockMove.Force _force ){

		timerReturn = 0;

		AllThePlace.Add (transform.position);

		Vector3.Normalize (myForce.direction);

		myForce.direction = Vector3.Normalize (myForce.direction + Vector3.Normalize (_force.direction));

		myForce.speed = _force.speed;

		//transform.rotation = Quaternion.identity;

		//transform.Rotate (_force.orientation);

	}


}
