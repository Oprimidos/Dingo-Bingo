using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonArmyManagement : MonoBehaviour
{
    public Button swordManB;
    public Button axeManB;

    public GameObject swordManPrefab;
    public GameObject axeManPrefab;

    public GameObject swordManPrefabR;
    public GameObject axeManPrefabR;

    BuildingManager buildingManager;
    ResourceAmount resourceAmount;

    int axemanCost = 100;
    int swordManCost = 60;

    public GameManagement gameManagement;

    // Start is called before the first frame update
    void Start()
    {
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
        swordManB.onClick.AddListener(ProduceSwordMan);
        axeManB.onClick.AddListener(ProduceAxeMan);
        swordManB.gameObject.SetActive(false);
        axeManB.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckBuilding();
    }

    void CheckBuilding()// barrcak veya axeMan binalarý inþaa edilmiþmi diye kontrol
    {

    if(gameManagement.playerNum == 1)
        {if (buildingManager.barrackCount > 0)
        {
            swordManB.gameObject.SetActive(true);
        }
        if (buildingManager.axeManCount > 0)
        {
            axeManB.gameObject.SetActive(true);
        }
        }
        if(gameManagement.playerNum == 2)
        {
            if (buildingManager.barrackCountR > 0)
            {
                swordManB.gameObject.SetActive(true);
            }
            if (buildingManager.axeManCountR > 0)
            {
                axeManB.gameObject.SetActive(true);
            }

        }
        
    }

    public void ProduceSwordMan()//swordman üretiyor
    {
        if(gameManagement.playerNum == 1)
        {
if (buildingManager.barrackCount > 0 && resourceAmount.ironNum >= swordManCost )
        {
            Vector3 spawnPosition = GetRandomSpawnPosition(buildingManager.barrackLocation);
            Instantiate(swordManPrefab, spawnPosition, Quaternion.identity);
            resourceAmount.ironNum -= swordManCost;
        }
        }
        if(gameManagement.playerNum == 2)
        {
            if (buildingManager.barrackCountR > 0 && resourceAmount.ironNumR >= swordManCost)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition(buildingManager.barrackLocationR);
                Instantiate(swordManPrefabR, spawnPosition, Quaternion.identity);
                resourceAmount.ironNumR -= swordManCost;
            }
        }
        
    }

    void ProduceAxeMan()//axeman üretiyor
    {
        if(gameManagement.playerNum == 1)
        {
            if (buildingManager.axeManCount > 0 && resourceAmount.ironNum >= axemanCost)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition(buildingManager.axeManLocation);
                Instantiate(axeManPrefab, spawnPosition, Quaternion.identity);
                resourceAmount.ironNum -= axemanCost;
            }
        }
        if (gameManagement.playerNum == 2)
        {
            if (buildingManager.axeManCountR > 0 && resourceAmount.ironNumR >= axemanCost)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition(buildingManager.axeManLocationR);
                Instantiate(axeManPrefabR, spawnPosition, Quaternion.identity);
                resourceAmount.ironNumR -= axemanCost;
            }
        }
        
    }

    Vector3 GetRandomSpawnPosition(Vector3 baseLocation)//askerlerin spawn noktasýný beliyrliyor
    {
        float randomX = Random.Range(baseLocation.x - 10f, baseLocation.x + 10f);
        float randomZ = Random.Range(baseLocation.z - 10f, baseLocation.z + 10f);
        return new Vector3(randomX, 5f, randomZ);
    }
}
