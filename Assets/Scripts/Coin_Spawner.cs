using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Coin_Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int mincoins = 3;
    public int maxcoins = 8;

    private void OnEnable()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        int count = Random.Range(mincoins, maxcoins);

        for(int i=0; i < count; i++)
        {
            Vector3 pos = transform.position + new Vector3(Random.Range(-1f, 1f), 0.5f, Random.Range(-5f, 5f));

            GameObject coin = Instantiate(coinPrefab, pos, Quaternion.identity, transform);
        }

        
    }

    private void OnDisable()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

}
