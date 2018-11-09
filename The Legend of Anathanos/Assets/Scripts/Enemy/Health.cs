using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int numOfHearths;

    private PlayerController pctrl;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        pctrl = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (pctrl.health>numOfHearths)
        {
            pctrl.health = numOfHearths;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if ( pctrl.health > i)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearths)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
