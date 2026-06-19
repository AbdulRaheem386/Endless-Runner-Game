using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_Page : MonoBehaviour
{
    public GameObject Loadingtext;
    public GameObject tabtostart;

    // Start is called before the first frame update
    void Start()
    {
        tabtostart.SetActive(false);
        Invoke("ShowTabToStart", 4f);
    }

    void ShowTabToStart()
    {
        Loadingtext.SetActive(false);
        tabtostart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       if(tabtostart.activeSelf && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("SampleScene");
        } 
    }
}
