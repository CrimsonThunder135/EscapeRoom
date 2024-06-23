using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    public GameState gameState;
    [SerializeField]
    public TextMeshProUGUI sensitivityText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.01f, 0);
    }

    public void UpdateSensitivity(float sensitivity)
    {
        gameState.mouseSensitivity = sensitivity * 100;
        sensitivityText.text = sensitivity.ToString();
    }

    public void UpdateCrouch(int newKey)
    {
        if (newKey == 1)
        {
            gameState.crouch = KeyCode.LeftControl;
        }
        else
        {
            gameState.crouch = KeyCode.LeftShift;
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene(gameState.previousScene);
    }
}
