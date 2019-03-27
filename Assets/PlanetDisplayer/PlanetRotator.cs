using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
	public float RotationSpeed = 1f;

	// Update is called once per frame
	void FixedUpdate ()
	{
		transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
	}
}
