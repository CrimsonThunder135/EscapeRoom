using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotBarHandler : MonoBehaviour
{
    public static HotBarHandler Instance { get; set; }

    // -- UI -- //
    public GameObject hotbarPanel;

    public List<GameObject> hotbarList = new List<GameObject>();
    public List<string> itemList = new List<string>();

    private GameObject newItem;

    private GameObject nextSlot;

    [SerializeField]
    GameObject selection;

    Vector3 leftBound;
    Vector3 rightBound;

    float slotDistance;

    public int selectedSlot = -1;
    [SerializeField]
    public GameObject selectedItem;
    [SerializeField]
    public GameObject note;
    [SerializeField]
    public TextMeshProUGUI noteText;


    private void Awake()
    {
        if (Instance != null && Instance != this)
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
        PopulateSlotList();
        leftBound = hotbarList[0].transform.localPosition;
        rightBound = hotbarList[hotbarList.Count - 1].transform.localPosition;

        slotDistance = Vector3.Magnitude(leftBound - rightBound) / (hotbarList.Count - 1);
    }

    private void Update()
    {
        selection.transform.localPosition = new Vector3(selection.transform.localPosition.x + Input.mouseScrollDelta.y * -slotDistance, selection.transform.localPosition.y, selection.transform.localPosition.z);

        if (selection.transform.localPosition.x < leftBound.x - 1)
        {
            selection.transform.localPosition = rightBound;
        }
        if (selection.transform.localPosition.x > rightBound.x + 1)
        {
            selection.transform.localPosition = leftBound;
        }

        UpdateCurrentSlot();

        if (selectedItem)
        {
            if (selectedItem.tag == "Note")
            {
                note.gameObject.SetActive(true);
                noteText.text = selectedItem.GetComponent<NoteScript>().note;
            }
            else
            {
                note.gameObject.SetActive(false);
                noteText.text = null;
            }
        }
        else
        {
            note.gameObject.SetActive(false);
            noteText.text = null;
        }
    }

    private void UpdateCurrentSlot()
    {
        for(int i = 0; i < 8; i++)
        {
            if(selection.transform.localPosition.x == hotbarList[i].transform.localPosition.x)
            {
                selectedSlot = i;
                if (hotbarList[i].transform.childCount != 0)
                {
                    selectedItem = hotbarList[i].transform.GetChild(0).gameObject;
                }
                else
                {
                    selectedItem = null;
                }
            }
        }
    }

    private void PopulateSlotList()
    {
        foreach (Transform child in hotbarPanel.transform)
        {
            if (child.CompareTag("Slot"))
            {
                hotbarList.Add(child.gameObject);
            }
        }
    }

    public void AddToHotBar(string ItemName, string note)
    {
        nextSlot = FindNextEmptySlot();
            
        newItem = (GameObject)Instantiate(Resources.Load<GameObject>(ItemName), nextSlot.transform.position, nextSlot.transform.rotation);

        newItem.transform.SetParent(nextSlot.transform);

        newItem.name = newItem.name.Replace("(Clone)", "");

        if (newItem.GetComponent<NoteScript>())
        {
            newItem.GetComponent<NoteScript>().note = note;
        }
    }


    private GameObject FindNextEmptySlot()
    {
        foreach (GameObject slot in hotbarList)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return new GameObject();
    }

    public bool CheckIfFull()
    {
        int counter = 0;

        foreach (GameObject slot in hotbarList)
        {
            if (slot.transform.childCount > 0)
            {
                counter += 1;
            }
        }

        if (counter == 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
