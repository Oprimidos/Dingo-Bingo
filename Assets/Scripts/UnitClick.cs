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
                // eðer týklanabilir bir objeye týklarsak

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    // eðer sol shifte basýlýyken týklarsak
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    // normal týklarsak
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
                // eðer boþ araziye týklarsak ve shift ile týklamýyorsak

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
