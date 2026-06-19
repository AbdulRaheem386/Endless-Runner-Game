using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_remover : MonoBehaviour
{

    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.z > transform.position.z + 48f)
        {
            Road_Spawner.instance.Spawn_Road();
            Destroy(this.gameObject);
        }
    }
}
