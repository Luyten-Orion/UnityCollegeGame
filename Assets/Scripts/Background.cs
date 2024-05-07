using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    // The meshRenderer field allows us to avoid repetitive code.
    private MeshRenderer meshRenderer;
    // Save the MeshRenderer to the meshRenderer field
    public void Awake() {
        // Get the MeshRenderer component of the object this script is attached to
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Scroll the background accordingly
    public void Update() {
        float offset = GameManager.Instance.GameSpeed / transform.localScale.x;
        // Change the offset to scroll the background
        meshRenderer.material.mainTextureOffset += Vector2.right * offset * Time.deltaTime;
    }
}
