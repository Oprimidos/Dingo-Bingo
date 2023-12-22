using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMine : MonoBehaviour
{
    public int gold;
    ResourceAmount resourceAmount;
    void Start()
    {
        gold = Random.Range(200, 501);
        resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
