using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemPuzzleScript : MonoBehaviour
{
    [SerializeField]
    public TextMeshPro num1;
    [SerializeField]
    public TextMeshPro num2;
    [SerializeField]
    public TextMeshPro num3;

    int a = -1;
    int b = -1;
    int c = -1;
    int d = -1;

    [SerializeField]
    public GameObject clueGem1;
    [SerializeField]
    public GameObject clueGem2;
    [SerializeField]
    public GameObject clueGem3;
    [SerializeField]
    public GameObject clueGem4;

    public int[] code;

    private void Awake()
    {
        while (b < 0)
        {
            a = Random.Range(0, 10);
            c = Random.Range(0, 10);
            d = Random.Range(0, 10);

            num1.text = (c + d).ToString();
            num2.text = (2 * d).ToString();
            num3.text = (a + a - d).ToString();
            b = c - (2 * a);
        }

        code = new int[4] { a, b, c, d};
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
