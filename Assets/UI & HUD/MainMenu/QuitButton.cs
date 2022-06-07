using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public GameObject quitDesc;
    public GameObject background;
    // Start is called before the first frame update

    public void QuitGame()
    {
        Application.Quit();
    }


    void OnMouseEnter()
    {
        background.SetActive(true);
        quitDesc.SetActive(true);

    }

    void OnMouseExit()
    {
        background.SetActive(false);
        quitDesc.SetActive(false);
    }
}
