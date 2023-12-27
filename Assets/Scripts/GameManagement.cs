using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagement : MonoBehaviour
{
    public int playerNum;

    // Tekil GameManagement instance'�
    private static GameManagement instance;

    private void Awake()
    {
        // E�er instance daha �nce olu�turulmam��sa, bu nesneyi don't destroy on load olarak i�aretle
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // E�er daha �nce bir instance varsa, bu nesneyi yok et (��nk� zaten bir tane olmal�)
            Destroy(gameObject);
        }
    }

    public void makeBlue()
    {
        playerNum = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void makeRed()
    {
        playerNum = 2;
        SceneManager.LoadScene("GameScene");
    }
}

