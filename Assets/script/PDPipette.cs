using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDPipette : Pipette
{
    private bool tipRange;
    private bool tip = false;



    //double check the assignment of tip
    //IF NEEDED, can remove the joint from the object 

    // Start is called before the first frame update
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //sees if the trackpad is ever pushed downwards, deletes the pipette 

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
        if (other.name == "pipette")
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
        Quaternion rotation = other.gameObject.transform.GetChild(4).gameObject.transform.rotation;
        Debug.Log(other.name);
        //checks to see if we don't already have a tip
        if (tip)
        {
            return;
        }
        Debug.Log("got into the assign Tip");
        //ataches the tip to the joint and moves it around the tip of the pipette 
        this.transform.SetParent(other.gameObject.transform.GetChild(4).gameObject.transform);
        //this.transform.position = other.gameObject.transform.GetChild(4).gameObject.transform.position;
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = other.gameObject.transform.rotation;
        this.transform.rotation = Quaternion.Euler(-90, 0, 0);
        tip = true;
        Destroy(GetComponent<Interactable>());
        Destroy(GetComponent<Rigidbody>());

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

    }

}
