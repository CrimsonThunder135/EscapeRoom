using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI timer;
    [SerializeField]
    public GameState gameState;
    [SerializeField]
    public TextMeshPro cipherText;
    [SerializeField]
    public GameObject cipherScroll;

    public int[] randomTime = new int[3];
    GameObject[] clocks;
    private void Awake()
    {
        gameState.timer = 30;
        randomTime[0] = Random.Range(1, 13);
        randomTime[1] = Random.Range(0, 60);
        randomTime[2] = Random.Range(0, 60);
    }


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }

        gameState.shift = Random.Range(-3,4);

        while(gameState.shift == 0)
        {
            gameState.shift = Random.Range(-3, 4);
        }

        gameState.emptyTile = GameObject.Find("EmptyTile").gameObject;
        gameState.hotBar.Clear();

        clocks = GameObject.FindGameObjectsWithTag("Clock");

        int randomClock = Random.Range(0, clocks.Length);

        Clock clueClock = clocks[randomClock].gameObject.GetComponentInChildren<Clock>();
        clueClock.realTime = false;
        clueClock.clockSpeed = 0;

        clueClock.hour = randomTime[0];
        clueClock.minutes = randomTime[1];
        clueClock.seconds = randomTime[2];

        if (gameState.shift < 0)
        {
            cipherScroll.GetComponent<CollectableObjectScript>().note = "Shift " + Mathf.Abs(gameState.shift) + " forward";
        }
        if (gameState.shift > 0)
        {
            cipherScroll.GetComponent<CollectableObjectScript>().note = "Shift " + Mathf.Abs(gameState.shift) + " backwards";
        }

        string decoded = "WHAT TIME ISN'T IT?";

        string encoded = "";

        for(int i = 0; i < decoded.Length; i++)
        {
            if ((decoded[i] >= 'A' & decoded[i] <= 'Z'))
            {
                if ((decoded[i] + gameState.shift) < 'A')
                {
                    encoded = encoded + (char)(decoded[i] + gameState.shift + ('Z' - 'A') + 1);
                }
                else if ((decoded[i] + gameState.shift) > 'Z')
                {
                    encoded = encoded + (char)(decoded[i] + gameState.shift - ('Z' - 'A') - 1);
                }
                else
                {
                    encoded = encoded + (char)(decoded[i] + gameState.shift);
                }
            }
            else
            {
                encoded = encoded + (char)(decoded[i]);
            }
        }

        cipherText.text = encoded;
    }

    // Update is called once per frame
    void Update()
    {
        float minutesRemaining = gameState.startingMinutes - Mathf.Floor(Time.timeSinceLevelLoad / 60);
        float secondsRemaining = gameState.startingSeconds - Mathf.Ceil(Time.timeSinceLevelLoad % 60);

        if (secondsRemaining < 10)
        {
            timer.text = "" + minutesRemaining + ":0" + secondsRemaining;
        }
        else
        {
            timer.text = "" + minutesRemaining + ":" + secondsRemaining;
        }


        if (minutesRemaining <= 0 & secondsRemaining <= 0)
        {
            SceneManager.LoadScene(4);
            gameState.leaderboard.Add(gameState.playerName);
            gameState.scores.Add(-1);
        }
    }
}
