using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}
public class GamerControllar : MonoBehaviour {
	public float speed;
	public float turnSpeed;
	public GameObject shot;
	public Transform shotSpawn;
	// public float tilt;
	public float fireRate;
	private float nextFire;
	public GameObject playerExplosion;
	public GameObject partExplosion;
	public Boundary boundary;

	public int HP;
//	public GameController controller;
	// Use this for initialization
	void Start () {
//		HPStrip.value = HPStrip.maxValue = HP;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space") && Time.time>nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}

	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		// Turning
		if (moveHorizontal != 0)
		{
			transform.Rotate(new Vector3(0.0f, moveHorizontal * turnSpeed, 0.0f));
		}
		// Forward or backwards
		if (moveVertical != 0)
		{
			Vector3 fwd = transform.forward;
			GetComponent<Rigidbody>().velocity = fwd * speed * moveVertical;
		}
		GetComponent<Rigidbody>().position = new Vector3(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			2.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

	}
	// void OnTriggerEnter(Collider other)
	// 	{

	// 		if (other.tag == "bolt2")
	// 		{
	// 			HP -= 1;
	// 			HPStrip.value = HP;
	// 			if(HPStrip.value !=0)
	// 			{
	// 				Instantiate(partExplosion, transform.position, transform.rotation);
	// 			}
	// 			if (HPStrip.value == 0)
	// 			{

	// 				Destroy(other.gameObject);
	// 				Destroy(gameObject);
	// 				Instantiate(playerExplosion, transform.position, transform.rotation);
	// 				controller.EndGame();
	// 			}      
	// 		}
	// 	}
}
