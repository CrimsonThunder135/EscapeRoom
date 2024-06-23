using NavKeypad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PropObjectScript : MonoBehaviour
{
    [SerializeField]
    public GameState gameState;
    [SerializeField]
    public SlidingPuzzleScript SlidingPuzzleScript;
    [SerializeField]
    public GameObject correctKey;
    [SerializeField]
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && SelectionManagerScript.Instance.onTarget && (transform.position == gameState.currentSelection))
        {
            switch (gameObject.tag)
            {
                case "PianoKey":
                    AudioSource audioSource = GetComponent<AudioSource>();
                    audioSource.Play();
                    gameObject.GetComponentInParent<PianoScript>().PressKey(itemName);
                    break;
                case "PuzzleTile":
                    GameObject[,] tiles = new GameObject[4,4];
                    int position = 0;
                    for(int i = 0; i < 16; i++)
                    {
                        tiles[(i / 4), (i % 4)] = gameState.tiles[i];
                    }
                    for(int i = 0; i < 16; i++)
                    {
                        if (gameState.tiles[i].transform.position == transform.position)
                        {
                            position = i;
                        }
                    }
                    
                    switch(position / 4)
                    {
                        case 0:
                            switch (position % 4)
                            {
                                case 0:
                                    if ((tiles[0,1] == gameState.emptyTile) |
                                        (tiles[1,0] == gameState.emptyTile))
                                    {
                                        Vector3 newPosition = transform.position;
                                        transform.position = gameState.emptyTile.transform.position;
                                        gameState.emptyTile.transform.position = newPosition;
                                        SlidingPuzzleScript.moveEmpty();

                                    }
                                    break;
                                case 3:
                                    if ((tiles[0, 2] == gameState.emptyTile) |
                                        (tiles[1, 3] == gameState.emptyTile))
                                    {
                                        Vector3 newPosition = transform.position;
                                        transform.position = gameState.emptyTile.transform.position;
                                        gameState.emptyTile.transform.position = newPosition;
                                        SlidingPuzzleScript.moveEmpty();
                                    }
                                    break;
                                default:
                                    if ((tiles[(position / 4) + 1, (position % 4)] == gameState.emptyTile) |
                                        (tiles[(position / 4), (position % 4) + 1] == gameState.emptyTile) |
                                        (tiles[(position / 4), (position % 4) - 1] == gameState.emptyTile))
                                    {
                                        Vector3 newPosition = transform.position;
                                        transform.position = gameState.emptyTile.transform.position;
                                        gameState.emptyTile.transform.position = newPosition;
                                        SlidingPuzzleScript.moveEmpty();
                                    }
                                    break;
                            }
                            break;
                        case 3:
                            switch (position % 4)
                            {
                                case 0:
                                    if ((tiles[3, 1] == gameState.emptyTile) |
                                        (tiles[2, 0] == gameState.emptyTile))
                                    {
                                        Vector3 newPosition = transform.position;
                                        transform.position = gameState.emptyTile.transform.position;
                                        gameState.emptyTile.transform.position = newPosition;
                                        SlidingPuzzleScript.moveEmpty();
                                    }
                                    break;
                                case 3:
                                    if ((tiles[3, 2] == gameState.emptyTile) |
                                        (tiles[2, 3] == gameState.emptyTile))
                                    {
                                        Vector3 newPosition = transform.position;
                                        transform.position = gameState.emptyTile.transform.position;
                                        gameState.emptyTile.transform.position = newPosition;
                                        SlidingPuzzleScript.moveEmpty();
                                    }
                                    break;
                                default:
                                    if ((tiles[(position / 4) - 1, (position % 4)] == gameState.emptyTile) |
                                        (tiles[(position / 4), (position % 4) + 1] == gameState.emptyTile) |
                                        (tiles[(position / 4), (position % 4) - 1] == gameState.emptyTile))
                                    {
                                        Vector3 newPosition = transform.position;
                                        transform.position = gameState.emptyTile.transform.position;
                                        gameState.emptyTile.transform.position = newPosition;
                                        SlidingPuzzleScript.moveEmpty();
                                    }
                                    break;
                            }
                            break;
                        default:
                            switch (position % 4)
                            {
                                case 0:
                                    if ((tiles[(position / 4) + 1, (position % 4)] == gameState.emptyTile) |
                                        (tiles[(position / 4) - 1, (position % 4) ] == gameState.emptyTile) |
                                        (tiles[(position / 4), (position % 4) + 1] == gameState.emptyTile))
                                    {
                                        Vector3 newPosition = transform.position;
                                        transform.position = gameState.emptyTile.transform.position;
                                        gameState.emptyTile.transform.position = newPosition;
                                        SlidingPuzzleScript.moveEmpty();
                                    }
                                    break;
                                case 3:
                                    if ((tiles[(position / 4) + 1, (position % 4)] == gameState.emptyTile) |
                                        (tiles[(position / 4) - 1, (position % 4)] == gameState.emptyTile) |
                                        (tiles[(position / 4), (position % 4) - 1] == gameState.emptyTile))
                                    {
                                        Vector3 newPosition = transform.position;
                                        transform.position = gameState.emptyTile.transform.position;
                                        gameState.emptyTile.transform.position = newPosition;
                                        SlidingPuzzleScript.moveEmpty();
                                    }
                                    break;
                                default:
                                    if ((tiles[(position / 4) - 1, (position % 4)] == gameState.emptyTile) |
                                        (tiles[(position / 4) + 1, (position % 4)] == gameState.emptyTile) |
                                        (tiles[(position / 4), (position % 4) + 1] == gameState.emptyTile) |
                                        (tiles[(position / 4), (position % 4) - 1] == gameState.emptyTile))
                                    {
                                        Vector3 newPosition = transform.position;
                                        transform.position = gameState.emptyTile.transform.position;
                                        gameState.emptyTile.transform.position = newPosition;
                                        SlidingPuzzleScript.moveEmpty();
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
                case "FullSize":
                case "LockedCabinetDoor":
                    if (HotBarHandler.Instance.selectedItem != null && correctKey != null)
                    {
                        if (HotBarHandler.Instance.selectedItem.name == correctKey.name)
                        {
                            gameObject.GetComponent<DoorScript>().Open();
                            Destroy(HotBarHandler.Instance.selectedItem);
                        }
                    }
                    break;
                case "CabinetDoor":
                case "Drawer":
                    gameObject.GetComponent<DoorScript>().Open();
                    break;
                case "KeyPadButton":
                    gameObject.GetComponent<KeypadButton>().PressButton();
                    break;
                case "DiceButton":
                    gameObject.GetComponent<DiceButtonScript>().PressButton();
                    break;
                default:
                    break;

            }
        }
    }
}
