using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System.Security.Cryptography;
using UnityEngine.SocialPlatforms;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    //public ScriptableObject Circle1;
    //public ScriptableObject Circle2;
    public CircleCard Circle1;
    public CircleCard Circle2;
    public CircleCard Square1;
    public CircleCard Square2;
    /*
    public Transform Circle1;
    public Transform Circle2;
    public Transform Square1;
    public Transform Square2;
    */

    public Transform triangleTester;

    //public Transform MarkOnCard;
    //bool MarkActivated = false;

    //Makes so that the player will not check a third card and only have two cards active/rendered true
    //The objects needs to have their "render" funktions on "false" to make them invisible, by having cards flipped up, aka cardsUp will make only two cards visible
    //But the only exception is pairs, which will always have their renders on true
    int CardsUp;

    //This has to check if a card was flipped, and if it was flipped, you can not flip back
    bool Checked1 = false;
    bool Checked2 = false;
    bool Checked3 = false;
    bool Checked4 = false;

    bool CirclePair = false;
    bool SquarePair = false;

    //This is required to make delays between frames
    //with this i can delay the time it takes the program to flip back two cards of the "not same type"
    bool Delay1 = false;
    bool Delay2 = false;
    bool Delay3 = false;
    bool Delay4 = false;

    //This is the true delay timer for two wrong cards to flip back
    int DelayTimer;

    Vector2 Location0 = new Vector2(-1, 1);
    Vector2 Location1 = new Vector2(1, 1);
    Vector2 Location2 = new Vector2(-1, -1);
    Vector2 Location3 = new Vector2(1, -1);


    void Start()
    {
        triangleTester.GetComponent<Renderer>().enabled = false;

        CardsUp = 0;
        DelayTimer = 0;

        //DO NOT FORGET THIS, MAKE A RANDOM LOCATION CODE THAT MAKES THE MARKS OF THE CARDS SWITCH PLACES, MAKING IT RANDOM
        //DO NOT FORGET THIS, MAKE A RANDOM LOCATION CODE THAT MAKES THE MARKS OF THE CARDS SWITCH PLACES, MAKING IT RANDOM
        List<Vector2> locationList = new List<Vector2>();
        locationList.Add(Location0);
        locationList.Add(Location1);
        locationList.Add(Location2);
        locationList.Add(Location3);
        
        List<CircleCard> MarkList = new List<CircleCard>(3);
        MarkList[0] = Circle1;
        MarkList[1] = Circle2;
        MarkList[2] = Square1;
        MarkList[3] = Square2;
        
        Circle1.transform.localPosition = Location0;
        Circle2.transform.localPosition = Location1;
        Square1.transform.localPosition = Location2;
        Square2.transform.localPosition = Location3;


        /*
        int rndNumber = UnityEngine.Random.Range(0, 3);
        int rndPlace = UnityEngine.Random.Range(0, 3);

        if (rndNumber == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                Location[i] = 
            }
        } 
        */

    }

    // Update is called once per frame
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


        //if CardsUp exceeds 2, render all object false
        //This makes sure you can not spam cards to get right, even when there is an delay between wrong pairs
        if (CardsUp > 2)
        {
            Circle1.gameObject.GetComponent<Renderer>().enabled = false;
            Circle2.gameObject.GetComponent<Renderer>().enabled = false;
            Square1.gameObject.GetComponent<Renderer>().enabled = false;
            Square2.gameObject.GetComponent<Renderer>().enabled = false;


            Delay1 = false;
            Delay2 = false;
            Delay3 = false;
            Delay4 = false;

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


        //if circle1 is active with either square 1 or 2, the DelayTimer will add +1 every frame
        if (Delay1 == true && Delay3 == true | Delay1 == true && Delay4 == true)
        {
            DelayTimer++;
        }
        //if circle2 is active with either square 1 or 2, the DelayTimer will add +1 every frame
        else if (Delay2 == true && Delay3 == true | Delay2 == true && Delay4 == true)
        {
            DelayTimer++;
        } else if (Delay1 == false && Delay2 == false)
        {
            DelayTimer = 0;
        }


        //If CardsUp is 2 and DelayTimer is more or the same as the number 700
        //then all marks will render false and all delays are false and CardsUp is equal to 0
        //Or CardsUp is more than 2
        //This will make sure that you can see what two cards that was flipped
        //I also have a code that makes pairs stay true both up and below this so that a pair counter adds and then render true, even when this activates
        if (CardsUp == 2 && DelayTimer >= 700)
        {
            Circle1.gameObject.GetComponent<Renderer>().enabled = false;
            Circle2.gameObject.GetComponent<Renderer>().enabled = false;
            Square1.gameObject.GetComponent<Renderer>().enabled = false;
            Square2.gameObject.GetComponent<Renderer>().enabled = false;

            Delay1 = false;
            Delay2 = false;
            Delay3 = false;
            Delay4 = false;

            Checked1 = false;
            Checked2 = false;
            Checked3 = false;
            Checked4 = false;

            CardsUp = 0;

            DelayTimer = 0;
        }

        //Makes sure both circles render funktion is true, making both of them visible
        if (CirclePair == true)
        {
            Circle1.gameObject.GetComponent<Renderer>().enabled = true;
            Circle2.gameObject.GetComponent<Renderer>().enabled = true;
        }
        if (SquarePair == true)
        {
            Square1.gameObject.GetComponent<Renderer>().enabled = true;
            Square2.gameObject.GetComponent<Renderer>().enabled = true;
        }

        //If you got both pairs then you will activate the victory
        if (CirclePair == true && SquarePair == true)
        {
            //You will notice this object when you win (this is the yellow triangle in the top middle of the screen, if i have not changed it.. ops i forgot to change this text)
            triangleTester.GetComponent<Renderer>().enabled = true;
        }


    }
}
