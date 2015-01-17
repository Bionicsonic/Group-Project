using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	//Press Ctrl + ' to find the definiton or meaning of things
	public float speed = 6.0F; //You can see these in the Inspector
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;

	void Update() {
		CharacterController controller = GetComponent<CharacterController>(); //When something says GetComponent<x> then <x> must be applied
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //There are two types of GetAxis(Raw)
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}