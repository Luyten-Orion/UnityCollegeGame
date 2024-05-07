using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, GroundedCheck {
    // Use a property to store if a player is touching the ground
    public bool IsGrounded { get; set; }
    // Store the RigidBody2D component used for player positions
    private Rigidbody2D rigidBody;
    // How much force a jump will apply
    private float JumpForce = 1000f;
    // How much force clicking down will apply
    private float DropForce = 100f;

    // On the object's initialisation, the `Awake` function is ran
    void Awake() {
        // Get a reference to the player's RigidBody2D
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // The `Update` function is ran every physics frame
    void Update() {
        if (IsGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector2.up * JumpForce);
        }

        if (!IsGrounded && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))) {
            rigidBody.AddRelativeForce(Vector2.down * DropForce);
        }
    }

    // Call the interface's implementation and add our own custom behaviour too
    void OnCollisionStay2D(Collision2D collision) {
        ((GroundedCheck) this).OnCollisionStay2D(collision);

        if (collision.gameObject.CompareTag("Enemy")) {
            GameManager.Instance.GameOver = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision) { ((GroundedCheck) this).OnCollisionExit2D(collision); }
}
