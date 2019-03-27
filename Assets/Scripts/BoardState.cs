using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : MonoBehaviour
{
    private static BoardState boardState;
    private int[,] board;
    private int rowAmount, colAmount;

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
        printLevel();        
    }

    public int locationValue(int row, int col)
    {
        //Debug.Log("at row:" + row + " col:" + col + " --> " + board[row, col]);
        return board[row, col];
    }

    void loadLevel(string level_in)
    {
        string[] rows = level_in.Split('\n');
        rowAmount = rows.Length;
        colAmount = -1;
        string[] oneRow;

        for (int i = 0; i < rowAmount; i++)
        {
            oneRow = rows[i].Split(' ');

            if (colAmount == -1)
            {
                colAmount = oneRow.Length;

                if (board == null)
                {
                    board = new int[rowAmount, colAmount];
                }
            }

            for (int j = 0; j < colAmount; j++)
            {
                board[i, j] = int.Parse(oneRow[j]);
            }
        }
    }

    void printLevel()
    {
        string levelString = "";

        for (int i = 0; i < rowAmount; i++)
        {
            for (int j = 0; j < colAmount; j++)
            {
                levelString += (board[i, j] + " ");
            }
            levelString += "\n";
        }
    }
}
