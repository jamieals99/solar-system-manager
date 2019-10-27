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
    Transform pauseMenu, gameUI, onStartUI, endUI;

    [SerializeField]
    Text timeText, pointText, matterText, createCost;

    private Text timerText;
    private float mainTimer;


    public static float timer;
    private bool canCount = true;
    private bool doOnce = false;
    private bool gameStartCheck = false;

    bool isPaused; // For determining pause state.

    // --- Start() ------------------------------------------------------------------------------------------- //

    void Start()
    {

        timer = mainTimer;
        pauseMenu.gameObject.SetActive(false); // Pause menu will be disabled on startup.
        gameUI.gameObject.SetActive(false);
        endUI.gameObject.SetActive(false);
        onStartUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
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
        pointText.text = "Score: " + Mathf.Round(ScoreTrigger.Score);
        matterText.text = "Matter: " + Mathf.Round(ResourceGeneration.resources);
        createCost.text = "Cost: " + Mathf.Round(PlanetManager.planetCost);

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && gameStartCheck) //If the esc key is pressed and the game isnt in a paused state run the Pause() function.
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused && gameStartCheck) //If the esc key is pressed and the game is in a paused state run the UnPause() function.
        {
            UnPause();
        }
    }

    // --- Pause() ------------------------------------------------------------------------------------------- //

    public void Pause()
    {
        isPaused = true;
        pauseMenu.gameObject.SetActive(true); // Enable the pause screen.
        gameUI.gameObject.SetActive(false);
        Time.timeScale = 0f; // Pause the game.
    }

    // --- UnPause() ----------------------------------------------------------------------------------------- //

    public void UnPause()
    {
        isPaused = false;
        pauseMenu.gameObject.SetActive(false); // Disable the pause screen.
        gameUI.gameObject.SetActive(true);
        UnPauseGame(); // Resume the game.
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
        resetData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // On call will load scene 0. ######## NEEDS TO BE CHANGED IF SCENE 0 IS NO LONGER THE GAMEPLAY SCENE #########
        UnPauseGame();
    }

    private void resetData()
    {
        ScoreTrigger.Score = 0;
        ResourceGeneration.resources = 0;
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadStartMenu()
    {
        resetData();
        SceneManager.LoadScene(0);
    }

    public void NameToGame()
    {
        onStartUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
        UnPauseGame();
    }
    
}