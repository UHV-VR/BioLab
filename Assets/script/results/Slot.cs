using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : World
{
    private bool inrange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerStay(Collider assignment)
    {
         if ((!rright.GetComponent<Hand>().triggerDown && !rleft.GetComponent<Hand>().triggerDown))
        {
             //Debug.Log("able to get inside of if for the remotes ");
            //sees if the remote is in range 
            //if (inrange)
            {
                assignment.transform.position = this.transform.position;
                assignment.transform.parent = this.transform;
                //zeros all physics on assigment so that it will stay still
                assignment.GetComponent<Rigidbody>().velocity = Vector3.zero;
                assignment.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
