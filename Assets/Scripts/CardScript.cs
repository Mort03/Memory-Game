using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System.Security.Cryptography;
using UnityEngine.SocialPlatforms;
using UnityEngine.Timeline;
using UnityEngine.UI;
using Unity.VisualScripting.Dependencies.NCalc;
using TMPro;

public class CardScript : MonoBehaviour
{
    //public ScriptableObject Circle1;
    //public ScriptableObject Circle2;
    public CircleCard Circle1;
    public CircleCard Circle2;
    public CircleCard Square1;
    public CircleCard Square2;
    public CircleCard Triangle1;
    public CircleCard Triangle2;
    /*
    public Transform Circle1;
    public Transform Circle2;
    public Transform Square1;
    public Transform Square2;
    */

    public TMP_Text winTextTMP;

    public string winText = "YOU WON!";
    //public int RandNum = 0;

    //public Transform MarkOnCard;
    //bool MarkActivated = false;

    //Makes so that the player will not check a third card and only have two cards active/rendered true
    //The objects needs to have their "render" funktions on "false" to make them invisible, by having cards flipped up, aka cardsUp will make only two cards visible
    //But the only exception is pairs, which will always have their renders on true
    int CardsUp = 0;

    //This has to check if a card was flipped, and if it was flipped, you can not flip back
    bool Checked1 = false;
    bool Checked2 = false;
    bool Checked3 = false;
    bool Checked4 = false;
    bool Checked5 = false;
    bool Checked6 = false;

    //This will make pairs always stay visible and for winning
    bool CirclePair = false;
    bool SquarePair = false;
    bool TrianglePair = false;

    //This is required to make delays between frames
    //with this i can delay the time it takes the program to flip back two cards of the "not same type"
    bool Delay1 = false;
    bool Delay2 = false;
    bool Delay3 = false;
    bool Delay4 = false;
    bool Delay5 = false;
    bool Delay6 = false;

    //This is the true delay timer for two wrong cards/not pairs to flip back
    int DelayTimer = 0;

    //This will check if one or two cards has been activated, these bools make sure that if two cards are visible (and not pair) then DelayTimerActivation will count up
    bool DelayCheck1 = false;
    bool DelayCheck2 = false;

    //When this activates, it will count up until DelayTimer limit is reach (not really limit, but a certain number that will deactivate the resently flipped cards and will reset all timers
    //Hard to explain but it is needed, if one card is visible, then it will not activate a string of code twice
    int DelayTimerActivation = 0;

    void Start()
    {
        //CardsUp starts with it being equal to 0
        CardsUp = 0;
    }

    
    void Update()
    {
        //Checking if the card is pressed and the check is not activated, it will then make sure it is checked and can not be flipped back down
        //This code will hinder the user from flipping back the card after already seeing whats under it
        if (Circle1.gameObject.GetComponent<Renderer>().enabled == true && Checked1 == false)
        {
            CardsUp++;
            Checked1 = true;
            Delay1 = true;
        }
        if (Circle2.gameObject.GetComponent<Renderer>().enabled == true && Checked2 == false)
        {
            CardsUp++;
            Checked2 = true;
            Delay2 = true;
        }
        if (Square1.gameObject.GetComponent<Renderer>().enabled == true && Checked3 == false)
        {
            CardsUp++;
            Checked3 = true;
            Delay3 = true;
        }
        if (Square2.gameObject.GetComponent<Renderer>().enabled == true && Checked4 == false)
        {
            CardsUp++;
            Checked4 = true;
            Delay4 = true;
        }
        if (Triangle1.gameObject.GetComponent<Renderer>().enabled == true && Checked5 == false)
        {
            CardsUp++;
            Checked5 = true;
            Delay5 = true;
        }
        if (Triangle2.gameObject.GetComponent<Renderer>().enabled == true && Checked6 == false)
        {
            CardsUp++;
            Checked6 = true;
            Delay6 = true;
        }


        //if CardsUp exceeds 2, render all object false
        //This makes sure you can not spam cards to get right, even when there is an delay between wrong pairs
        if (CardsUp > 2)
        {
            Circle1.gameObject.GetComponent<Renderer>().enabled = false;
            Circle2.gameObject.GetComponent<Renderer>().enabled = false;
            Square1.gameObject.GetComponent<Renderer>().enabled = false;
            Square2.gameObject.GetComponent<Renderer>().enabled = false;
            Triangle1.gameObject.GetComponent<Renderer>().enabled = false;
            Triangle2.gameObject.GetComponent<Renderer>().enabled = false;

            Delay1 = false;
            Delay2 = false;
            Delay3 = false;
            Delay4 = false;
            Delay5 = false;
            Delay6 = false;

            Checked1 = false;
            Checked2 = false;
            Checked3 = false;
            Checked4 = false;
            Checked5 = false;
            Checked6 = false;

            DelayCheck1 = false;
            DelayCheck2 = false;

            CardsUp = 0;

            DelayTimer = 0;
        }

        //This will make sure that pairs will not be flipped and stay up
        if (Circle1.gameObject.GetComponent<Renderer>().enabled == true && Circle2.gameObject.GetComponent<Renderer>().enabled == true)
        {
            CirclePair = true;

            Delay1 = false;
            Delay2 = false;
        }
        if (Square1.gameObject.GetComponent<Renderer>().enabled == true && Square2.gameObject.GetComponent<Renderer>().enabled == true)
        {
            SquarePair = true;

            Delay3 = false;
            Delay4 = false;
        }
        if (Triangle1.gameObject.GetComponent<Renderer>().enabled == true && Triangle2.gameObject.GetComponent<Renderer>().enabled == true)
        {
            TrianglePair = true;

            Delay5 = false;
            Delay6 = false;
        }

        //This part wont work

        /*
        //This will check if any delay bool is equal to true and if DelayCheck1 is equal to false, then DelayCheck1 is equal to true and DelayTimerActivation goes up with 1
        if (Delay1 == true && DelayCheck1 == false | Delay2 == true && DelayCheck1 == false | Delay3 == true && DelayCheck1 == false | Delay4 == true && DelayCheck1 == false | Delay5 == true && DelayCheck1 == false | Delay6 == true && DelayCheck1 == false)
        {
            DelayCheck1 = true;
            DelayTimerActivation++;
        }
        //This checks the second DelayChecker, the DelayCheck2, instead of DelayCheck1 and does the same
        else if (Delay1 == true && DelayCheck2 == false | Delay2 == true && DelayCheck2 == false | Delay3 == true && DelayCheck2 == false | Delay4 == true && DelayCheck2 == false | Delay5 == true && DelayCheck2 == false | Delay6 == true && DelayCheck2 == false)
        {
            DelayCheck2 = true;
            DelayTimerActivation++;
        }
        //is DelayTimerActivation is equal to 2, then DelayTimer ticks up
        else if (DelayTimerActivation == 2)
        {
            DelayTimer++;
        }

        //Checks if two pairs is true, then DelayTimer will always be equal to 0
        if (CirclePair == true && SquarePair == true | CirclePair == true && TrianglePair == true | SquarePair == true && TrianglePair == true)
        {
            DelayTimer = 0;
        }
        */
        //If CardsUp is equal to 2 and DelayTimer is more or equal to 50
        //then all marks will render false and all delays are false and CardsUp is equal to 0
        //This will make sure that you can see what two cards that was flipped
        //I also have a code that makes pairs stay true both up and below this so that a pair counter adds and then render true, even when this activates
        /*if (CardsUp == 2 && DelayTimer > 50)
        {
            Circle1.gameObject.GetComponent<Renderer>().enabled = false;
            Circle2.gameObject.GetComponent<Renderer>().enabled = false;
            Square1.gameObject.GetComponent<Renderer>().enabled = false;
            Square2.gameObject.GetComponent<Renderer>().enabled = false;
            Triangle1.gameObject.GetComponent<Renderer>().enabled = false;
            Triangle2.gameObject.GetComponent<Renderer>().enabled = false;

            Delay1 = false;
            Delay2 = false;
            Delay3 = false;
            Delay4 = false;
            Delay5 = false;
            Delay6 = false;

            Checked1 = false;
            Checked2 = false;
            Checked3 = false;
            Checked4 = false;
            Checked5 = false;
            Checked6 = false;

            DelayCheck1 = false;
            DelayCheck2 = false;

            CardsUp = 0;

            DelayTimer = 0;
        }
        */
        //Makes sure both circles render funktion is true, making both of them visible
        if (CirclePair == true)
        {
            Circle1.gameObject.GetComponent<Renderer>().enabled = true;
            Circle2.gameObject.GetComponent<Renderer>().enabled = true;

            Checked1 = true;
            Checked2 = true;
        }
        if (SquarePair == true)
        {
            Square1.gameObject.GetComponent<Renderer>().enabled = true;
            Square2.gameObject.GetComponent<Renderer>().enabled = true;

            Checked3 = true;
            Checked4 = true;
        }
        if (TrianglePair == true)
        {
            Triangle1.gameObject.GetComponent<Renderer>().enabled = true;
            Triangle2.gameObject.GetComponent<Renderer>().enabled = true;

            Checked5 = true;
            Checked6 = true;
        }

        //If you got both pairs then you will activate the victory
        if (CirclePair == true && SquarePair == true && TrianglePair == true)
        {
            //You will notice this object when you win (this is the yellow triangle in the top middle of the screen, if i have not changed it.. ops i forgot to change this text)
            winTextTMP.text = winText.ToString();
        }

    }
}