using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzleScript : MonoBehaviour
{
    [SerializeField]
    public GameObject[] tiles;
    [SerializeField]
    public GameState gameState;
    [SerializeField]
    public Vector3[] tilePositions;

    int[,] puzzleBoard;

    static int getInvCount(int[] arr)
    {
        int inv_count = 0;
        for (int i = 0; i < 4 * 4 - 1; i++)
        {
            for (int j = i + 1; j < 4 * 4; j++)
            {
                // count pairs(arr[i], arr[j]) such that
                // i < j but arr[i] > arr[j]
                if (arr[j] != 0 && arr[i] != 0
                    && arr[i] > arr[j])
                    inv_count++;
            }
        }
        return inv_count;
    }

    // find Position of blank from bottom
    static int findXPosition(int[,] puzzle)
    {
        // start from bottom-right corner of matrix
        for (int i = 4 - 1; i >= 0; i--)
            for (int j = 4 - 1; j >= 0; j--)
                if (puzzle[i,j] == 0)
                    return 4 - i;
        return -1;
    }

    // This function returns true if given
    // instance of N*N - 1 puzzle is solvable
    static bool isSolvable(int[,] puzzle)
    {
        // Count inversions in given puzzle
        int[] arr = new int[16];
        int k = 0;
        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                arr[k++] = puzzle[i,j];

        int invCount = getInvCount(arr);

        int pos = findXPosition(puzzle);
        if (pos % 2 == 1)
            return invCount % 2 == 0;
        else
            return invCount % 2 == 1;
        
    }

    public void GeneratePuzzleBoard()
    {
        List<int> puzzle = new();

        for (int i = 0; i < 16; i++)
        {
            if (i < 15)
            {
                puzzle.Add(i + 1);
            }
            else
            {
                puzzle.Add(0);
            }
        }
        puzzleBoard = new int[4, 4];

        for (int i = 0; i < 16; i++)
        {
            int randomValue = Random.Range(0, 16 - i);

            puzzleBoard[i / 4, i % 4] = puzzle[randomValue];

            puzzle.Remove(puzzle[randomValue]);
        }

        while (! isSolvable(puzzleBoard))
        {
            puzzle = new List<int>();

            for (int i = 0; i < 16; i++)
            {
                if (i < 15)
                {
                    puzzle.Add(i + 1);
                }
                else
                {
                    puzzle.Add(0);
                }
            }

            puzzleBoard = new int[4, 4];

            for (int i = 0; i < 16; i++)
            {
                int randomValue = Random.Range(0, 16 - i);

                puzzleBoard[i / 4, i % 4] = puzzle[randomValue];

                puzzle.Remove(puzzle[randomValue]);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState.tilesSolution = tiles;
        GeneratePuzzleBoard();

        GameObject[] newTilePositions = new GameObject[16];


        tilePositions = new Vector3[16];

        for (int i = 0; i < 16; i++)
        {
            tilePositions[i] = tiles[i].transform.position;
        }

        for (int i = 0; i < 16; i++)
        {
            if(puzzleBoard[i / 4, i % 4] == 0)
            {
                tiles[15].transform.position = tilePositions[i];
            }
            else
            {
                tiles[puzzleBoard[i / 4, i % 4] - 1].transform.position = tilePositions[i];
            }
        }

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (tilePositions[i] == tiles[j].transform.position)
                {
                    newTilePositions[i] = tiles[j];
                }
            }
        }

        tiles = newTilePositions;

        gameState.tilePositions = tilePositions;
        gameState.tiles = tiles;
    }

    // Update is called once per frame
    void Update()
    {
        bool finished = false;

        for(int i = 0; i < 16; i++)
        {
            if (gameState.tilesSolution[i].transform.position != gameState.tilePositions[i])
            {
                finished = false;
                break;
            }
            finished = true;
        }

        if (finished)
        {
            Destroy(gameState.emptyTile);
            this.enabled = false;
        }
    }

    public void moveEmpty()
    {
        GameObject[] newTilePositions = new GameObject[16];

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (tilePositions[i] == tiles[j].transform.position)
                {
                    newTilePositions[i] = tiles[j];
                }
            }
        }

        tiles = newTilePositions;

        gameState.tilePositions = tilePositions;
        gameState.tiles = tiles;
    }
}
