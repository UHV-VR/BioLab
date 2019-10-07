using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incubator : container
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("is currently incubating");
        //fades to black
        //looks through all the childeren of this container 
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform child = gameObject.transform.GetChild(i);
            // if it finds one that has a testtube attached to it, assigns the liquid tht was parented to it's incubated as true 
            if (child.transform.GetChild(0))
            {
                child.transform.GetChild(0).gameObject.GetComponent<Liquid>().setincubated(true);
            }
        }
    }
}
