using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMine : MonoBehaviour
{
    public int stone;
    ResourceAmount resourceAmount;
    void Start()
    {
        stone = Random.Range(200, 501);
        resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BuildingMine"))
        {
            DecreaseResourceAndIncreaseAmount();
            InvokeRepeating("DecreaseResourceAndIncreaseAmount", 0f, 60f);
        }
    }

    void DecreaseResourceAndIncreaseAmount()//elimizde yeterli miktarda maden varsa onu madenden azaltýp kaynaða eklesin
    {
        if (stone >= 0)
        {
            stone -= 10;
            resourceAmount.stoneNum += 10;
        }
    }
}
