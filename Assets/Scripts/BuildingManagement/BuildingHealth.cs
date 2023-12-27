using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHealth : MonoBehaviour
{
    public float health;
    public SoliderStatsR soliderStatsR;
    public SoliderStatsR soliderStatsRA;
    private bool isUnderAttack = false;

    public GameManagement gameManagement;
    // Update is called once per frame
    private void Start()
    {
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
    }
    void Update()
    {
        
            if (health <= 0)
            {
                // Eðer bina saldýrý altýndaysa, InvokeRepeating'i iptal et
                if (isUnderAttack)
                {
                    CancelInvoke("AttackFrom");
                }

                // Call a method to handle building destruction
                DestroyBuilding();
            }
        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("RedArmy"))
        {
            // Eðer bina saldýrý altýnda deðilse, InvokeRepeating'i baþlat
            if (!isUnderAttack)
            {
                InvokeRepeating("AttackFrom", 0f, 5f);
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
    }

    void AttackFrom()
    {
        health -= soliderStatsR.damage;
        health -= soliderStatsRA.damage;
    }

    void DestroyBuilding()
    {
        // Bina oyun nesnesini yok et
        Destroy(gameObject);
    }
}
