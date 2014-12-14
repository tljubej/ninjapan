using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Moving speed
    public float speed = 6.0f;
    // Jumping speed
    public float jumpSpeed = 8.0f;
    // Falling speed
    public float gravity = 20.0f;

    private CharacterController controller_;

    private Vector3 moveDirection_ = Vector3.zero;
    
    void Awake()
    {
        controller_ = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
	if (controller_.isGrounded) {
	    moveDirection_ = updateMoveDirection();
	}
	moveDirection_.y -= gravity * Time.deltaTime;
        CollisionFlags collisionFlags = controller_.Move(moveDirection_ * Time.deltaTime);
    }

    private Vector3 updateMoveDirection()
    {
        float h = Input.GetAxis("Horizontal");
	Vector3 moveDirection = (Vector3.right * h).normalized;
	moveDirection.x  *= speed;
	if (Input.GetButton("Jump")) {
	    moveDirection.y = jumpSpeed;
	}
	return moveDirection;
    }
}
