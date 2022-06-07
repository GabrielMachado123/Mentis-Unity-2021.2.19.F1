using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public AudioClip BossMusic;
    public ChekIfInBossRoom ck;

    public AudioSource Source;

    public MusicMaster Master;
    private bool HasPlayed = false;
    private bool HasPlayed2 = false;
    private void Start()
    {
   
        Source = gameObject.GetComponent<AudioSource>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if(ck.IsInBossRoom)
        {
            Source.clip = BossMusic;
            if(!HasPlayed)
            {
                Source.volume = Master.Mvolume;
                Source.Play();
                HasPlayed = true;
            }
            
        }
        else if(!Master.menuOn && !HasPlayed2)
        {
            Source.volume = Master.Mvolume;
            Source.Play();
            HasPlayed2 = true;
        }
    }
}
