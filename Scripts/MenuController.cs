using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject creditCanvas;

    private void Start() {
        menuCanvas.SetActive(true);
        creditCanvas.SetActive(false);
    }

    public void startGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void openCredits() {
        menuCanvas.SetActive(false);
        creditCanvas.SetActive(true);
    }

    public void backToMenu() {
        menuCanvas.SetActive(true);
        creditCanvas.SetActive(false);
    }

    public void exitGame() {
        Application.Quit();
    }
}
