using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum ResourceType
{
    Stone,
    Iron,
    Gold
}
public class Mine : MonoBehaviour
{

    public ResourceType type;
    public int quantity;

    //events
    public UnityEvent onQuantityChange;

    public void GatherResource(int amount)
    {

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
