using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    private void Awake()
    {   // eðer bir instance önceden var ise 
        if(_instance != null && _instance != this)
        {   //burada onu yok ediyoruz
            Destroy(this.gameObject);
        }
        else
        {   //burada onu yeni instance olarak atýyoruz
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd) {
        //önce deselect yapmamýzýn sebebi önceki seçili olanlarý unutmak çünkü shit ile týklamýyoruz
        DeSelectAll();
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);// karaktere týkladýðýmýzda seçili olduðunu gösteren alttaki quadýçalýþtýrýr
        unitToAdd.GetComponent<UnitMovement>().enabled = true; //hareket etmesi için
    }

    public void ShiftClickSelect(GameObject unitToAdd) {
        if (!unitSelected.Contains(unitToAdd))
        {   // eðer seçilmemiþ bir asker ise onu ekler
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {   // eðer seçilmiþ bir asker ise onu çýkarýr
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitSelected.Remove(unitToAdd);
        }
    }

    public void DragSelect(GameObject unitToAdd) {
        if (!unitSelected.Contains(unitToAdd))
        {
            unitSelected.Add (unitToAdd);
            unitToAdd.transform.GetChild (0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
    }


    public void DeSelectAll() {
        foreach(var unit in unitSelected)
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }

        unitSelected.Clear();
    }

    public void Deselect(GameObject unitToDeselect) { } 


}
