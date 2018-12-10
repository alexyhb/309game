using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllar : MonoBehaviour {


	public GameObject player;
	public float rotationDamping;
	public float distance;
	public float height;
	// Use this for initialization
	void Start()
	{
	}
	// Update is called once per frame
	void Update()
	{

	}
	void LateUpdate()
	{
		float wantedRotationAngle = player.transform.eulerAngles.y;
		float currentRotationAngle = transform.eulerAngles.y;
		// Damp the rotation around the Y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle,
			rotationDamping * Time.deltaTime);
		// Convert the angle into a quaternion
		Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
		// Set the (x,z) camera position based on where the player is
		transform.position = player.transform.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		// Set the height (y) of the camera
		Vector3 newPosition = new Vector3(transform.position.x, height, transform.position.z);
		transform.position = newPosition;
		// Look at the player
		transform.LookAt(player.transform);
	}
}
