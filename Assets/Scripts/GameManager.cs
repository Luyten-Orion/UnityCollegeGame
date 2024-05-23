using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // The game manager, this is a singleton
    public static GameManager Instance { get; private set; }
    // The initial game speed
    public float InitialGameSpeed = 2.5f;
    // The rate of how quick the game speed increases
    public float GameSpeedIncreaseRate = 0.1f;
    // The current game speed
    public float GameSpeed { get; private set; }
    // Field that can be set if there's a game over
    public bool GameOver { get; set; }
    // Spawnable objects
    public GameObject[] SpawnableObjects;
    // Spawned objects
    private List<GameObject> spawnedObjects = new();
    // Random number generator
    private readonly System.Random rng = new();
    // Store a reference to the Canvas object
    private GameObject canvas;

    // On object creation, the `Awake` function is ran and sets the `Instance` if it is null
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            DestroyImmediate(gameObject);
        }
    }

    // On object destruction, the `OnDestroy` function is ran, and the `Instance` is set to null if it is the current obj
    private void OnDestroy() {
        if (Instance == this) {
            Instance = null;
        }
    }

    // The `Start` function is ran when the object is active
    public void Start() {
        GameSpeed = InitialGameSpeed;
        canvas = GameObject.Find("Canvas");
        canvas.SetActive(false);
    }

    // The `Update` function is ran every frame
    public void Update() {
        // Increment the game speed over time, or set it to 0 if there's a game over
        if (!GameOver) {
            GameSpeed += GameSpeedIncreaseRate * Time.deltaTime;

            List<GameObject> toRemove = new List<GameObject>();

            // Look through the list to see what needs to be removed.
            for (int i = 0; i < spawnedObjects.Count; i++) {
                Rigidbody2D rb = spawnedObjects[i].GetComponent<Rigidbody2D>();
                if (rb.position.x <= -14) {
                    toRemove.Add(spawnedObjects[i]);
                }
            }

            // Destroy the objects that are offscreen now.
            for (int i = 0; i < toRemove.Count; i++) {
                spawnedObjects.Remove(toRemove[i]);
                Destroy(toRemove[i]);
            }

            // Spawn a random object from the list
            if (spawnedObjects.Count == 0) {
                GameObject obj = Instantiate(SpawnableObjects[rng.Next(SpawnableObjects.Length)]);
                spawnedObjects.Add(obj);
            }
        } else {
            GameSpeed = 0;
            canvas.SetActive(true);
        }
    }
}
