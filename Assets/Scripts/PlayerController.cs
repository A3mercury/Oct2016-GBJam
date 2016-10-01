using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float jetPackSpeed = 50f;
	private float rotateSpeed = 10f;
	
	private Rigidbody2D playerRigidBody;

	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float vertical = Input.GetAxisRaw("Vertical");
		float horizontal = Input.GetAxisRaw("Horizontal");
		float shift = Input.GetAxisRaw("Shift");
		
		playerRigidBody.AddRelativeForce(Vector2.up * vertical * jetPackSpeed, ForceMode2D.Force);
		
		if (shift > 0) {
			playerRigidBody.AddRelativeForce(Vector2.right * horizontal * jetPackSpeed, ForceMode2D.Force);
		} else {
			playerRigidBody.AddTorque(-(horizontal) * rotateSpeed);
		}

	}
	
	public void AddGravity(Vector3 asteroidPosition, float gravity) {
		Vector2 direction = transform.position + asteroidPosition;
		playerRigidBody.AddForce(direction * gravity, ForceMode2D.Force);
	}
}
