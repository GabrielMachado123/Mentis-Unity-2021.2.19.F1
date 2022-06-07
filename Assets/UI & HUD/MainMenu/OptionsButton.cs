using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    public GameObject optionsDesc;
    public GameObject background;
    public GameObject mainscreen;
    public GameObject options;
    // Start is called before the first frame update


    public void Start()
    {
        options.SetActive(false);
    }
    public void Options()
    {
        mainscreen.SetActive(false);
        options.SetActive(true);

        background.SetActive(false);
        optionsDesc.SetActive(false);
    }


    void OnMouseEnter()
    {
        background.SetActive(true);
        optionsDesc.SetActive(true);

    }

    void OnMouseExit()
    {
        background.SetActive(false);
        optionsDesc.SetActive(false);
    }
}
