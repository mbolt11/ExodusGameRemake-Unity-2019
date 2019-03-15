using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform moses;
    public float xOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(moses.position.x + xOffset, transform.position.y, -10);
    }
}
