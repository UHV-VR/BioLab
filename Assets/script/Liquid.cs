using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : World
{
    [SerializeField]
    private bool phage1 = false;
    [SerializeField]
    private bool phage2 = false;
    [SerializeField]
    private bool shaken = false;
    [SerializeField]
    private bool incubated = false;
    [SerializeField]
    private bool centrafuge = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setphage1( bool value)
    {
        phage1 = value;
    }

    public void setphage2(bool value)
    {
        phage2 = value;
    }

    public void setshaken(bool value)
    {
        shaken = value;
    }

    public void setincubated(bool value)
    {
        incubated = value;
    }

    public void setcentrafugec(bool value)
    {
        centrafuge = value;
    }

    public bool getphage1()
    {
        return phage1;
    }

    public bool getphage2()
    {
        return phage2;
    }

    public bool getshaken()
    {
        return shaken;
    }

    public bool getincubated()
    {
        return incubated;
    }

    public bool getcentrafuge()
    {
        return centrafuge;
    }
}
