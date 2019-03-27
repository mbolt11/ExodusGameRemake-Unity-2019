﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardState : MonoBehaviour
{
    private static BoardState boardState;
    private int[,] board;
    private int rowAmount, colAmount;
    private Vector2 topLeft;

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
        if(boardState == null)
            boardState = this;
    }

    void Start()
    {
        loadLevel(level1);
        //Debug.Log("LEVEL\n");
        //printLevel();
        topLeft = new Vector2(-5.5f, 5.5f);
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

        Debug.Log(levelString);
    }

    //level 1 top left corner x:-5.5 y:5.5
    public Vector2 findBoardLocation(Transform other)
    {
        //find the row
        int other_col = Mathf.RoundToInt(Mathf.Abs(other.position.x - topLeft.x));
        int other_row = Mathf.RoundToInt(Mathf.Abs(other.position.y - topLeft.y));
        //Debug.Log("ROW:" + other_row + " COL:" + other_col);
        return new Vector2(other_row, other_col);
    }

    public void updateBoard(Vector2 location, int value)
    {
        board[(int)location.x, (int)location.y] = value;
        //Debug.Log("UPDATED BOARD");
        //Debug.Log(board);
        //printLevel();
    }
}
