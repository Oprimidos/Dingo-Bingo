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
        InvokeRepeating("Salary", 60f, 60f); //60 saniyede bir �al��t�r�r
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Salary()
    {
        //her 1 dakikada hazieden asker ba��na alt�n eksiltecek
        if(resourceAmount.goldNum >= goldSpent)//yeterli alt�n var m� kontrol
        {
            resourceAmount.goldNum -= goldSpent;
        }
        else
        {
            // Yetersiz alt�n durumunda GameObject'i yok et
            Debug.LogWarning("Yetersiz alt�n! Asker yok ediliyor.");
            Destroy(gameObject);
        }
        
    }
}
