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

    BuildingManager buildingManager;
    ResourceAmount resourceAmount;

    int axemanCost = 100;
    int swordManCost = 60;

    // Start is called before the first frame update
    void Start()
    {
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
        if (buildingManager.barrackCount > 0)
        {
            swordManB.gameObject.SetActive(true);
        }
        if (buildingManager.axeManCount > 0)
        {
            axeManB.gameObject.SetActive(true);
        }
    }

    public void ProduceSwordMan()//swordman üretiyor
    {
        if (buildingManager.barrackCount > 0 && resourceAmount.ironNum >= swordManCost )
        {
            Vector3 spawnPosition = GetRandomSpawnPosition(buildingManager.barrackLocation);
            Instantiate(swordManPrefab, spawnPosition, Quaternion.identity);
            resourceAmount.ironNum -= swordManCost;
        }
    }

    void ProduceAxeMan()//axeman üretiyor
    {
        if (buildingManager.axeManCount > 0 && resourceAmount.ironNum >= axemanCost)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition(buildingManager.axeManLocation);
            Instantiate(axeManPrefab, spawnPosition, Quaternion.identity);
            resourceAmount.ironNum -= axemanCost;
        }
    }

    Vector3 GetRandomSpawnPosition(Vector3 baseLocation)//askerlerin spawn noktasýný beliyrliyor
    {
        float randomX = Random.Range(baseLocation.x - 10f, baseLocation.x + 10f);
        float randomZ = Random.Range(baseLocation.z - 10f, baseLocation.z + 10f);
        return new Vector3(randomX, 5f, randomZ);
    }
}
