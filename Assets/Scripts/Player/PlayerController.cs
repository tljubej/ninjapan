using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Moving speed
    public float runSpeed = 6.0f;
    public float crouchSpeed = 2.0f;
    // Jumping speed
    public float jumpSpeed = 8.0f;
    // Falling speed
    public float gravity = 20.0f;

    public GameObject shurikenPrefab;
    public Transform shurikenSpawn;
    public float shurikenDelay = 0.2f;
    public float shurikenCooldown = 1.0f;
    public float throwStrength = 10.0f;
    public float climbSpeed = 2.0f;
    public float climbEndOffset = 1.4f;
    public float climbStartOffset = 1.6f;

    private Animator animator_;
    private CharacterController controller_;
    // Current move direction
    private Vector3 moveDirection_ = Vector3.zero;
    // Last trigger spawn point
    private Vector3 activeSpawnPoint_ = Vector3.zero;

    // Last available grab point
    private Transform grabPoint_ = null;

    private bool isClimbing_ = false;
    private bool startedClimbing_ = false;
    private bool isJumping_ = false;
    private bool isCrouching_ = false;
    private bool isDead_ = false;
    private float currentShurikenTime_ = 0.0f;
    
    void Awake()
    {
        controller_ = GetComponent<CharacterController>();
        animator_ = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead_) {
            handleInputs();
        } else {
            moveDirection_.x = 0.0f;
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
            if (moveDirection_.x > 0.0f) {
                transform.rotation = Quaternion.LookRotation(Vector3.forward);
            } else if (moveDirection_.x < 0.0f) {
                transform.rotation = Quaternion.LookRotation(-Vector3.forward);
            }
        }
        animator_.SetFloat("Speed", Mathf.Abs(moveDirection_.x));
    }

    void handleInputs()
    {
        float v = Input.GetAxis("Vertical");
        if (controller_.isGrounded) {
            if (isJumping_) {
                isJumping_ = false;
                animator_.SetTrigger("Landed");
            }
            moveDirection_ = updateMoveDirection();
            if (v < 0.0f) {
                if (!isCrouching_) {
                    crouch();
                }
                isCrouching_ = true;
            } else if (isCrouching_){
                isCrouching_ = false;
                uncrouch();
            }
            animator_.SetBool("Crouch", isCrouching_);
        }
        if (v > 0.0f && grabPoint_) {
            isClimbing_ = true;
        }
        currentShurikenTime_ = Mathf.Max(0.0f,currentShurikenTime_ - Time.deltaTime);
        if (Input.GetButtonDown("Fire1") && !isClimbing_ && !isCrouching_
            && controller_.isGrounded && currentShurikenTime_ <= 0.0f) {
            currentShurikenTime_ = shurikenCooldown;
            animator_.SetTrigger("Throw");
            Invoke("throwShuriken", shurikenDelay);
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
                grabPoint_ = other.transform;
                break;
            default:
                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == TagManager.grabPoint) {
            grabPoint_ = null;
        }
    }
    
    /// <summary>
    ///   Handles input for basic movement (running and jumping).
    /// </summary>
    private Vector3 updateMoveDirection()
    {
        float h = Input.GetAxis("Horizontal");
        Vector3 moveDirection = (Vector3.right * h).normalized;
        float speed = isCrouching_ ? crouchSpeed : runSpeed;
        moveDirection.x  *= speed;
        if (Input.GetButton("Jump")) {
            moveDirection.y = jumpSpeed;
            animator_.SetTrigger("Jump");
            isJumping_ = true;
        }
        return moveDirection;
    }

    private IEnumerator climb()
    {
        Debug.Log("Climbing.");
        Transform gp = grabPoint_;
        float gpx = gp.position.x;
        float gpy = gp.position.y;
        Vector3 endPoint = new Vector3(gpx, gpy + climbEndOffset, 0.0f);
        transform.position = new Vector3(endPoint.x, gpy - climbStartOffset, 0.0f);
        animator_.SetTrigger("Climb");
        transform.rotation = Quaternion.LookRotation(-gp.forward);
        while (isClimbing_ && transform.position.y < endPoint.y) {
            float delta = endPoint.y - transform.position.y;
            transform.position += Vector3.up * Mathf.Min(delta, climbSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.0f);
        }
        transform.position += transform.right * 0.2f;
        isClimbing_ = false;
        startedClimbing_ = false;
        isJumping_ = false;
        animator_.ResetTrigger("Jump");
        animator_.ResetTrigger("Landed");
        Debug.Log("DoneClimbing.");
    }

    private void crouch()
    {
        CharacterController capsule = collider as CharacterController;
        capsule.height -= 0.6f;
    }

    private void uncrouch()
    {
        transform.position += Vector3.up * 0.6f;
        CharacterController capsule = collider as CharacterController;
        capsule.height += 0.6f;
    }
    
    /// <summary>
    ///   Handles triggering of spike trap and runs death animation.
    /// </summary>
    private void dieBySpikes()
    {
        Debug.Log("died by spikes");
        if (isDead_) {
            return;
        }
        animator_.Play("Death");
        Invoke("LowerPosition", 0.7f);
        Invoke("restartLevel", 4.0f);
        isDead_ = true;
    }

    private void dieByScythe()
    {
        Debug.Log("died by scythe");
        if (isDead_) {
            return;
        }
        animator_.Play("Death");
        Invoke("LowerPosition", 0.7f);
        Invoke("restartLevel", 4.0f);
        isDead_ = true;
    }

    private void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    
    void LowerPosition()
    {
        CharacterController capsule = collider as CharacterController;
        capsule.height = 0.6f;
        capsule.center = Vector3.up * 0.5f;
    }

    void RaisePosition()
    {
        CharacterController capsule = collider as CharacterController;
        capsule.height = 1.3f;
        capsule.center = Vector3.up * 0.1f;
        transform.position += Vector3.up * 2.0f;
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
