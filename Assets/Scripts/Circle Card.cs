using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CircleCard : MonoBehaviour
{
    //Create bool markActivated equal to false, this will be used to check if the mark got activated, if it was not and the corresponding mark was not rendered true
    //Then it will be equal to true (markActivated), this will together with checkedActivation, activate the objects renderer to be equal to true and then deactivate both markActivate and CheckedActivation
    //Those bools can not be reactivated because of the object being rendered equal to true, but if the answer later on makes the renderer false, then both bools can be used
    public bool markActivated = false;

    bool checkedActivation = false;
    
    void Start()
    {
        //Wants to start the game with it "off"
        //gameObject.GetComponent<Renderer>().enabled = false;
    }

    private void OnMouseDown()
    {
        //When the object is clicked, then it will first check if markActivated is false and object renderer is false, if both statements is true then markActivated is equal to true
        if (markActivated == false && gameObject.GetComponent<Renderer>().enabled == false)
        {
            markActivated = true;
        }
        //Or if markActivated is already true, markActivated will then be equal to false
        else if (markActivated = true && gameObject.GetComponent<Renderer>().enabled == false)
        {
            markActivated = false;
        }
    }

    void Update()
    {
        //If markActivated is true and checkActivation is false, then object render is equal to true
        if (markActivated == true && checkedActivation == false)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            checkedActivation = true;
        }
        //Else if both bools is equal to true, then both of them is equal to false
        //It will reset both bools after activating the objects renderer to true, making the mark visible, because "renderer" is the thing that makes the object appear and dissappear without destroying it
        else if (markActivated == true && checkedActivation == true)
        {
            markActivated = false;
            checkedActivation = false;
        }
    }
}

