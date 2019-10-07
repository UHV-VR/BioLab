using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class containers : MonoBehaviour
{
    //Purpose: will move an object released inside range if it is a test tube
    // Start is called before the first frame update
    private bool inrange = false;
    private GameObject toassign;
    private int spots = 0; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //will assign the gameobject here when the button is pressed within the range of the object 
        //will call assigntoSlot 
    }
    //sees if the collider is something that can be assigned to a container 

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "testTube")
        {
            inrange = true;
            toassign = other.gameObject;
        }
    }
    //sees if the collider that is leaving could have been assigned to the container 
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "testTube")
        {
            inrange = false;
            toassign = null;
        }
    }
    //assigns the object to one of the empty objects that are placed on each of the empty spaces 
    public void assigntoSlot(GameObject assignment)
    {
        if (assignment == null)
        {
            return;
        }
        Transform child = gameObject.transform.GetChild(spots);
        assignment.transform.position = child.transform.position;
        assignment.transform.parent = child.transform;
        spots++;
        return;
           
    }
    //removes from the spot counter, allowing to assign to old positions 
    public void removeSlot()
    {
        //when to call this?? 
        spots--;
    }
}
