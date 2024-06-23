using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    bool isOpen = false;

    [SerializeField]
    public GameState gameState;

    [SerializeField]
    public Vector3 openPosition;
    [SerializeField]
    public Quaternion openRotation;
    [SerializeField]
    public Quaternion closedRotation;

    public void Open()
    {
        if(!isOpen)
        {
            isOpen = true;
            switch (gameObject.tag)
            {
                case "FullSize":
                    transform.localRotation = openRotation;
                    break;
                case "LockedCabinetDoor":
                    transform.localRotation = openRotation;
                    break;
                case "CabinetDoor":
                    transform.localRotation = openRotation;
                    break;
                case "Drawer":
                    transform.localPosition = transform.localPosition + openPosition;
                    break;
                case "FinalDoor":
                    SceneManager.LoadScene(3);
                    gameState.leaderboard.Add(gameState.playerName);
                    gameState.scores.Add((int) Mathf.Floor(Time.timeSinceLevelLoad));
                    break;
                default:
                    break;
            }
        }
        else
        {
            isOpen = false;
            switch (gameObject.tag)
            {
                case "CabinetDoor":
                    transform.localRotation = closedRotation;
                    break;
                case "Drawer":
                    transform.localPosition = transform.localPosition - openPosition;
                    break;
                default:
                    break;
            }
        }
    }
}
