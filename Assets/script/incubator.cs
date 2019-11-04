using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incubator : Containers
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
        // Debug.Log("is currently incubating");


        //**********WHAT WHAS THIS FOR??
        /*if (other.transform.Find("liquid"))
        {
            other.transform.Find("liquid").gameObject.transform.GetComponent<Liquid>().incubated = true; ;
        }*/

        //fades to black
        //looks through all the childeren of this container 
        for (int i = 0; i < this.transform.parent.transform.childCount; i++)
        {
            Debug.Log(this.transform.parent.transform.childCount);
            // Debug.Log("inside with" + i);
            Transform child = this.transform.parent.transform.GetChild(i);
            // if it finds one that has a testtube attached to it, assigns the liquid tht was parented to it's incubated as true 
            if (child.transform.childCount == 1)
            {
                //double check and see if this works, this is an adition LOOK HERE*******************
                if (child.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Liquid>())
                {
                    child.transform.GetChild(0).gameObject.transform.GetChild(2).GetComponent<Liquid>().setincubated(true);
                }

            }
        }
    }
}
