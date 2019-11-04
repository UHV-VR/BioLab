using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centrafuge : MonoBehaviour
{
    private Transform tube1;
    private Transform tube2;
    [SerializeField]
    private GameObject super;
    [SerializeField]
    private GameObject pellete;

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
        //foreach (Transform firstchild in transform)
        //{
        //    //goes thorugh the second set of childeren
        //    foreach (Transform secondchild in firstchild.transform)
        //    {
        //        //sees if one of the childeren is a liquid
        //        if (secondchild.CompareTag("interactable"))
        //        {
        //            tube1 = secondchild;
        //            //finds the other child and sees if it also has a liquid child 
        //            Transform partner = firstchild.transform.Find("paired");
        //            if (partner.transform.GetChild(0).CompareTag("liquid"))
        //            {
        //                tube2 = partner;
        //                liquidUpdate(tube1);
        //                liquidUpdate(tube2);
        //                print("Found both childeren");
        //            }
        //            else
        //                print("did not find partner's child");
        //        }
        //        else
        //            print("did not find matching childeren");

        //    }

        //}
        print(this.transform.Find("liquid"));
        liquidUpdate(this.transform.Find("liquid")); 
    }

    private void liquidUpdate(Transform tube)
    {
        if (tube.gameObject.GetComponent<Liquid>().getBacteria() == false)
        {
            //will NOT load in a pellet asset 
            if (tube.GetComponent<Liquid>().getphage1() == true || tube.GetComponent<Liquid>().getphage2() == true)
            {
                Instantiate(super, tube.transform.position, Quaternion.identity);
                GameObject assign = this.transform.Find("superlatent").gameObject;
                assign.transform.parent = tube.transform;
                assign.GetComponent<Raidioactive>().radioactivity = " HIGH";
                //create an object of supernatant with HIGH rad

            }
            if (tube.GetComponent<Liquid>().getphage1() == false && tube.GetComponent<Liquid>().getphage2() == false)
            {
                //create an object of supernatant with no rad 
            }
        }
        else    // bacteria is true 
        {
            if (tube.GetComponent<Liquid>().getphage1() == true && tube.GetComponent<Liquid>().getphage2() == true)
            {
                //create a pellet with reg rad
                //create a supernatant with HIGH rad
            }
            if (tube.GetComponent<Liquid>().getphage1() == true && tube.GetComponent<Liquid>().getphage2() == false)
            {
                //create a pellet with HIGH rad 
                //create a supernatant with MILD rad
            }
            if (tube.GetComponent<Liquid>().getphage1() == false && tube.GetComponent<Liquid>().getphage2() == true)
            {
                //create a pellet with MILD rad
                //create a supernatant with HIGH rad
            }
            if (tube.GetComponent<Liquid>().getphage1() == false && tube.GetComponent<Liquid>().getphage2() == false)
            {
                //no pellets or supernatant 
            }
        }
    }
}
