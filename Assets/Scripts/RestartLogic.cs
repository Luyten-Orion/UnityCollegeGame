using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLogic : MonoBehaviour {
    public void OnRestartButton() {
        SceneManager.LoadScene("MainGame");
    }

    public void OnExitButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
