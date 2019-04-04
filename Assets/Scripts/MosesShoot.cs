using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesShoot : MonoBehaviour 
{
    public Rigidbody2D word;
    public Transform spawnRight, spawnLeft, spawnDown, spawnUp;
    public float speed;

    private int shots = 0;
    private Transform direction;
    private float xSpeed, ySpeed;
    private float nextFire;
    private float fireRate;

    private void Start()
    {
        fireRate = .2f;
        direction = spawnDown;
        xSpeed = 0;
        ySpeed = -speed;
    }

    // Update is called once per frame
    void Update () 
    {
        //In case the shot count gets below zero, reset... this may not be best solution
        if (shots < 0)
            shots = 0;

        if (Input.GetButton("Fire1"))
        {
            //Get the direction of the shot
            string lastMove = GetComponent<MosesMovement>().getLastMove();
            if (lastMove.Equals("UP"))
            {
                direction = spawnUp;
                xSpeed = 0;
                ySpeed = speed;
            }
            else if (lastMove.Equals("DOWN"))
            {
                direction = spawnDown;
                xSpeed = 0;
                ySpeed = -speed;
            }
            else if (lastMove.Equals("RIGHT"))
            {
                direction = spawnRight;
                xSpeed = speed;
                ySpeed = 0;
            }
            else
            {
                direction = spawnLeft;
                xSpeed = -speed;
                ySpeed = 0;
            }

            //Shoot the word if it is allowed
            if ((Time.time > nextFire) && shots < GameController.controller.wordsAtOnce)
            {
                nextFire = Time.time + fireRate;
                shots++;
                Rigidbody2D wordInstance = Instantiate(word, direction.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
                wordInstance.velocity = new Vector2(xSpeed, ySpeed);
                StartCoroutine(DestroyShot(wordInstance));
            }
        }
	}

    //This is called from the WordBehavior script when a word is destroyed by hitting something
    public void subtractShot()
    {
        shots--;
    }

    public void ChangeFireRate(float rate)
    {
        fireRate = rate;
    }

    //Coroutine which destroys the shot instance after an amount of time
    private IEnumerator DestroyShot(Rigidbody2D theShot)
    {
        yield return new WaitForSeconds(GameController.controller.wordLifeTime);

        if(theShot != null)
        {
            shots--;
            Destroy(theShot.gameObject);
        }
    }
}
