using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    public CardMarkScript Circle1;
    public CardMarkScript Circle2;
    public CardMarkScript Square1;
    public CardMarkScript Square2;
    public CardMarkScript Triangle1;
    public CardMarkScript Triangle2;

    public int Rnd1;
    public int Rnd2;
    public int Rnd3;
    public int Rnd4;
    public int Rnd5;
    public int Rnd6;

    List<CardMarkScript> MarkList = new List<CardMarkScript>();

    List<Vector2> locationList = new List<Vector2>();

    Vector2 Location0 = new Vector2(-1, 2);
    Vector2 Location1 = new Vector2(1, 2);
    Vector2 Location2 = new Vector2(-1, 0);
    Vector2 Location3 = new Vector2(1, 0);
    Vector2 Location4 = new Vector2(-1, -2);
    Vector2 Location5 = new Vector2(1, -2);

    private void OnMouseDown()
    {
        for (int i = 0; i < MarkList.Count; ++i)
        {
            MarkList[i].gameObject.GetComponent<Renderer>().enabled = false;
        }
        
        Rnd1 = Random.Range(0, 6);
        Rnd2 = Random.Range(0, 6);
        Rnd3 = Random.Range(0, 6);
        Rnd4 = Random.Range(0, 6);
        Rnd5 = Random.Range(0, 6);
        Rnd6 = Random.Range(0, 6);
    }

    // Start is called before the first frame update
    void Start()
    {
        locationList.Add(Location0);
        locationList.Add(Location1);
        locationList.Add(Location2);
        locationList.Add(Location3);
        locationList.Add(Location4);
        locationList.Add(Location5);

        MarkList.Add(Circle1);
        MarkList.Add(Circle2);
        MarkList.Add(Square1);
        MarkList.Add(Square2);
        MarkList.Add(Triangle1);
        MarkList.Add(Triangle2);
    }

    // Update is called once per frame
    void Update()
    {
        //If the random number before is equal to the one after, then the one after will go through the random number process again until it has a number thats not equal to the other/others before it
        //For example Rnd1 is first and Rnd2 is second, both can not be the same, Rnd2 will then change its number and then it will be compaired to the next one together with Rnd1
        //Then it will be Rnd1 and Rnd2 is first and Rnd3 is second, then the process will be repeated but instead the Rnd3 is randomized again
        if (Rnd1 == Rnd2)
        {
            Rnd2 = Random.Range(0, 6);
        }
        else if (Rnd1 == Rnd3 || Rnd2 == Rnd3)
        {
            Rnd3 = Random.Range(0, 6);
        }
        else if (Rnd1 == Rnd4 || Rnd2 == Rnd4 || Rnd3 == Rnd4)
        {
            Rnd4 = Random.Range(0, 6);
        }
        else if (Rnd1 == Rnd5 || Rnd2 == Rnd5 || Rnd3 == Rnd5 || Rnd4 == Rnd5)
        {
            Rnd5 = Random.Range(0, 6);
        }
        else if (Rnd1 == Rnd6 || Rnd2 == Rnd6 || Rnd3 == Rnd6 || Rnd4 == Rnd6 || Rnd5 == Rnd6)
        {
            Rnd6 = Random.Range(0, 6);
        }

        MarkList[0].transform.position = locationList[Rnd1];
        MarkList[1].transform.position = locationList[Rnd2];
        MarkList[2].transform.position = locationList[Rnd3];
        MarkList[3].transform.position = locationList[Rnd4];
        MarkList[4].transform.position = locationList[Rnd5];
        MarkList[5].transform.position = locationList[Rnd6];
    }
}
