using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingTreasure : MonoBehaviour
{
    public GameObject treasure;
    bool hiddenTreasure;
    // Start is called before the first frame update
    void Awake()
    {
        if (treasure == null)
            hiddenTreasure = false;
        else
            hiddenTreasure = true;

        if (hiddenTreasure)
            treasure.SetActive(false);
    }

    public bool showTreasure()
    {
        if (hiddenTreasure)
        {
            treasure.SetActive(true);
            return true;
        }

        return false;
    }
}
