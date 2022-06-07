using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject mainscreen;
    public GameObject options;
    // Start is called before the first frame update

    public void Back()
    {
        mainscreen.SetActive(true);
        options.SetActive(false);
    }
}
