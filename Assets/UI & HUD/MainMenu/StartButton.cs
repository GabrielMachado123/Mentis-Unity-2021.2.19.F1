using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject uICamera;
    public GameObject startDesc;
    public GameObject background;
    public MusicMaster master;
    // Start is called before the first frame update

    public void StartGame()
    {
        master.menuOn = false;
        uICamera.SetActive(false);
        gameObject.SetActive(false);

    }


    void OnMouseEnter()
    {
        background.SetActive(true);
        Debug.Log(background);
        startDesc.SetActive(true);

    }

    void OnMouseExit()
    {
        background.SetActive(false);
        startDesc.SetActive(false);
    }
}
