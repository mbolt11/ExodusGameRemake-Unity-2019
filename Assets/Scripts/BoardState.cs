using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : MonoBehaviour
{
    private static BoardState boardState;
    private int[,] board;

    //all the obstacles and empty spaces on the board at the load of level1
    string level1 = "1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1\n" +
                    "1 0 0 0 0 0 0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 0 1 0 1\n" +
                    "1 1 1 1 1 1 0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1\n" +
                    "1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 1 0 0 1\n" +
                    "1 1 1 1 1 1 1 1 1 0 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 1 1 1 1\n" +
                    "1 0 0 0 0 1 1 1 0 0 0 0 0 1 1 1 0 0 0 0 0 0 0 0 0 1 0 1 1 0 0 1\n" +
                    "1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0\n" +
                    "1 1 1 1 1 1 0 1 1 1 0 1 0 1 1 1 1 1 1 1 0 1 1 1 1 1 0 1 1 0 1 1\n" +
                    "1 1 1 1 1 1 0 1 1 1 0 1 0 1 1 1 1 1 1 1 0 1 1 1 1 1 1 1 1 1 1 1\n" +
                    "1 1 1 1 1 1 0 1 1 1 0 0 0 1 1 1 1 1 1 1 0 0 1 1 1 1 1 1 1 1 0 1\n" +
                    "1 1 1 1 1 1 0 1 1 1 0 1 0 1 1 1 1 1 1 1 0 1 1 1 1 1 1 1 1 1 0 1\n" +
                    "1 1 1 1 1 1 0 0 0 0 0 1 0 1 1 1 1 1 1 1 0 1 1 1 1 1 0 0 1 1 1 1\n" +
                    "1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1";

    //Get Singleton
    public static BoardState getBoard()
    {
            return boardState;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        if(boardState != this)
            boardState = this;
    }

    void Start()
    {
        loadLevel(level1);
        //Debug.Log("LEVEL\n");
        //printLevel();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int locationValue(int row, int col)
    {
        return board[row, col];
    }

    void loadLevel(string level_in)
    {
        if(board == null)
            board = new int[13, 32];

        string[] rows = level_in.Split('\n');
        string[] oneRow;

        for (int i = 0; i < 13; i++)
        {
            oneRow = rows[i].Split(' ');

            for (int j = 0; j < 32; j++)
            {
                board[i, j] = int.Parse(oneRow[j]);
            }
        }
    }

    void printLevel()
    {
        string levelString = "";

        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 32; j++)
            {
                levelString += (board[i, j] + " ");
            }
            levelString += "\n";
        }

        Debug.Log(levelString);
    }
}
