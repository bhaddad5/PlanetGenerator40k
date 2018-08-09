using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
	public Camera Camera;

	private Vector2 prevMousePos;

	private const float rotSpeed = .2f;

	void Start()
	{
		prevMousePos = Input.mousePosition;
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKey(KeyCode.Mouse1))
		{
			Vector2 diff = (Vector2)Input.mousePosition - prevMousePos;

			Camera.transform.RotateAround(transform.position, new Vector3(0, 1, 0), diff.x * rotSpeed);
			Camera.transform.RotateAround(transform.position, Camera.transform.right, -diff.y * rotSpeed);
		}

		prevMousePos = Input.mousePosition;
	}
}
