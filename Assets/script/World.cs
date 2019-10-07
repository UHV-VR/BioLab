using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    string info;

    //[SerializeField]
    public GameObject rright;

    // [SerializeField]
    public GameObject rleft;
    //sound sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setInfo(string value)
    {
        info = value; 
    }
    public string getInfo()
    {
        return info;
    }

}
