using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will not be destroyed when loading between different levels
//It handles the stats that carry over from level to level, but not the ones that are level-specific
public class GameController : MonoBehaviour
{
    public GameController controller;

    private int MosesLives;
    private int points;
    private int currentLevel;

    //Singleton
    public GameController GetController()
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

    void Start()
    {
        //Initialize variables at beginning of game
        MosesLives = 5;
        points = 0;
        currentLevel = 1;
        
    }

    //Stat updaters
    public void MosesDied()
    {
        MosesLives--;
    }

    public void addPoints(int points_in)
    {
        points += points_in;
    }

}
