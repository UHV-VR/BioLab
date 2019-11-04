using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Vortex : World
{
    public SteamVR_Action_Vibration hapticAction;

    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.GetComponent<LiquidContainer>().getTag() == "testTube")
        {
            if (rright.GetComponent<Hand>().name == other.name)
            {
                Pulse(4, 150, 75, SteamVR_Input_Sources.RightHand);
            }
            else if (rleft.GetComponent<Hand>().name == other.name)
            {
                Pulse(1, 150, 75, SteamVR_Input_Sources.LeftHand);
            }
            other.transform.Find("liquid").GetComponent<Liquid>().setshaken(true);
        }
    }



    public void Pulse(float duration, float frequency, float amplitude, SteamVR_Input_Sources source)

    {
        hapticAction.Execute(0, duration, frequency, amplitude, source);
        print("pulse" + " " + source.ToString());
    }



}
