using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Transform Player;
    bool collected = false;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (collected) return;

        float distance = Vector3.Distance(transform.position, Player.position);

        if(distance < 1.2f)
        {
            collected = true;

            int coins = PlayerPrefs.GetInt("total_coins", 0) + 1;
            PlayerPrefs.SetInt("total_coins", coins);
            PlayerPrefs.Save();


            Destroy(gameObject);
        }
    }
}
