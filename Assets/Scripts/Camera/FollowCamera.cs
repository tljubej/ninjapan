using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    public Transform target;
    // Default distance variable - same as the distance in start
    public float defaultDistance = 10.0f;
    // Default angle around X axis (how close is camera to ground)
    public float defaultAngleX = 15.0f;
    // Camera move speed
    public float moveSpeed = 5.0f;
    
    // Current distance to target
    private float distance_ = 6.0f;
    // New distance camera needs to move to.
    private float newDistance_;
    // Current angle around X axis
    private float angleX_ = 0.0f;
    // New angle around X axis the camera needs to move to.
    private float newAngleX_;
    // Angle around Y axis (mouse driven)
    private float angleY_ = 0.0f;
    // New angle around Y axis the camera needs to move to.
    private float newAngleY_ = 0.0f;

    // Use this for initialization
    void Start()
    {
        angleX_ = defaultAngleX;
        distance_ = defaultDistance;
        newDistance_ = defaultDistance;
        newAngleX_ = defaultAngleX;	
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    void LateUpdate()
    {
	if (target)
        {
            cameraSmoothTransition();
            Quaternion rot = Quaternion.Euler(angleX_, angleY_, 0);
            Vector3 pos = rot * new Vector3(0, 0, -distance_) + target.position;
            transform.rotation = rot;
            transform.position = pos;
        }
    }

    /// <summary>
    /// Smoothly transition camera to new position.
    /// </summary>
    private void cameraSmoothTransition()
    {
        float speed = Time.deltaTime * moveSpeed;
        angleX_ = Mathf.LerpAngle(angleX_, newAngleX_, speed);
        angleY_ = Mathf.LerpAngle(angleY_, newAngleY_, speed);
        distance_ = Mathf.Lerp(distance_, newDistance_, speed);
    }
}
