using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesShoot : MonoBehaviour 
{
    public Rigidbody2D word;
    public Transform spawnRight, spawnLeft, spawnDown, spawnUp, moses;
    public float speed;

    // Update is called once per frame
    void Update () 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            float xSpeed, ySpeed;
            string lastMove = moses.GetComponent<MosesMovement>().getLastMove();
            Transform direction;
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

            //Debug.Log("Speed: " + xSpeed + "," + ySpeed);
            Rigidbody2D wordInstance = Instantiate(word, direction.position, Quaternion.Euler(new Vector3(0f,0f,0f))) as Rigidbody2D;
            wordInstance.velocity = new Vector2(xSpeed, ySpeed);
        }
	}
}
