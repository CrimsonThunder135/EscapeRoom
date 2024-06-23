using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndScript : MonoBehaviour
{
    [SerializeField]
    public GameState gameState;
    [SerializeField]
    public TextMeshProUGUI namesList;
    [SerializeField]
    public TextMeshProUGUI scoresList;

    // Start is called before the first frame update
    void Start()
    {
        namesList.text = null;
        scoresList.text = null;

        foreach (var name in gameState.leaderboard)
        {
            namesList.text = namesList.text + name + "\n";
        }

        foreach (var score in gameState.scores)
        {
            if(score == -1)
            {
                scoresList.text = scoresList.text + "DNF";
            }

            if(score % 60 >= 10)
            {
                scoresList.text = scoresList.text + "Time: " + score / 60 + ":" + score % 60 + "\n";
            }
            else
            {
                scoresList.text = scoresList.text + "Time: " + score / 60 + ":0" + score % 60 + "\n";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
