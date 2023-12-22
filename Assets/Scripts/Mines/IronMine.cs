using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMine : MonoBehaviour
{
    public int iron;
    ResourceAmount resourceAmount;
    private BuildingManager buildingManager;
    void Start()
    {
        iron = Random.Range(200, 501);
        resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        
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
        if (iron >= 0)
        {
            iron -= 10 ;
            resourceAmount.ironNum += 10;
        }
    }
}
