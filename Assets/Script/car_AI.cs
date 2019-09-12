using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_AI : MonoBehaviour {

	public Transform path;
	public float maxSteerAngle = 45f;
	public WheelCollider wheelfl;
	public WheelCollider wheelfr;
	private List<Transform> nodes;
	private int currentNode = 0;
	// Use this for initialization
	void Start () {
		Transform[] pathTransform = path.GetComponentsInChildren<Transform> ();
		nodes = new List<Transform> ();

		for (int i = 0; i < pathTransform.Length; i++) {
			if (pathTransform [i] != path.transform)
				nodes.Add (pathTransform [i]);
		}	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ApplySteer ();	
		Drive ();
	}

	private void ApplySteer(){
		Vector3 relativeVector = transform.InverseTransformPoint (nodes [currentNode].position);
		relativeVector /= relativeVector.magnitude;
		float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
		wheelfl.steerAngle = newSteer;
		wheelfr.steerAngle = newSteer;
	}

	public void Drive(){
		wheelfl.motorTorque = 10f;
		wheelfr.motorTorque = 10f;
	}
}
