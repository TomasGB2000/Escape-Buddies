using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	PlayerInput playerInput;
	Vector2 move;
	Vector2 rotate;
	float run;
	float jumpStarted;
	public float walkSpeed = 5f;
	public float runSpeed = 10f;
	public Camera playerCamera;
	Vector3 CameraRotation;

	private void OnEnable()
	{
		playerInput.Player.Enable();
	}

	private void OnDisable()
	{
		playerInput.Player.Enable();
	}

	private void Awake()
	{
		playerInput = new PlayerInput();

		playerInput.Player.Jump.performed += ctx => Jump();

		playerInput.Player.Run.performed += ctx => run = runSpeed;
		playerInput.Player.Run.canceled += ctx => run = walkSpeed;

		playerInput.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
		playerInput.Player.Move.canceled += ctx => move = Vector2.zero;

		playerInput.Player.Look.performed += ctx => rotate = ctx.ReadValue<Vector2>();
		playerInput.Player.Look.canceled += ctx => rotate = Vector2.zero;
	}

	private void Jump()
    {
		if(jumpStarted +1f < Time.time)
        {
			jumpStarted = Time.time;
        }
    }

    void Start()
    {
		run = walkSpeed;
		CameraRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
		jumpStarted = -1f;
		Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
		CameraRotation = new Vector3(CameraRotation.x + rotate.y, CameraRotation.y + rotate.x, CameraRotation.z);

		playerCamera.transform.eulerAngles = CameraRotation;
		transform.eulerAngles = new Vector3(transform.rotation.x, CameraRotation.y, transform.rotation.z);

		transform.Translate(Vector3.right * Time.deltaTime * move.x * run, Space.Self);
		transform.Translate(Vector3.forward * Time.deltaTime * move.y * run, Space.Self);

		if(jumpStarted + 0.5f > Time.time)
        {
			transform.Translate((Vector3.up * 8f * Time.deltaTime), Space.Self);
        }
		else if(jumpStarted + 1f > Time.time)
        {
			transform.Translate((Vector3.up * -8f * Time.deltaTime), Space.Self);
		}
	}
}
