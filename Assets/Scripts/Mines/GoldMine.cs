using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    public int gold;
    ResourceAmount resourceAmount;
    public GameManagement gameManagement;
    void Start()
    {
        gold = Random.Range(200, 501);
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
        {if (other.CompareTag("BuildingMine"))
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
        if (gold >= 0)
        {
            gold -= 10;
            resourceAmount.goldNum += 10;
        }
        }
        if(gameManagement.playerNum == 2)
        {
            if (gold >= 0)
            {
                gold -= 10;
                resourceAmount.goldNumR += 10;
            }
        }
        
    }
}
