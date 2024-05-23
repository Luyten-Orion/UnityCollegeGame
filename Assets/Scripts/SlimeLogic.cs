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

    // The `FixedUpdate` function is ran every physics frame, so we use it to
    // modify the physics of the slime
    public void FixedUpdate() {
        // Set the RigidBody2D's velocity
        if (!GameManager.Instance.GameOver) {
            // Set the RigidBody2D's velocity
            if (IsGrounded) {
                // If the slime is touching the ground, make it jump
                rigidbody.AddRelativeForce(Vector2.up * 200f);
            }
            rigidbody.velocity = new Vector2(-GameManager.Instance.GameSpeed, rigidbody.velocity.y);
        }
    }

    // C# has some odd behaviour when it comes to superclasses and interfaces defining the same method,
    // so we manually call the interface's implementation.
    void OnCollisionStay2D(Collision2D collision) { ((GroundedCheck)this).OnCollisionStay2D(collision); }
    void OnCollisionExit2D(Collision2D collision) { ((GroundedCheck)this).OnCollisionExit2D(collision); }
}
