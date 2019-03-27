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
		float heightSpeedAdjuster = Mathf.Min(Mathf.Max(transform.position.y, .4f), 10f);

		var d = Input.GetAxis("Mouse ScrollWheel") * heightSpeedAdjuster;
		transform.position += transform.forward * d;

		if (Input.GetKey(KeyCode.Mouse1))
		{
			Vector2 diff = (Vector2)Input.mousePosition - prevMousePos;

			transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), diff.x * rotSpeed);
			transform.RotateAround(Vector3.zero, transform.right, -diff.y * rotSpeed);
		}

		float wasdSpeed = .1f * heightSpeedAdjuster;

		Vector3 camFlatForward = transform.forward;
		camFlatForward.y = 0;

		if (Input.GetKey(KeyCode.W))
			transform.position += camFlatForward * wasdSpeed;
		if (Input.GetKey(KeyCode.A))
			transform.position -= transform.right * wasdSpeed;
		if (Input.GetKey(KeyCode.S))
			transform.position -= camFlatForward * wasdSpeed;
		if (Input.GetKey(KeyCode.D))
			transform.position += transform.right * wasdSpeed;

		prevMousePos = Input.mousePosition;
	}
}
