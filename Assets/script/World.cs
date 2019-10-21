using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class World : MonoBehaviour
{
    string info;
    public Sounds[] sounds;

    //[SerializeField]
    public GameObject rright = GameObject.Find("Controller (right)");

    // [SerializeField]
    public GameObject rleft = GameObject.Find("Controller (left)");
    //sound sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        //  PURHAPS NEED TO DELAY THE IS PLAYING BY RANDOM VALUES??
        //  NEED TO FIGURE THIS OUT!
        if (s == null && !(s.isplaying()))
        {
            Debug.Log("sound: " + name + " is not found ");
            return;
        }
        s.source.Play();
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
