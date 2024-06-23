using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScript : MonoBehaviour
{
    public int value;
    public string color;

    public bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        value = Random.Range(1, 7);

        switch (value)
        {
            case 1:
                transform.rotation = new Quaternion(0.71f, 0, 0, -0.71f);
                break;
            case 2:
                transform.rotation = new Quaternion(0, 0, 0, 1);
                break;
            case 3:
                transform.rotation = new Quaternion(0, 0, -0.71f, 0.71f);
                break;
            case 4:
                transform.rotation = new Quaternion(0, 0, 0.71f, 0.71f);
                break;
            case 5:
                transform.rotation = new Quaternion(1, 0, 0, 0);
                break;
            case 6:
                transform.rotation = new Quaternion(0.71f, 0, 0, 0.71f);
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
