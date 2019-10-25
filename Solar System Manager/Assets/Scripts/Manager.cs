using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // --- Variable Declarations ----------------------------------------------------------------------------- //

    [SerializeField]
    Transform UIPanel; // Will assign panel to this variable so it can be enabled/disabled.

    [SerializeField]
    Text timeText; // Will assign time text to this variable so the text it displays can be modified.

    
    bool isPaused; // For determining pause state.

    // --- Start() ------------------------------------------------------------------------------------------- //

    void Start()
    {
        UIPanel.gameObject.SetActive(false); // Pause menu will be disabled on startup.
        isPaused = false; // Makes sure isPaused is false when the scene starts.
    }

    // --- Update() ------------------------------------------------------------------------------------------ //

    void Update()
    {
        timeText.text = "Time Since Startup: " + Mathf.Round(Time.timeSinceLevelLoad) + " seconds"; // Displays the time since the scene loaded.

        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused) //If the esc key is pressed and the game isnt in a paused state run the Pause() function.
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused) //If the esc key is pressed and the game is in a paused state run the UnPause() function.
        {
            UnPause();
        }

    }

    // --- Pause() ------------------------------------------------------------------------------------------- //

    public void Pause()
    {
        isPaused = true;
        UIPanel.gameObject.SetActive(true); // Enable the pause screen.
        Time.timeScale = 0f; // Pause the game.
    }

    // --- UnPause() ----------------------------------------------------------------------------------------- //

    public void UnPause()
    {
        isPaused = false;
        UIPanel.gameObject.SetActive(false); // Disable the pause screen.
        Time.timeScale = 1f; // Resume the game.
    }

    // --- QuitGame() ---------------------------------------------------------------------------------------- //

    public void QuitGame()
    {
        Application.Quit(); // On call will quit the application.
    }

    // --- Restart() ----------------------------------------------------------------------------------------- //

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // On call will load scene 0. ######## NEEDS TO BE CHANGED IF SCENE 0 IS NO LONGER THE GAMEPLAY SCENE #########
    }
}