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
    {   // e�er bir instance �nceden var ise 
        if(_instance != null && _instance != this)
        {   //burada onu yok ediyoruz
            Destroy(this.gameObject);
        }
        else
        {   //burada onu yeni instance olarak at�yoruz
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd) {
        //�nce deselect yapmam�z�n sebebi �nceki se�ili olanlar� unutmak ��nk� shit ile t�klam�yoruz
        DeSelectAll();
        unitSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);// karaktere t�klad���m�zda se�ili oldu�unu g�steren alttaki quad��al��t�r�r
        unitToAdd.GetComponent<UnitMovement>().enabled = true; //hareket etmesi i�in
    }

    public void ShiftClickSelect(GameObject unitToAdd) {
        if (!unitSelected.Contains(unitToAdd))
        {   // e�er se�ilmemi� bir asker ise onu ekler
            unitSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {   // e�er se�ilmi� bir asker ise onu ��kar�r
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
