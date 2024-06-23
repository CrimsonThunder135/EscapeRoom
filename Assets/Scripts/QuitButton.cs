using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public TextMeshProUGUI warning;

    // Start is called before the first frame update
    void Start()
    {
        warning.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        warning.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        warning.gameObject.SetActive(true);
    }

}
