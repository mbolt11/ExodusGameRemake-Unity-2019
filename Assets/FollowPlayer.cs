using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform moses;
    public float xOffset, yOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(moses.position.x + xOffset, moses.position.y + yOffset, -10);
    }
}
