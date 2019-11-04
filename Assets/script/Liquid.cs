using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : World
{

    //private bool phage1 = false;

    // private bool bacteria = false;
    ////  [SerializeField]
    // // public bool bacteria { get; set; }
    // // [SerializeField]
    //  public bool phage1 { get; set; }
    // // [SerializeField]
    //  public bool phage2 { get; set; }
    // // [SerializeField]
    //  public bool shaken { get; set; }
    ////  [SerializeField]
    //  public bool incubated { get; set; }
    // // [SerializeField]
    //  public bool centrafuge { get; set; }

    [SerializeField]
    private bool phage1 = false;
    [SerializeField]
    private bool bacteria = false;

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
    public void setBacteria(bool value)
    {
        bacteria = value;
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

    public bool getBacteria()
    {
        return bacteria;
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
