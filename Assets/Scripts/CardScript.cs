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
    
    public CardMarkScript Circle1;
    public CardMarkScript Circle2;
    public CardMarkScript Square1;
    public CardMarkScript Square2;
    public CardMarkScript Triangle1;
    public CardMarkScript Triangle2;

    List<Vector3> checkLocation = new List<Vector3>();

    void Start()
    {
        //At the start of the first frame, checkLocation gets two location from two diffrent object, saving those location in the list for later use
        checkLocation.Add(Circle1.transform.position);
        
    }
    
    public TMP_Text winTextTMP;

    public string winText = "YOU WON!";
    public string resetText = "";
    
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

    void Update()
    {
        //If the locations added before any changes is not equal to any type of change in location on two marks, circle1 and or circle2, then the pairs will be reset, removing any visible cards on the table and the player can start over
        //The checkLocation[0] and [1] will then take the new location
        //THIS does not 100% remove the pairs that is already paired, but it will work as long as you do not get the same location on both circle1 and circle2, i could code the rest to make it 100%
        if (checkLocation[0] != Circle1.transform.position)
        {
            CirclePair = false;
            SquarePair = false;
            TrianglePair = false;

            Checked1 = false;
            Checked2 = false;
            Checked3 = false;
            Checked4 = false;
            Checked5 = false;
            Checked6 = false;

            CardsUp = 0;

            checkLocation.Remove(checkLocation[0]);
            checkLocation.Add(Circle1.transform.position);

            //Removes the victory text
            winTextTMP.text = resetText.ToString();
        }
        else
        {
            //Nothing
        }

        //Checking if the card is pressed and the check is not activated, it will then make sure it is checked and can not be flipped back down
        //This code will hinder the user from flipping back the card after already seeing whats under it
        if (Circle1.gameObject.GetComponent<Renderer>().enabled == true && Checked1 == false)
        {
            CardsUp++;
            Checked1 = true;
        }
        if (Circle2.gameObject.GetComponent<Renderer>().enabled == true && Checked2 == false)
        {
            CardsUp++;
            Checked2 = true;
        }
        if (Square1.gameObject.GetComponent<Renderer>().enabled == true && Checked3 == false)
        {
            CardsUp++;
            Checked3 = true;
        }
        if (Square2.gameObject.GetComponent<Renderer>().enabled == true && Checked4 == false)
        {
            CardsUp++;
            Checked4 = true;
        }
        if (Triangle1.gameObject.GetComponent<Renderer>().enabled == true && Checked5 == false)
        {
            CardsUp++;
            Checked5 = true;
        }
        if (Triangle2.gameObject.GetComponent<Renderer>().enabled == true && Checked6 == false)
        {
            CardsUp++;
            Checked6 = true;
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

            Checked1 = false;
            Checked2 = false;
            Checked3 = false;
            Checked4 = false;
            Checked5 = false;
            Checked6 = false;

            CardsUp = 0;
        }

        //This will make sure that pairs will not be flipped and stay up
        if (Circle1.gameObject.GetComponent<Renderer>().enabled == true && Circle2.gameObject.GetComponent<Renderer>().enabled == true)
        {
            CirclePair = true;
        }
        if (Square1.gameObject.GetComponent<Renderer>().enabled == true && Square2.gameObject.GetComponent<Renderer>().enabled == true)
        {
            SquarePair = true;
        }
        if (Triangle1.gameObject.GetComponent<Renderer>().enabled == true && Triangle2.gameObject.GetComponent<Renderer>().enabled == true)
        {
            TrianglePair = true;
        }

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