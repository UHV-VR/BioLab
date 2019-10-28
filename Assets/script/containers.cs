using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Containers : World
{
    //Purpose: will move an object released inside range if it is a test tube
    // Start is called before the first frame update
    private bool inrange = false;
    private GameObject toassign;
    private int spots = 0;
    [SerializeField]
    private GameObject[] childeren = new GameObject[3];
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //will assign the gameobject here when the button is pressed within the range of the object 
        //will call assigntoSlot 

        if ((!rright.GetComponent<Hand>().triggerDown && !rleft.GetComponent<Hand>().triggerDown))
        {
            // Debug.Log("able to get inside of if for the remotes ");
            //sees if the remote is in range 
            if (inrange)
            {
                assigntoSlot(toassign);
                toassign = null;
                inrange = false;
            }
        }
    }
    //sees if the collider is something that can be assigned to a container 

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<LiquidContainer>())
        {
            if (other.GetComponent<LiquidContainer>().getTag() == "testTube")
            {
                //Debug.Log("testtube in range ");
                inrange = true;
                toassign = other.gameObject;
            }
        }

    }
    //sees if the collider that is leaving could have been assigned to the container 
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<LiquidContainer>())
        {
            Debug.Log("leaving collider");
            //not entering if 
            if (other.GetComponent<LiquidContainer>().getTag() == "testTube")
            {
                Debug.Log("testtube leaving range");
                removeSlot(other.gameObject);
                inrange = false;
                toassign = null;
                other.transform.parent = null;
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                
            }
        }
    }
    //assigns the object to one of the empty objects that are placed on each of the empty spaces 
    public void assigntoSlot(GameObject assignment)
    {

        if (assignment == null)
        {
            return;
        }
        else if (spots == 3)
            return;
        Transform child;

        //works through child array to find a child that does not have a test tube 
        for (int i = 0; i < childeren.Length; i++)
        {
            child = gameObject.transform.GetChild(i);
            if (child.transform.childCount == 0)
            {

                assignment.transform.position = child.transform.position;
                assignment.transform.parent = child.transform;
                //zeros all physics on assigment so that it will stay still
                assignment.GetComponent<Rigidbody>().velocity = Vector3.zero;
                assignment.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                childeren[i] = assignment;
                spots++;
                return;
            }


        }
        /* assignment.transform.position = child.transform.position;
         assignment.transform.parent = child.transform;
         //zeros all physics on assigment so that it will stay still
         assignment.GetComponent<Rigidbody>().velocity = Vector3.zero;
         assignment.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        */

        return;

    }
    //removes from the spot counter, allowing to assign to old positions 
    public void removeSlot(GameObject remove)
    {
        Transform child;
        //goes through the array of assigned test tubes 
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            child = this.transform.GetChild(i);
            //grabs a child with the same element value
            //sees if that child has a child 
            if (child.GetChild(0) != null)
            {
                //*********** NOT TOO SURE IF THIS WILL WORK, MUST TRY!!
                //sees if that child is the same object that is leaving the scope 
                if (child.GetChild(0).name == remove.name)
                {
                    //removes that object from the array 
                    childeren[i] = null;
                }
            }
        }
        spots--;
    }
}
