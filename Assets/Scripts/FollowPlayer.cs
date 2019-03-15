using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform moses;
    private float xPosition;

    // Update is called once per frame
    void Update()
    {
        //Have the camera's x position be Moses' x postion
        xPosition = moses.transform.position.x;

        //When the camera reaches the ends of the level, it doesn't follow Moses anymore 
        if (xPosition < 1.94f)
            xPosition = 1.94f;
        if (xPosition > 18.06f)
            xPosition = 18.06f;

        //Move camera
        transform.position = new Vector3(xPosition, transform.position.y, -10);
    }
}
