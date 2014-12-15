using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Moving speed
    public float speed = 6.0f;
    // Jumping speed
    public float jumpSpeed = 8.0f;
    // Falling speed
    public float gravity = 20.0f;

    public GameObject shurikenPrefab;
    public Transform shurikenSpawn;
    public float throwStrength = 10.0f;
    public float climbSpeed = 2.0f;
    public float climbOffset = 1.0f;
    
    private CharacterController controller_;
    // Current move direction
    private Vector3 moveDirection_ = Vector3.zero;
    // Last trigger spawn point
    private Vector3 activeSpawnPoint_ = Vector3.zero;

    // Last available grab point
    private Vector3 grabPoint_ = Vector3.zero;

    private bool isClimbing_ = false;
    private bool startedClimbing_ = false;
    
    void Awake()
    {
        controller_ = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller_.isGrounded) {
            moveDirection_ = updateMoveDirection();
        } else {
            float v = Input.GetAxis("Vertical");
            if (v > 0.0f && grabPoint_ != Vector3.zero) {
                isClimbing_ = true;
            } else if (isClimbing_ && v <= 0.0f) {
                isClimbing_ = false;
            }
        }
        if (Input.GetButtonDown("Fire1" && !isClimbing_)) {
            throwShuriken();
        }
        // Climbing overrides other movement.
        if (isClimbing_) {
            moveDirection_ = Vector3.zero;
            if (!startedClimbing_) {
                startedClimbing_ = true;
                StartCoroutine(climb());
            }
        } else {
            moveDirection_.y -= gravity * Time.deltaTime;
            CollisionFlags collisionFlags =
                controller_.Move(moveDirection_ * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag) {
            case TagManager.spikes:
                dieBySpikes();
                break;
            case TagManager.spawnPoint:
                activateSpawnPoint(other.transform.position);
                break;
            case TagManager.scythe:
                dieByScythe();
                break;
            case TagManager.grabPoint:
                grabPoint_ = other.transform.position;
                break;
            default:
                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == TagManager.grabPoint) {
            grabPoint_ = Vector3.zero;
        }
    }
    
    /// <summary>
    ///   Handles input for basic movement (running and jumping).
    /// </summary>
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

    private IEnumerator climb()
    {
        Debug.Log("Climbing.");
        Vector3 endPoint = new Vector3(grabPoint_.x, grabPoint_.y + climbOffset, 0.0f);
        transform.position = new Vector3(endPoint.x, transform.position.y, 0.0f);
        while (isClimbing_ && transform.position.y < endPoint.y) {
            float delta = endPoint.y - transform.position.y;
            transform.position += Vector3.up * Mathf.Min(delta, climbSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.0f);
        }
        isClimbing_ = false;
        startedClimbing_ = false;
        Debug.Log("DoneClimbing.");
    }
    
    /// <summary>
    ///   Handles triggering of spike trap and runs death animation.
    /// </summary>
    private void dieBySpikes()
    {
        Debug.Log("died by spikes");
        transform.position = activeSpawnPoint_;
    }

    private void dieByScythe()
    {
        Debug.Log("died by scythe");
    }
    
    /// <summary>
    ///   Sets the new active spawn point.
    /// </summary>
    private void activateSpawnPoint(Vector3 position)
    {
	activeSpawnPoint_ = position;
    }

    private void throwShuriken()
    {
        Object shuriken = Instantiate(shurikenPrefab, shurikenSpawn.position, shurikenSpawn.rotation);
        Rigidbody rb = (shuriken as GameObject).rigidbody;
        rb.AddRelativeForce(Vector3.right * throwStrength);
    }
}
