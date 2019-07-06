using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverImage : MonoBehaviour
{

    GameOverManager gameOverManager;
    // Start is called before the first frame update
    void Start()
    {
        gameOverManager = GameObject.Find("GameOverManager").GetComponent<GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTitleScene()
    {
        gameOverManager.LoadTitleScene();
    }
}
