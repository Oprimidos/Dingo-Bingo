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
}
