using System.Collections;
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
    private int currentSceneNum;

    private int MosesLives = 5;
    private int points;
    private int currentLevel = 1;

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
    }

    //Method to re-initialize any gameobject references in this script whenever the scene is loaded
    public void InitializeGameObjects()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Moses = GameObject.FindGameObjectWithTag("Moses");
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
        //Make Moses stop moving and update lives count
        Moses.GetComponent<MosesMovement>().enabled = false;
        MosesLives--;
        canvas.GetComponent<StatBoard>().UpdateLives();

        //Print message then reload the scene
        canvas.GetComponent<StatBoard>().UpdateMessage("You died!");
        StartCoroutine(ReloadSceneOnDeath());
    }

    public void addPoints(int points_in)
    {
        points += points_in;
        canvas.GetComponent<StatBoard>().UpdateScore();
    }

    //Coroutine to be called when Moses dies and need to reload scene
    private IEnumerator ReloadSceneOnDeath()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(currentSceneNum);
    }


}
