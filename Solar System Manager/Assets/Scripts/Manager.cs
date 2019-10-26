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

    [SerializeField] Transform UIPanel; // Will assign panel to this variable so it can be enabled/disabled.

    [SerializeField] Text timeText; // Will assign time text to this variable so the text it displays can be modified.

    [SerializeField] Text pointText; // Will be used to assign the points-txt to this script.

    [SerializeField] private Text timerText;

    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;


    bool isPaused; // For determining pause state.

    // --- Start() ------------------------------------------------------------------------------------------- //

    void Start()
    {
        timer = mainTimer;
        UIPanel.gameObject.SetActive(false); // Pause menu will be disabled on startup.
        isPaused = false; // Makes sure isPaused is false when the scene starts.
    }

    // --- Update() ------------------------------------------------------------------------------------------ //

    void Update()
    {   


        if (timer>= 0.0f&& canCount)
        {
            timer -= Time.deltaTime;
            timerText.text = "Timer: " + Mathf.Round(timer);//.ToString("F");
        }

        else if (timer<= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            timerText.text = "0.00f";
            timer = 0.0f;
        }

        timeText.text = "Time Since Startup: " + Mathf.Round(Time.timeSinceLevelLoad) + " seconds"; // Displays the time since the scene loaded.
        pointText.text = "Score: " + (ScoreTrigger.planetScore + MoonScoreTrigger.moonScore);

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