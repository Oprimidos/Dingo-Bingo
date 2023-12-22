using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderStats : MonoBehaviour
{

    public int health;
    public int damage;
    public int goldSpent;

    ResourceAmount resourceAmount;
    // Start is called before the first frame update
    void Start()
    {
        resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
        InvokeRepeating("Salary", 60f, 60f); //60 saniyede bir çalýþtýrýr
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Salary()
    {
        //her 1 dakikada hazieden asker baþýna altýn eksiltecek
        if(resourceAmount.goldNum >= goldSpent)//yeterli altýn var mý kontrol
        {
            resourceAmount.goldNum -= goldSpent;
        }
        else
        {
            // Yetersiz altýn durumunda GameObject'i yok et
            Debug.LogWarning("Yetersiz altýn! Asker yok ediliyor.");
            Destroy(gameObject);
        }
        
    }
}
