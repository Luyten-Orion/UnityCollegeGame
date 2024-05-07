using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLogic : MonoBehaviour, GroundedCheck {
    // Store a property for if the slime is touching the ground
    public bool IsGrounded { get; set; }
    // Store a reference to the RigidBody2D
    private new Rigidbody2D rigidbody;
    // On object creation, the `Awake` function is ran.
    public void Awake() {
        // Get a reference to the object's RigidBody2D
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update() {
        // Check if the game is not over
        if (!GameManager.Instance.GameOver) {
            // Set the RigidBody2D's velocity
            rigidbody.velocity = new Vector2(-GameManager.Instance.GameSpeed, rigidbody.velocity.y);

            if (IsGrounded) {
                // If the slime is touching the ground, make it jump
                rigidbody.AddRelativeForce(Vector2.up * 60f);
            }
        }
    }

    // C# has some odd behaviour when it comes to superclasses and interfaces defining the same method,
    // so we manually call the interface's implementation.
    void OnCollisionStay2D(Collision2D collision) { ((GroundedCheck)this).OnCollisionStay2D(collision); }
    void OnCollisionExit2D(Collision2D collision) { ((GroundedCheck)this).OnCollisionExit2D(collision); }
}
