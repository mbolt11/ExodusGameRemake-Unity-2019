using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesShoot : MonoBehaviour 
{
    public Rigidbody2D word;
    public Transform spawnpoint;
    public float speed = 2;

	// Update is called once per frame
	void Update () 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Rigidbody2D wordInstance = Instantiate(word, spawnpoint.position, Quaternion.Euler(new Vector3(0f,0f,0f))) as Rigidbody2D;
            wordInstance.velocity = new Vector2(1f, 0);
        }
		
	}
}
