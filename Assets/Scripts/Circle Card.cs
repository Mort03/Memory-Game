using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CircleCard : MonoBehaviour
{

    public bool MarkActivated = false;

    bool CheckedActivation = false;

    void Start()
    {
        //Wants to start the game with it "off"
        gameObject.GetComponent<Renderer>().enabled = false;

    }

    private void OnMouseDown()
    {
        if (MarkActivated == false && gameObject.GetComponent<Renderer>().enabled == false)
        {
            MarkActivated = true;
        }
        
        else if (MarkActivated = true && gameObject.GetComponent<Renderer>().enabled == false)
        {
            MarkActivated = false;
        }
        
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (MarkActivated == true && CheckedActivation == false)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            CheckedActivation = true;
        } 
        /*
        else if (gameObject.GetComponent<Renderer>().enabled == false)
        {

        }
        */
        else if (MarkActivated == true && CheckedActivation == true)
        {
            MarkActivated = false;
            CheckedActivation = false;
        }





        /*
        if (gameObject.GetComponent<Renderer>().enabled == false)
        {
            CardScript.cardsUp();
        }
        */
    }
    
    
}

