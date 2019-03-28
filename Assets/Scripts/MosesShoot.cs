using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesShoot : MonoBehaviour 
{
    public Rigidbody2D word;
    public Transform spawnRight, spawnLeft, spawnDown, spawnUp, moses;
    public float speed;

    private GameObject wordExist;

    // Update is called once per frame
    void Update () 
    {
        if(wordExist == null)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))
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

                Rigidbody2D wordInstance = Instantiate(word, direction.position, Quaternion.Euler(new Vector3(0f, 0f, 0f))) as Rigidbody2D;
                wordExist = wordInstance.gameObject;
                wordInstance.velocity = new Vector2(xSpeed, ySpeed);
            }
        }
	}
}
