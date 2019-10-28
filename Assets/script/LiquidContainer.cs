using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidContainer : World
{
    private string Tag = "testTube";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setTag(string value)
    {
        Tag = value;
    }
    public string getTag()
    {
        return Tag;
    }
}
