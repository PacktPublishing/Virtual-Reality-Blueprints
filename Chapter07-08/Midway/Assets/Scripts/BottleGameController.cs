using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleGameController : MonoBehaviour {
	[SerializeField] GameObject BottlePyramidPrefab;
	[SerializeField] GameObject FiveBallsPrefab;

	private Vector3 PryamidPosition;
	private Quaternion PryamidRotation;
	private Vector3 BallsPosition;
	private Quaternion BallsRotation;

	// Use this for initialization
	void Start () {
		PryamidPosition = GameObject.FindWithTag("bottles").transform.position;
		PryamidRotation = GameObject.FindWithTag("bottles").transform.rotation;
		BallsPosition = GameObject.FindWithTag("balls").transform.position;
		BallsRotation = GameObject.FindWithTag("balls").transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Button.Two") || Input.GetButtonDown("Button.Four")) { 
			Destroy (GameObject.FindWithTag("bottles"));
			Destroy (GameObject.FindWithTag("balls"));

			GameObject BottlePryamids = Instantiate (BottlePyramidPrefab, PryamidPosition, PryamidRotation);
			GameObject FiveBalls = Instantiate (FiveBallsPrefab, BallsPosition, BallsRotation);

			BottlePryamids.tag = "bottles";
			FiveBalls.tag = "balls";
		}
	}
}
