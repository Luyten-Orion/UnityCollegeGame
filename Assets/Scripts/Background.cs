using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    // The meshRenderer field allows us to avoid repetitive code.
    private MeshRenderer meshRenderer;
    // Cached local scale to reduce calls
    private float localScaleX;
    // Save the MeshRenderer to the meshRenderer field
    public void Awake() {
        // Get the MeshRenderer component of the object this script is attached to
        meshRenderer = GetComponent<MeshRenderer>();
        localScaleX = transform.localScale.x;
    }

    // Scroll the background accordingly
    public void Update() {
        float offset = GameManager.Instance.GameSpeed / localScaleX;
        // Change the offset to scroll the background
        meshRenderer.material.mainTextureOffset += Vector2.right * offset * Time.deltaTime;
    }
}
