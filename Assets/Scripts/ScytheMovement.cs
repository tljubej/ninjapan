﻿using UnityEngine;
using System.Collections;

public class ScytheMovement : MonoBehaviour {

    public Transform left;
    public Transform right;

    public float speed = 5.0f;

    private bool moveLeft_ = true;
    
    void Update()
    {
	Vector3 moveDirection = updateMoveDirection();
	transform.Translate(moveDirection * Time.deltaTime, Space.World);
    }

    private Vector3 updateMoveDirection()
    {
	Vector3 direction = Vector3.zero;
	
	if (moveLeft_) {
	    direction.x = left.position.x - transform.position.x;
	    if (transform.position.x <= left.position.x) {
		moveLeft_ = false;
	    }
	} else {
	    direction.x = right.position.x - transform.position.x;
            if (transform.position.x >= right.position.x) {
                moveLeft_ = true;
            }
        }
	direction.Normalize();
	return direction * speed;
    }
}