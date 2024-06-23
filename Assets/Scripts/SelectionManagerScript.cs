using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManagerScript : MonoBehaviour{

    public static SelectionManagerScript Instance { get; set; }


    public GameState gameState;
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;

    public bool onTarget;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } 
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        onTarget = false;
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            if (selectionTransform.gameObject.GetComponent<CollectableObjectScript>() && selectionTransform.gameObject.GetComponent<CollectableObjectScript>().inRange)
            {
                gameState.currentSelection = selectionTransform.position;

                onTarget = true;

                interaction_text.text = selectionTransform.GetComponent<CollectableObjectScript>().GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else if (selectionTransform.gameObject.GetComponent<PropObjectScript>())
            {
                gameState.currentSelection = selectionTransform.position;
                onTarget = true;
            }
            else if (selectionTransform.gameObject.GetComponent<DieScript>() && selectionTransform.gameObject.GetComponent<DieScript>().inRange)
            {
                if (!selectionTransform.GetComponent<DieScript>().color.Equals("Red"))
                {
                    interaction_text.text = selectionTransform.GetComponent<DieScript>().color + ": " + selectionTransform.GetComponent<DieScript>().value.ToString();
                    interaction_Info_UI.SetActive(true);
                }
            }
            else
            {
                gameState.currentSelection = Vector3.zero;
                onTarget = false;
                interaction_Info_UI.SetActive(false);
            }

        }
        else
        {
            gameState.currentSelection = Vector3.zero;
            onTarget = false;
            interaction_Info_UI.SetActive(false);
        }
    }
}
