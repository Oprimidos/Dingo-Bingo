using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagement : MonoBehaviour
{
    public int playerNum;

    // Tekil GameManagement instance'ý
    private static GameManagement instance;

    private void Awake()
    {
        // Eðer instance daha önce oluþturulmamýþsa, bu nesneyi don't destroy on load olarak iþaretle
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Eðer daha önce bir instance varsa, bu nesneyi yok et (çünkü zaten bir tane olmalý)
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

