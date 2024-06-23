using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    public GameState gameState;

    [SerializeField]
    public TextMeshProUGUI inputField;

    // Start is called before the first frame update
    void Start()
    {
        gameState.startingMinutes = 29;
        gameState.startingSeconds = 60;
        gameState.playerName = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.01f, 0);
    }

    public void StartButton()
    {
        if (! gameState.playerName.Equals(string.Empty))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            inputField.text = "Please input Player Username...";
        }
    }
    public void InputName(string inputString)
    {
        gameState.playerName = inputString;
    }
    public void SettingsButton()
    {
        gameState.previousScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(2);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
