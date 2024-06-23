using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PianoScript : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] 
    private UnityEvent onPianoSolved;
    public UnityEvent OnPianoSolved => onPianoSolved;

    [SerializeField]
    public GameObject note;

    string[] words = {"adage", "added", "badge", "baggage", "bagged", "bead", "bedded", "beef", "beefed", "begged", "cabbage", "cafe", "caged", "dead", "deaf", "decade", "decaf", "deed", "deface", "edged", "facade", "faded", "gabbed", "gaffe", "gagged"};

    public string clue;

    public string sequence;

    bool solved = false;

    // Start is called before the first frame update
    void Start()
    {
        clue = words[Random.Range(0, words.Length)];
        sequence = "";
        note.GetComponent<CollectableObjectScript>().note = clue;
    }

    // Update is called once per frame
    void Update()
    {
        if (sequence.Length >= clue.Length)
        {
            sequence = sequence.Substring(sequence.Length - clue.Length, clue.Length);
        }

        if (sequence.Equals(clue) && !solved)
        {
            solved = true;
            PianoSolved();
        }
    }

    public void PressKey(string key)
    {
        sequence = sequence + key;
    }

    void PianoSolved()
    {
        onPianoSolved?.Invoke();
    }
}
