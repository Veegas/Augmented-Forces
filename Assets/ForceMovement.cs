using UnityEngine;
using System.Collections;
using Vuforia;

public class ForceMovement : MonoBehaviour {

	private GameObject toBeMoved;
	private DefaultTrackableEventHandler toBeMovedHandler;
	private Vector3 lastPosition;
	public GameObject rightForce;
	//public GameObject leftForce;
	public float tolerance;
	private int frameNumber = 0;
	public int mass = 1;
	private Vector3 lastVelocity;

	// Use this for initialization
	void Start () {
		toBeMoved = this.gameObject;
		toBeMovedHandler = toBeMoved.GetComponent<DefaultTrackableEventHandler> ();
		lastPosition = toBeMoved.transform.position;
		lastVelocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (toBeMovedHandler.tracking) {

			if (frameNumber == 0) {
				float time = 2;
				Vector3 newPosition = toBeMoved.transform.position;

				Vector3 differenceDistance = newPosition - lastPosition;
//				differenceDistance.y = 0;
//				differenceDistance.z = 0;

				Vector3 newVelocity = (differenceDistance / time) * 5;

				Vector3 diffVelocity = newVelocity - lastVelocity;

				Vector3 acceleration = diffVelocity / time;

//				Vector3 netForce = mass * acceleration;

				Vector3 netForce = differenceDistance * -1;
				// Object moved to Right so draw force the opposite direction
				if (netForce.magnitude > tolerance) {
					rightForce.SetActive (true);
					rightForce.GetComponent<LineRenderer> ().SetPosition (1, netForce);
				} else {
					rightForce.SetActive (false);
				}
				lastPosition = newPosition;
				lastVelocity = newVelocity;

			} 

			if (frameNumber >= 8) {
				frameNumber = 0;
			} else {
				frameNumber++;
			}

		}
	}
}
