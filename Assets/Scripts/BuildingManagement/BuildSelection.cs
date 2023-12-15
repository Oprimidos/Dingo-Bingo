using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildSelection : MonoBehaviour
{
    public GameObject selectedObject;
    public TextMeshProUGUI objNameText;
    private BuildingManager buildingManager;

    public GameObject objUI;
    // Start is called before the first frame update
    void Start()
    {
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.CompareTag("Building"))
                {
                    Select(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Deselect();
        }
    }

    private void Select(GameObject obj) // binalarý seçmemizi saðlýyor
    {
        if (obj == selectedObject)
        {
            return;
        }
        if (selectedObject != null)
        {
            Deselect();
        }
        Outline outline = obj.GetComponent<Outline>();
        if (outline == null)
        {
            obj.AddComponent<Outline>();
        }
        else
        {
            outline.enabled = true;
        }
        objNameText.text = obj.name;// bina adýný direkt text mexhe atýyor
        objUI.SetActive(true);//bina UI açýyor
        selectedObject = obj;

    }

    private void Deselect()
    {
        objUI.SetActive(false);//bina UI gizliyor
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }

    public void Move()//binayý hareket ettirme butonu için
    {
        buildingManager.pendingObject = selectedObject;
    }

    public void Delete()// binayý silme butonu için
    {
        GameObject objToDestroy = selectedObject;
        Deselect();
        Destroy(objToDestroy);
    }
}