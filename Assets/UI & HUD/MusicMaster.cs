using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMaster : MonoBehaviour
{
    public bool menuOn;
    public float Mvolume;
    public float Svolume;
    public AudioSource menuMusic;
    public GameObject options;
    // Start is called before the first frame update
    void Start()
    {
        menuOn = true;
        menuMusic.volume = 1;
        Mvolume = 1;
        Svolume = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (options.activeSelf)
        {
            menuMusic.volume = Mvolume;
        }

        if (!menuOn)
        {
            menuMusic.Stop();
        }
        
    }
}
