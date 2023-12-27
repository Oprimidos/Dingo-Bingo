using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderStatsR : MonoBehaviour
{
    public int health;
    public int damage;
    public int goldSpent;
    int arrowDamage = 2;

    public SoliderStats soliderStats;
    public SoliderStats soliderStatsAx;
    ResourceAmount resourceAmount;
    private bool isUnderAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
        InvokeRepeating("Salary", 60f, 60f); //60 saniyede bir çalýþtýrýr
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // Eðer asker saldýrý altýndaysa, InvokeRepeating'i iptal et
            if (isUnderAttack)
            {
                CancelInvoke("AttackFrom");
                CancelInvoke("TowerAttack");
            }

            // Call a method to handle solider destruction
            DestroySolider();
        }
    }

    void Salary()
    {
        //her 1 dakikada hazieden asker baþýna altýn eksiltecek
        if (resourceAmount.goldNumR >= goldSpent)//yeterli altýn var mý kontrol
        {
            resourceAmount.goldNumR -= goldSpent;
        }
        else
        {
            // Yetersiz altýn durumunda GameObject'i yok et
            Debug.LogWarning("Yetersiz altýn! Asker yok ediliyor.");
            Destroy(gameObject);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BlueArmy"))
        {
            // Eðer bina saldýrý altýnda deðilse, InvokeRepeating'i baþlat
            if (!isUnderAttack)
            {
                InvokeRepeating("AttackFrom", 1f, 1f);
                isUnderAttack = true;
            }
        }
        if (other.CompareTag("Tower"))
        {
            // Eðer bina saldýrý altýnda deðilse, InvokeRepeating'i baþlat
            if (!isUnderAttack)
            {
                InvokeRepeating("TowerAttack", 1f, 1f);
                isUnderAttack = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BlueArmy"))
        {
            // Eðer bina saldýrý altýndaysa, InvokeRepeating'i iptal et
            if (isUnderAttack)
            {
                CancelInvoke("AttackFrom");
                isUnderAttack = false;
            }
        }
        if (other.CompareTag("Tower"))
        {
            // Eðer bina saldýrý altýndaysa, InvokeRepeating'i iptal et
            if (isUnderAttack)
            {
                CancelInvoke("TowerAttack");
                isUnderAttack = false;
            }
        }
    }




    void AttackFrom()
    {
        health -= soliderStats.damage;
        health -= soliderStatsAx.damage;
    }
    void TowerAttack()
    {
        health -= arrowDamage;
    }
    void DestroySolider()
    {
        // Bina oyun nesnesini yok et
        Destroy(gameObject);
    }
}
