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
        InvokeRepeating("Salary", 60f, 60f); //60 saniyede bir �al��t�r�r
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // E�er asker sald�r� alt�ndaysa, InvokeRepeating'i iptal et
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
        //her 1 dakikada hazieden asker ba��na alt�n eksiltecek
        if (resourceAmount.goldNumR >= goldSpent)//yeterli alt�n var m� kontrol
        {
            resourceAmount.goldNumR -= goldSpent;
        }
        else
        {
            // Yetersiz alt�n durumunda GameObject'i yok et
            Debug.LogWarning("Yetersiz alt�n! Asker yok ediliyor.");
            Destroy(gameObject);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BlueArmy"))
        {
            // E�er bina sald�r� alt�nda de�ilse, InvokeRepeating'i ba�lat
            if (!isUnderAttack)
            {
                InvokeRepeating("AttackFrom", 1f, 1f);
                isUnderAttack = true;
            }
        }
        if (other.CompareTag("Tower"))
        {
            // E�er bina sald�r� alt�nda de�ilse, InvokeRepeating'i ba�lat
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
            // E�er bina sald�r� alt�ndaysa, InvokeRepeating'i iptal et
            if (isUnderAttack)
            {
                CancelInvoke("AttackFrom");
                isUnderAttack = false;
            }
        }
        if (other.CompareTag("Tower"))
        {
            // E�er bina sald�r� alt�ndaysa, InvokeRepeating'i iptal et
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
