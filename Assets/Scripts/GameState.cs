using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "gameState", menuName = "State/GameState")]
public class GameState : ScriptableObject
{
    public string playerName;

    public float timer;
    public KeyCode crouch = KeyCode.LeftShift;

    public float mouseSensitivity = 5000;

    public float startingMinutes = 29;
    public float startingSeconds = 59;

    public Vector3 currentSelection;
    public GameObject[] tiles;
    public GameObject[] tilesSolution;
    public GameObject emptyTile;
    public Vector3[] tilePositions;

    public List<GameObject> hotBar;

    public GameObject objectInHotbar;

    public int shift;

    public int previousScene;

    public List<string> leaderboard = new List<string>();
    public List<int> scores= new List<int>();
}
