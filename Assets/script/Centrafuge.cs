using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centrafuge : MonoBehaviour
{
    private Transform tube1;
    private Transform tube2;

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
        centrafuge();
    }

    private void centrafuge()
    {
        //goes through the outer pairs of childeren
        foreach (Transform firstchild in transform)
        {
            //goes thorugh the second set of childeren
            foreach (Transform secondchild in firstchild.transform)
            {
                //sees if one of the childeren is a liquid
                if (secondchild.CompareTag("liquid"))
                {
                    tube1 = secondchild;
                    //finds the other child and sees if it also has a liquid child 
                    Transform partner = firstchild.transform.Find("paired");
                    if (partner.transform.GetChild(0).CompareTag("liquid"))
                    {
                        tube2 = partner;
                        liquidUpdate(tube1);
                        liquidUpdate(tube2);
                        print("Found both childeren");
                    }
                    else
                        print("did not find partner's child");
                }
                else
                    print("did not find matching childeren");
         
            }
            
        }
    }

    private void liquidUpdate(Transform tube)
    {
        if (tube.GetComponent<Liquid>().bacteria == false)
        {
            //will NOT load in a pellet asset 
            if (tube.GetComponent<Liquid>().phage1 == true || tube.GetComponent<Liquid>().phage2 == true)
            {
                //create an object of supernatant with HIGH rad

            }
            if (tube.GetComponent<Liquid>().phage1 == false && tube.GetComponent<Liquid>().phage2 == false)
            {
                //create an object of supernatant with no rad 
            }
        }
        else    // bacteria is true 
        {
            if (tube.GetComponent<Liquid>().phage1 == true && tube.GetComponent<Liquid>().phage2 == true)
            {
                //create a pellet with reg rad
                //create a supernatant with HIGH rad
            }
            if (tube.GetComponent<Liquid>().phage1 == true && tube.GetComponent<Liquid>().phage2 == false)
            {
                //create a pellet with HIGH rad 
                //create a supernatant with MILD rad
            }
            if (tube.GetComponent<Liquid>().phage1 == false && tube.GetComponent<Liquid>().phage2 == true)
            {
                //create a pellet with MILD rad
                //create a supernatant with HIGH rad
            }
            if (tube.GetComponent<Liquid>().phage1 == false && tube.GetComponent<Liquid>().phage2 == false)
            {
                //no pellets or supernatant 
            }
        }
    }
}
