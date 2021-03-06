﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script will not be destroyed when loading between different levels
//It handles the stats that carry over from level to level, but not the ones that are level-specific
public class GameController : MonoBehaviour
{
    //For singleton
    public static GameController controller;
    private static bool created = false;

    public GameObject canvas;
    public GameObject Moses;
    public GameObject levelcontrol;
    private int currentSceneNum;

    private int MosesLives;
    private int points;
    private int currentLevel;
    private int bibles;
    private bool MosesDead = false;

    private BoardState board;

    //The amount/lifetime of words that can be shot at once according to powerup
    public int wordsAtOnce;
    public float wordLifeTime;

    void Awake()
    {
        //Create Singleton
        if(!created)
        {
            controller = this;
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        else
        {
            //Destroys extra copy when reloading scene
            Destroy(gameObject);
        }

        //Initialize gameobjects for the first time
        InitializeGameObjects();

        //Initialize variables at beginning of game
        MosesLives = 5;
        points = 0;
        currentLevel = 1;
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;
        wordsAtOnce = 1;
        wordLifeTime = .3f;
    }

    //Method to re-initialize any gameobject references in this script whenever the scene is loaded
    public void InitializeGameObjects()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Moses = GameObject.FindGameObjectWithTag("Moses");
        levelcontrol = GameObject.FindGameObjectWithTag("Level Control");
        MosesDead = false;
    }

    public void setUpBoard()
    {
        board = BoardState.boardState;
        board.loadCurrectLevel(currentLevel);
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

    public int getBibles()
    {
        return bibles;
    }

    public bool getMosesDead()
    {
        return MosesDead;
    }

    //Stat updaters
    public void MosesDied()
    {
        //Make Moses stop moving and update counts
        wordsAtOnce = 1;
        MosesDead = true;
        Moses.GetComponent<MosesMovement>().enabled = false;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Soldier");
        for(int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<SoldierMovement>().enabled = false;
        }
        GameObject[] woods = GameObject.FindGameObjectsWithTag("Wood Block");
        for (int i = 0; i < woods.Length; i++)
        {
            woods[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            woods[i].GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        GameObject[] blues = GameObject.FindGameObjectsWithTag("Blue Block");
        for (int i = 0; i < blues.Length; i++)
        {
            blues[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            blues[i].GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        MosesLives--;
        canvas.GetComponent<StatBoard>().UpdateLives();

        //Check if game over
        if(MosesLives > 0)
        {
            //Reload the scene
            StartCoroutine(ReloadSceneOnDeath());
        }
        else
        {
            canvas.GetComponent<StatBoard>().UpdateMessage("Game Over!!");
            currentLevel = 1;
            currentSceneNum = 0;

            MosesLives = 5;
            points = 0;
            wordsAtOnce = 1;
            wordLifeTime = .3f;

            StartCoroutine(ReloadSceneOnDeath());
        }
    }

    //This is called when you get the word of God powerup
    public void AddWordAtOnce()
    {
        if(wordsAtOnce < 5)
            wordsAtOnce++;

        if(wordsAtOnce == 3)
            Moses.GetComponent<MosesShoot>().ChangeFireRate(.15f);
        if(wordsAtOnce == 4)
            Moses.GetComponent<MosesShoot>().ChangeFireRate(.1f);
    }

    //This is called when you get the Authority of God powerup
    public void AddWordLifetime()
    {
        wordLifeTime += .2f;
    }

    public void addPoints(int points_in)
    {
        points += points_in;
        canvas.GetComponent<StatBoard>().UpdateScore();
    }

    public void addBible()
    {
        bibles++;

        //You are supposed to gain a life when you get 10 bibles,
        //but you are also supposed to gain a bible when you answer and question
        //and we aren't doing the questions.. idk if they can even get 10 bibles
        if(bibles == 10)
        {
            MosesLives++;
            bibles = 0;
        }

        canvas.GetComponent<StatBoard>().UpdateBibles();
    }

    //Coroutine to be called when Moses dies and need to reload scene
    private IEnumerator ReloadSceneOnDeath()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(currentSceneNum);
    }

    //Coroutine to be called when completing a level to move on to the next
    public void LoadNextLevel()
    {
        if(currentLevel == 5)
        {
            canvas.GetComponent<StatBoard>().UpdateMessage("You win!");
            currentLevel = 1;
            currentSceneNum = 0;
            StartCoroutine(WaitToLoad());
        }
        else
        {
            currentLevel++;
            currentSceneNum++;
            StartCoroutine(WaitToLoad());
        }
    }

    public IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("should be loading next level");
        SceneManager.LoadScene(currentSceneNum);
    }
}
