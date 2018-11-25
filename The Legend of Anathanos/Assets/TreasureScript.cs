using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour {

    public int priceMin,priceMax;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Player")
        {
            PlayerController pc = hitInfo.GetComponent<PlayerController>();
            pc.money=pc.money+ Random.Range(priceMin,priceMax);
            Destroy(gameObject);
            pc.moneyText.text = "Money: " + pc.money.ToString();
        }
        else
        {

        }
    }
}
