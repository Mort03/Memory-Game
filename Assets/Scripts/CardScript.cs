using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{

    public Transform MarkOnCard;
    bool MarkActivated = false;

    // Update is called once per frame
    void Update()
    {
        //0 for left click, 1 for right click and 2 for middle click
        if (Input.GetMouseButtonDown(1))
        {
            MarkActivated = true;

        }
    }
}
