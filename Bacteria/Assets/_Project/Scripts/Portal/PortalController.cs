using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    //public GameObject[] enemies;
    public string nextLevelName;

    void Start()
    {
        //gameObject.SetActive(false);
    }


    void Update()
    {

        //gameObject.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Portal entered");
            SceneManager.LoadScene(nextLevelName);
        }
    }

}
