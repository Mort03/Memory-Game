using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cricle1Script : MonoBehaviour
{
    public Transform Circle;

    bool MarkActivated = false;

    void Start()
    {
        
        gameObject.SetActive(MarkActivated);
    }

    private void OnMouseDown()
    {
        MarkActivated = true;
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }
}
