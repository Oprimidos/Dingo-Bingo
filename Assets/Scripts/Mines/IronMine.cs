using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMine : MonoBehaviour
{
    public int iron;
    ResourceAmount resourceAmount;
    void Start()
    {
        iron = Random.Range(200, 501);
        resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
