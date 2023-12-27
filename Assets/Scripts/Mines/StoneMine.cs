using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMine : MonoBehaviour
{
    public int stone;
    ResourceAmount resourceAmount;
    public GameManagement gameManagement;
    void Start()
    {
        stone = Random.Range(200, 501);
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(gameManagement.playerNum == 1)
        {
            if (other.CompareTag("BuildingMine"))
            {
                DecreaseResourceAndIncreaseAmount();
                InvokeRepeating("DecreaseResourceAndIncreaseAmount", 0f, 60f);
            }
        }
        if(gameManagement.playerNum == 2)
        {
            if (other.CompareTag("BuildingMineRed"))
            {
                DecreaseResourceAndIncreaseAmount();
                InvokeRepeating("DecreaseResourceAndIncreaseAmount", 0f, 60f);
            }
        }
        
    }

    void DecreaseResourceAndIncreaseAmount()//elimizde yeterli miktarda maden varsa onu madenden azaltýp kaynaða eklesin
    {
        if(gameManagement.playerNum == 1)
        {
            if (stone >= 0)
            {
                stone -= 10;
                resourceAmount.stoneNum += 10;
            }
        }
        if(gameManagement.playerNum == 2)
        {
            if (stone >= 0)
            {
                stone -= 10;
                resourceAmount.stoneNumR += 10;
            }
        }
        
    }
}
