using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// To add:
/// - Have when escape is pressed to go out of the pause menu the game should return
///     to the last game speed that was pressed. 
/// </summary>

public class Manager : MonoBehaviour
{
    // --- Variable Declarations ----------------------------------------------------------------------------- //

    [SerializeField]
    Transform UIPanel; // Will assign panel to this variable so it can be enabled/disabled.

    [SerializeField]
    Text timeText; // Will assign time text to this variable so the text it displays can be modified.

    [SerializeField]
    Text pointText; // Will be used to assign the points-txt to this script.

    //int totalScore = ScoreTrigger.planetScore + MoonScoreTrigger.moonScore;

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
        pointText.text = "Points: " + (ScoreTrigger.planetScore + MoonScoreTrigger.moonScore);

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused) //If the esc key is pressed and the game isnt in a paused state run the Pause() function.
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused) //If the esc key is pressed and the game is in a paused state run the UnPause() function.
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

    // --- PauseGame() --------------------------------------------------------------------------------------- //

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    // --- UnPauseGame() ------------------------------------------------------------------------------------- //

    public void UnPauseGame()
    {
        Time.timeScale = 1f;
    }

    // --- DoubleSpeed() ------------------------------------------------------------------------------------- //

    public void DoubleSpeed()
    {
        Time.timeScale = 2f;
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