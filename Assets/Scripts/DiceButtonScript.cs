using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceButtonScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshPro countText;
    int count;

    private void Start()
    {
        count = 1;
    }

    private void Update()
    {
        countText.text = count.ToString();
    }

    public void PressButton()
    {
        count++;
        if (count > 6)
        {
            count = 1;
        }
    }
}
