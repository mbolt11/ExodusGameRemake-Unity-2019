using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will not be destroyed when loading between different levels
//It handles the stats that carry over from level to level, but not the ones that are level-specific
public class GameController : MonoBehaviour
{
    private static GameController controller;

    //this kept throwing a null pointer, so I had to have it be re-found everytime
    //something was called on the canvas object
    private GameObject canvas;

    private int MosesLives = 5;
    private int points;
    private int currentLevel = 1;

    //Singleton
    public static GameController GetController()
    {
        if(controller == null)
        {
            controller = new GameController();
            return controller;
        }
        else
        {
            return controller;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        controller = GetController();

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        //Debug.Log("Find? " +canvas);

        //Initialize variables at beginning of game
        MosesLives = 5;
        points = 0;
        currentLevel = 1;
    }

    //Stat accessors
    public int getPoints()
    {
        return points;
    }

    public int getLives()
    {
        return MosesLives;
    }

    public int getLevelNum()
    {
        return currentLevel;
    }

    //Stat updaters
    public void MosesDied()
    {
        MosesLives--;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        canvas.GetComponent<StatBoard>().UpdateLives();
    }

    public void addPoints(int points_in)
    {
        points += points_in;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        canvas.GetComponent<StatBoard>().UpdateScore();
    }

}
