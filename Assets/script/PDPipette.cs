using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDPipette : Pipette
{
    private bool tipRange;
    private bool tip = false;

    private FixedJoint m_joint = null;

    //double check the assignment of tip
    //IF NEEDED, can remove the joint from the object 

    // Start is called before the first frame update
    private void Awake()
    {
        m_joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        //inside of an if that reads from the trackpad 

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "pipette")
        {
            setTipRange(true);
            assignTip(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "pipette")
        {
            setTipRange(false);
        }
    }
    public void setTipRange(bool value)
    {
        tipRange = value; 
    }
    public bool getTipRange()
    {
        return tipRange;
    }
   
    private void assignTip(Collider other)
    {
        //checks to see if we don't already have a tip
        if (tip)
        {
            return;
        }
        Debug.Log("got into the assign Tip");
        //ataches the tip to the joint and moves it around the tip of the pipette 
        gameObject.transform.parent = other.gameObject.transform.GetChild(4).gameObject.transform;
        gameObject.transform.position = other.gameObject.transform.GetChild(4).gameObject.transform.position;
        tip = true;

        Rigidbody targetbody = other.gameObject.GetComponent<Rigidbody>();
        m_joint.connectedBody = targetbody;
    }

    private void releaseTip()
    {
        if (!tip)
        {
            return;
        }
        //dont know if this actually works 
        this.gameObject.transform.GetChild(5).gameObject.transform.parent = null;
        tip = false;
        m_joint.connectedBody = null;
    }

}
