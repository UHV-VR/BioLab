using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : LiquidContainer
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerStay(Collider other)
    {
        //checks to see if we now have a child
        if (this.transform.childCount > 0)
        {
            Transform child = this.transform.GetChild(0);
            if (child.transform.GetComponent<Liquid>() != null)
            {
                child.transform.GetComponent<Liquid>().bacteria = true;

            }
        }

    }


}
