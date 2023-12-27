using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderStats : MonoBehaviour
{

    public int health;
    public int damage;
    public int goldSpent;
    int arrowDamage = 2;

    ResourceAmount resourceAmount;
    public SoliderStatsR soliderStatsR;
    public SoliderStatsR soliderStatsRAx;
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RedArmy"))
        {
            // Eðer bina saldýrý altýnda deðilse, InvokeRepeating'i baþlat
            if (!isUnderAttack)
            {
                InvokeRepeating("AttackFrom", 1f, 1f);
                isUnderAttack = true;
            }
        }
        if (other.CompareTag("RedTower"))
        {
            if (!isUnderAttack)
            {
                InvokeRepeating("TowerAttack", 1f, 1f);
                isUnderAttack = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RedArmy"))
        {
            // Eðer bina saldýrý altýndaysa, InvokeRepeating'i iptal et
            if (isUnderAttack)
            {
                CancelInvoke("AttackFrom");
                isUnderAttack = false;
            }
        }
        if (other.CompareTag("RedTower"))
        {
            if (isUnderAttack)
            {
                CancelInvoke("TowerAttack");
                isUnderAttack = false;
            }
        }
    }

    void AttackFrom()
    {
        health -= soliderStatsR.damage;
        health -= soliderStatsRAx.damage;
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
