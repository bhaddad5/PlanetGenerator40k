using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
	private Vector2 prevMousePos;

	private const float rotSpeed = .2f;

	void Start()
	{
		prevMousePos = Input.mousePosition;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		var d = Input.GetAxis("Mouse ScrollWheel");
		transform.position += transform.forward * d;

		if (Input.GetKey(KeyCode.Mouse1))
		{
			Vector2 diff = (Vector2)Input.mousePosition - prevMousePos;

			transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), diff.x * rotSpeed);
			transform.RotateAround(Vector3.zero, transform.right, -diff.y * rotSpeed);
		}

		prevMousePos = Input.mousePosition;
	}
}
