using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesShoot : MonoBehaviour 
{
    public Rigidbody2D word;
    public Transform spawnRight, spawnLeft, spawnDown, spawnUp, moses;
    public float speed;

    private int shots = 0;
    private float timeToNextShot;
    private Transform direction;
    private float xSpeed, ySpeed;
    private float nextFire;
    private float fireRate;

    private void Start()
    {
        fireRate = .4f;
        direction = spawnDown;
        xSpeed = 0;
        ySpeed = -speed;
    }

    public void increaseFireRate()
    {
        fireRate -= .1f;
    }

    // Update is called once per frame
    void Update () 
    {
        //if( (GameController.controller.getWordsAtOnce() - shots) > 0 )
        if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))
        {
            //float xSpeed, ySpeed;
            string lastMove = moses.GetComponent<MosesMovement>().getLastMove();
            //Transform direction;
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

            /*GameObject wordInstance = Instantiate(word, direction.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as GameObject;
            Rigidbody2D wordInstance = Instantiate(word, direction.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
            StartCoroutine(DestroyShot(wordInstance));
            shots++;
            wordInstance.velocity = new Vector2(xSpeed, ySpeed);
            wordInstance.transform.Translate(xSpeed, ySpeed,0);*/

            if ((Time.time > nextFire) || shots <= 0)
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

    //Coroutine which destroys the shot instance after an amount of time
    private IEnumerator DestroyShot(Rigidbody2D theShot)
    {
        yield return new WaitForSeconds(.4f);

        if(theShot != null)
        {
            shots--;
            Destroy(theShot.gameObject);
        }
    }

    /*private IEnumerator Firing()
    {
        //Wait the amount of time according to how many words already exist/are allowed
        yield return new WaitForSeconds(timeToNextShot);

        //Instantiate the shot and set in motion
        Rigidbody2D wordInstance = Instantiate(word, direction.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
        wordInstance.velocity = new Vector2(xSpeed, ySpeed);
    }*/
}
