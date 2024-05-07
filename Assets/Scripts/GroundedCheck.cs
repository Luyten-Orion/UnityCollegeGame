using UnityEngine;

// This is an interface that allows objects to share code related to touching the ground
public interface GroundedCheck {
    // Store if the object is touching the ground
    public bool IsGrounded { get; set; }

    // Check if the object is touching the ground
    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            IsGrounded = true;
        }
    }

    // Check if the object is no longer touching the ground
    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            IsGrounded = false;
        }
    }
}