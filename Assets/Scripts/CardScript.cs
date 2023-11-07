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

    int CardsUp;

    bool Checked1 = false;
    bool Checked2 = false;
    bool Checked3 = false;
    bool Checked4 = false; 


    void Start()
    {
        triangleTester.GetComponent<Renderer>().enabled = false;

        CardsUp = 0;

        List<CircleCard> MarkList = new List<CircleCard>(3);
        MarkList[0] = Circle1;
        MarkList[1] = Circle2;
        MarkList[2] = Square1;
        MarkList[3] = Square2;
        //Circle1 = Circle2;
        //Square1 = Square2;

        



        /*
        int rndNumber = UnityEngine.Random.Range(0, 3);
        int rndPlace = UnityEngine.Random.Range(0, 3);

        if (rndNumber == 0)
        {
            if (rndPlace == 0)
            {
                MarkList[1] = ;
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
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
        if (CardsUp == 2)
        {
            triangleTester.GetComponent<Renderer>().enabled = true;
        }
        else if (CardsUp < 2)
        {
            triangleTester.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            triangleTester.GetComponent<Renderer>().enabled = false;



            Circle1.gameObject.GetComponent<Renderer>().enabled = false;
            Circle2.gameObject.GetComponent<Renderer>().enabled = false;
            Square1.gameObject.GetComponent<Renderer>().enabled = false;
            Square2.gameObject.GetComponent<Renderer>().enabled = false;
            

            Checked1 = false;
            Checked2 = false;
            Checked3 = false;
            Checked4 = false;

            CardsUp = 0;
        }

        
    }
}
