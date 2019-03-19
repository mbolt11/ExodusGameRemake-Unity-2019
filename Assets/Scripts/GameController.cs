using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script will not be destroyed when loading between different levels
//It handles the stats that carry over from level to level, but not the ones that are level-specific
public class GameController : MonoBehaviour
{
    //private static GameController controller;
    private GameObject canvas;
    private int currentSceneNum;

    private int MosesLives = 5;
    private int points;
    private int currentLevel = 1;

    //Singleton
    /*public static GameController GetController()
    {
        return controller;
    }*/

    void Awake()
    {
        //controller = gameObject.AddComponent<GameController>();

        DontDestroyOnLoad(this.gameObject);

        currentSceneNum = SceneManager.GetActiveScene().buildIndex;

        //canvas = GameObject.FindGameObjectWithTag("Canvas");
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
        //Update the lives count
        MosesLives--;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        canvas.GetComponent<StatBoard>().UpdateLives();

        //Print message then reload the scene
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        canvas.GetComponent<StatBoard>().UpdateMessage("You died!");
        StartCoroutine(ReloadSceneOnDeath());
    }

    public void addPoints(int points_in)
    {
        points += points_in;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        canvas.GetComponent<StatBoard>().UpdateScore();
    }

    //Coroutine to be called when Moses dies and need to reload scene
    private IEnumerator ReloadSceneOnDeath()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(currentSceneNum);
    }
}
