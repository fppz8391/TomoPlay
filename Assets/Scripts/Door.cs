using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void ChangeScene()
    {
        Debug.Log("change Scene");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Invoke("ChangeScene", 0.5f);
        gameObject.SetActive(false);
    }
}
