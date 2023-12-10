using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera myCam;
   // public GameObject groundMarker;

    public LayerMask clickable;
    public LayerMask ground;
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                // e�er t�klanabilir bir objeye t�klarsak

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    // e�er sol shifte bas�l�yken t�klarsak
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    // normal t�klarsak
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
                // e�er bo� araziye t�klarsak ve shift ile t�klam�yorsak

                if (!Input.GetKey(KeyCode.LeftShift))
                {
                  UnitSelections.Instance.DeSelectAll();
                }
             
            }
        }

       /* if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position=hit.point;
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);


            }

        }*/
    }
}
