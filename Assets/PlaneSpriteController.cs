﻿using UnityEngine;
using System.Collections;

public class PlaneSpriteController : MonoBehaviour {
	public float maxHorizontalSpeed;
	public float maxVerticalSpeed;

	private float xBound = 20f; //horizontal bound of plane
	private float yBound = 20f;
	private float verticalSpeed = 0; //Move plane up & down speed
	private float horizontalSpeed = 0; // Move plane left & right speed

	private Rigidbody2D plane;

	void Awake() {
		Application.targetFrameRate = 300;
	}

	void HorizontalInputHandler(float a){
		if (a > 0 && transform.localPosition.x < xBound) {
			horizontalSpeed = maxHorizontalSpeed;
			//transform.Rotate(Vector3.right * Time.deltaTime * -horizontalRotateSpeed);
		}
		else if (a < 0 && transform.localPosition.x > -xBound )
			horizontalSpeed = -maxHorizontalSpeed;
		else
			horizontalSpeed = 0;
	}

	
	void VerticalInputHandler(float b){
		if (b > 0 && transform.position.y < yBound) {
			verticalSpeed = maxVerticalSpeed;
			Debug.Log("vertical input");
			//transform.Rotate(Vector3.right * Time.deltaTime * -horizontalRotateSpeed);
		}
		else if (b < 0 && transform.position.y > -yBound )
			verticalSpeed = -maxVerticalSpeed;
		else
			verticalSpeed = 0;
	}


	// Use this for initialization
	void Start () {
		plane = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float a = Input.GetAxisRaw  ("Horizontal") ;
		HorizontalInputHandler (a);

		float b = Input.GetAxisRaw("Vertical");
		VerticalInputHandler (b);

		plane.AddForce(Vector2.right * horizontalSpeed) ;//Move plane horizontally 
		plane.AddForce(Vector2.up * verticalSpeed) ;//Move plane horizontally 

	}

	void Update(){

	}
}