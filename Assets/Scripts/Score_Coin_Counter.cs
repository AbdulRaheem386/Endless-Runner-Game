using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score_Coin_Counter : MonoBehaviour
{
    

    [SerializeField] TextMeshProUGUI total_coins_text;
    [SerializeField] TextMeshProUGUI total_score_text;

    [SerializeField] Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("total_coins", 0);
    }

    // Update is called once per frame
    void Update()
    {
        total_coins_text.text = PlayerPrefs.GetInt("total_coins", 0).ToString("00");

        total_score_text.text = Player.transform.position.z.ToString("00.0") + "m";

        if(Player.transform.position.z >= PlayerPrefs.GetFloat("high_score", 0f))
        {
            PlayerPrefs.SetFloat("high_score", Player.transform.position.z);
        }
    }

   
}
