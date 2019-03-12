using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosesMovement : MonoBehaviour 
{
    public float speed = 3;

    // Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        //His movement based on arrow keys
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(moveHorizontal, moveVertical, 0f); 
	}
}
