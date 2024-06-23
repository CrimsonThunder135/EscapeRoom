using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DicePuzzleScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshPro redCount;
    [SerializeField]
    public TextMeshPro blueCount;
    [SerializeField]
    public TextMeshPro whiteCount;

    [SerializeField]
    public GameObject redDie;
    [SerializeField]
    public GameObject blueDie;
    [SerializeField]
    public GameObject whiteDie;


    [SerializeField]
    private UnityEvent onPuzzleSolved;
    public UnityEvent OnPuzzleSolved => onPuzzleSolved;

    bool solved;

    // Start is called before the first frame update
    void Start()
    {
        solved = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (redCount.text.Equals(redDie.GetComponent<DieScript>().value.ToString()) & 
            blueCount.text.Equals(blueDie.GetComponent<DieScript>().value.ToString()) & 
            whiteCount.text.Equals(whiteDie.GetComponent<DieScript>().value.ToString()))
        {
            if (!solved)
            {
                solved = true;
                PuzzleSolved();
            }
        }
    }


    void PuzzleSolved()
    {
        onPuzzleSolved?.Invoke();
    }
}
