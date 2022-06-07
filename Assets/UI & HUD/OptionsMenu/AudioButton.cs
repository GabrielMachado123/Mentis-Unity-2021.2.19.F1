using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioButton : MonoBehaviour
{
    public GameObject displayOptions;
    public GameObject audioOptions;
    public Slider music;
    public Slider audio;
    public MusicMaster Master;

    public void Start()
    {
        music.value = 1;
        audio.value = 1;
    }

    public void AudioClick()
    {
        displayOptions.SetActive(false);
        audioOptions.SetActive(true);
    }

    public void UpdateMusic()
    {
        Master.Mvolume = music.value;
    }

    public void UpdateVolume()
    {
        Master.Svolume = audio.value;
    }
}
