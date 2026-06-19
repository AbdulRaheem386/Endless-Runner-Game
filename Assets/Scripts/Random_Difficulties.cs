using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Difficulties : MonoBehaviour
{

    public GameObject[] difficulties;
    public bool IsDefault;

    // Start is called before the first frame update
    void Start()
    {
        if (!IsDefault)
        {
            int random_value = Random.Range(0, difficulties.Length);

            difficulties[random_value].gameObject.SetActive(true);
        }
    }

   
}
