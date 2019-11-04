using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Pipette : World
{
    private bool inReachTube;
    private bool iteration = false;
    private string content;
    private Transform liquid;
    private GameObject current;

    private GameObject inreach;

    // Start is called before the first frame update
    void Start()
    {
        current = gameObject;
    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {

        if ((rright.GetComponent<Hand>().padDown || rleft.GetComponent<Hand>().padDown) && (rright.GetComponent<Hand>().held == gameObject.name || rleft.GetComponent<Hand>().held == gameObject.name))
        {
            if (!iteration)
            {

                if (inReachTube)
                {
                    if (!current.transform.Find("liquid"))
                    {
                        Debug.Log("am inside the if that calls the liquid in");
                        setLiquid(gameObject, inreach);
                    }
                    else
                    {
                        Debug.Log("am inside the if that calls to release liquid");
                        setLiquid(inreach, gameObject);
                    }
                    //could add an else here to remove the liquid but need a different update
                }
                iteration = true;
            }

        }
        else
            iteration = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<LiquidContainer>())
        {
            if (other.gameObject.GetComponent<LiquidContainer>().getTag() == "testTube")
            {
                inReachTube = true;
                inreach = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<LiquidContainer>())
        {
            if (other.gameObject.GetComponent<LiquidContainer>().getTag() == "testTube")
            {
                inReachTube = false;
                inreach = null;
            }
        }
    }

    //assigns the liquid to this object as a child
    public void setLiquid(GameObject parent, GameObject previousHolder)
    {
        liquid = previousHolder.transform.Find("liquid");
        liquid.transform.SetParent(parent.transform);
        Debug.Log("got into transferliquid");
        //parent.transform.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        //previousHolder.transform.gameObject.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.grey);
    }


    public string getContent()
    {
        return content;
    }
    public void setContent(string value)
    {
        content = value;
    }

}
