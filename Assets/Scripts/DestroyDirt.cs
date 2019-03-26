using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDirt : MonoBehaviour
{
    private int life = 2;

    public void BlueDirtHit()
    {
        life--;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
