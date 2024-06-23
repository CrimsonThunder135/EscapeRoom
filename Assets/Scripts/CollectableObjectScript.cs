using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjectScript : MonoBehaviour
{
    [SerializeField]
    public GameState gameState;
    [SerializeField]
    public string note;

    public bool inRange;

    public string ItemName;

    public string GetItemName()
    {
        return ItemName;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && inRange && SelectionManagerScript.Instance.onTarget && (transform.position == gameState.currentSelection))
        {
            switch(gameObject.tag)
            {
                case "Key":
                case "Note":
                    if(!HotBarHandler.Instance.CheckIfFull())
                    {
                        Destroy(gameObject);
                        HotBarHandler.Instance.AddToHotBar(ItemName, note);
                    }
                    break;
                default:
                    break;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange= true;
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
