using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildSelection : MonoBehaviour
{
    public GameObject selectedObject;
    public TextMeshProUGUI objNameText;
    public TextMeshProUGUI healthText; // Reference to UI Text component for displaying health
    private BuildingManager buildingManager;
    public GameManagement gameManagement;

    public GameObject objUI;

    public GameObject basePanelUI;
    public GameObject housePanelUI;
    public GameObject minePanelUI;
    public GameObject barrackPanelUI;
    public GameObject axeManPanelUI;
    public GameObject arrowTowerPanelUI;

    // Start is called before the first frame update
    void Start()
    {
        gameManagement = GameObject.Find("GameManagement").GetComponent<GameManagement>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (gameManagement.playerNum == 1)
            {
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.collider.gameObject.CompareTag("Building") || hit.collider.gameObject.CompareTag("Tower") || hit.collider.gameObject.CompareTag("BuildingMine"))
                    {
                        Select(hit.collider.gameObject);
                    }
                }
            }
            if(gameManagement.playerNum == 2)
            {
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.collider.gameObject.CompareTag("BuildingRed") || hit.collider.gameObject.CompareTag("RedTower") || hit.collider.gameObject.CompareTag("BuildingMineRed"))
                    {
                        Select(hit.collider.gameObject);
                    }
                }
            }
            
        }
        if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            Deselect();
        }
    }

    private void Select(GameObject obj)
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
        objNameText.text = obj.name;
        objUI.SetActive(true);
        selectedObject = obj;

        // Check if the selected object has a BuildingHealth component
        BuildingHealth buildingHealth = obj.GetComponent<BuildingHealth>();
        if (buildingHealth != null)
        {
            // Display the health in the UI
            healthText.text = "Health: " + buildingHealth.health.ToString("F0");
        }
        else
        {
            // If the selected object doesn't have BuildingHealth, hide the health text
            healthText.text = "";
        }
    }

    private void Deselect()
    {
        objUI.SetActive(false);
        selectedObject.GetComponent<Outline>().enabled = false;
        selectedObject = null;
    }

    public void Delete()
    {
        GameObject objToDestroy = selectedObject;
        Deselect();
        Destroy(objToDestroy);
    }
}
