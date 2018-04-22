using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prototype : MonoBehaviour {

    public int playerSpeed = 7;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    void PlayerMove() {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump")) {
            jump();
        }

        // ANIMATIONS
        // PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false) {
            flipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true) {
            flipPlayer();
        }

        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void jump() {
        // JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }

    void flipPlayer() {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
