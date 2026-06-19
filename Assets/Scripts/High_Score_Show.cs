using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class High_Score_Show : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI high_score_text;

    Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        high_score_text.text = PlayerPrefs.GetFloat("high_score", 0).ToString("00.0") + "m";
    }
}
