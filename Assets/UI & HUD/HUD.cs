using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public PlayerMovement player;
    public RectTransform health;
    public RectTransform mana;
    public Image manaFront;
    public Image manaBack;
    public RectTransform overdrive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.sizeDelta = new Vector2(50, player.health * 2);
        mana.sizeDelta = new Vector2(50, player.mana * 5);
        overdrive.sizeDelta = new Vector2(player.overchargeVal * 5, 25);

        if (player.manaRecharge)
        {
            manaFront.color = new Color(1, 0, 0.4f);
            manaBack.color = new Color(0.4f, 0, 0.1f);
        }
        else
        {
            manaFront.color = new Color(0, 0.7f, 1);
            manaBack.color = new Color(0, 0.2f, 0.4f);
        }
    }
}
