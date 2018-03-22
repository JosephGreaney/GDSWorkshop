using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Data
    [SerializeField] private float speed = 10;

    private bool jumping;
    private float jumpSpeed = 200;
    private Rigidbody2D body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        jumping = false;
	}
	// Update is called once per frame
	void Update () {
        // Get input.
        float hInput = Input.GetAxis("Horizontal");
        bool jumpPressed = Input.GetButtonDown("Jump");
        if(jumpPressed && !jumping) {
            jumping = true;
            body.AddForce(Vector2.up * jumpSpeed);
        }
        Vector2 moveForce = new Vector2(hInput, 0);
        body.AddForce(moveForce * speed);
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.CompareTag("Floor")) {
            jumping = false;
        }
    }
}
