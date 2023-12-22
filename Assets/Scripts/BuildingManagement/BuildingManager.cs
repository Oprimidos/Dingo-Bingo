using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    GameObject[] objects;
    public GameObject mainBase;
      public GameObject house;
      public GameObject mine;
      public GameObject barrack;
      public GameObject axeMan;
      public GameObject arrowTower;
    public GameObject pendingObject;
    [SerializeField] private Material[] materials;

    int stoneCost = 60;
    int baseCost = 60;
    int mineCost = 40;
    int houseCost = 80;
    int barrackCost = 120;
    int axeManCost = 160;
    int arrowCost = 200;

    public Button baseButton;
    public Button houseButton;
    public Button mineButton;
    public Button barrackButton;
    public Button axeManButton;
    public Button arrowTowerButton;


    public Button baseButtonB;
    public Button houseButtonB;
    public Button mineButtonB;
    public Button barrackButtonB;
    public Button axeManButtonB;
    public Button arrowTowerButtonB;

    ResourceAmount resourceAmount;//Ana kaynak koda ulaþmak için

    public float rotateAmount = 45f;

    private Vector3 posit;//position

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    public float gridSize;
    bool gridOn = true;

    public bool canPlace = true;
    [SerializeField] private Toggle gridToggle;



    private int baseCount = 0;
    public int barrackCount = 0;
    public int axeManCount = 0;
    public int mineCount;

    //barrack ve axeman binalarý kordinatlarýný
    public Vector3 barrackLocation;
    public Vector3 axeManLocation;
    public void Start()
    {
        resourceAmount = GameObject.Find("ResourceManager").GetComponent<ResourceAmount>();
         objects[0] = mainBase;
         objects[1] = house;
         objects[2] = mine;
         objects[3] = barrack;
         objects[4] = axeMan;
         objects[5] = arrowTower;

        baseButtonB.gameObject.SetActive(false);
        houseButtonB.gameObject.SetActive(false );
        mineButtonB.gameObject.SetActive(false);
        barrackButtonB.gameObject.SetActive(false );
        axeManButtonB.gameObject.SetActive(false );
        arrowTowerButtonB.gameObject.SetActive(false );
    }
    // Update is called once per frame
    void Update()
    {
         BuildingButtonManagement();
        if (pendingObject != null)
        {
           
            if (gridOn)
            {
                pendingObject.transform.position = new Vector3(RoadToNearestGrid(posit.x), RoadToNearestGrid(posit.y), RoadToNearestGrid(posit.z));
            }
            else
            {
                pendingObject.transform.position = posit;
            }


            if (Input.GetMouseButtonDown(0) && canPlace)
            {
                
                PlaceObject();

            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                RotateObject();
            }
            uptadeMaterials();
        }
    }


    public void PlaceObject()
    {
        if (pendingObject != null && canPlace)
        {
            

            // Binaya göre harcanacak taþ miktarý belirleme (maalesef çalýþmýyor)
            if (pendingObject == mainBase)
            {
                stoneCost = baseCost;
            }
            else if (pendingObject == house)
            {
                stoneCost = houseCost;
            }
            else if (pendingObject == mine)
            {
                stoneCost = mineCost;
            }
            else if (pendingObject == barrack)
            {
                stoneCost = barrackCost;
            }
            else if (pendingObject == axeMan)
            {
                stoneCost = axeManCost;
            }
            else if (pendingObject == arrowTower)
            {
                stoneCost = arrowCost;
            }

            // Check if there are enough stones to build
            if (resourceAmount.stoneNum >= stoneCost)
            {
                // Reduce the stone amount
                resourceAmount.stoneNum -= stoneCost;

                // Set the material and reset pendingObject
                pendingObject.GetComponent<MeshRenderer>().material = materials[2];
                pendingObject = null;
            }
            else
            {
                // Handle insufficient resources (optional)
                Debug.Log("Insufficient stones to build!");
            }
        }
    }


    public void BuildingButtonManagement() 
    {
        // base, barrack ve axeman binalarý bir kurulmuþ ise bir daha inþaa edilmesine izin vermemek için binanýn inþa butonunu deactive ediyoruz
        if (baseCount > 0)
        {
            baseButtonB.gameObject.SetActive(true);
            baseButton.gameObject.SetActive(false);
        }
        else
        {
            if (resourceAmount.stoneNum < 60)
            {
                baseButtonB.gameObject.SetActive(true);
                baseButton.gameObject.SetActive(false);
            }
            else
            {
                baseButtonB.gameObject.SetActive(false);
                baseButton.gameObject.SetActive(true);
            }
        }

        if (barrackCount > 0)
        {
            barrackButtonB.gameObject.SetActive(true);
            barrackButton.gameObject.SetActive(false);
        }
        else
        {
            if (resourceAmount.stoneNum < 120)
            {
                barrackButtonB.gameObject.SetActive(true);
                barrackButton.gameObject.SetActive(false);
            }
            else
            {
                barrackButtonB.gameObject.SetActive(false);
                barrackButton.gameObject.SetActive(true);
            }
        }

        if (axeManCount > 0)
        {
            axeManButtonB.gameObject.SetActive(true);
            axeManButton.gameObject.SetActive(false);
        }
        else
        {
            if (resourceAmount.stoneNum < 160)
            {
                axeManButtonB.gameObject.SetActive(true);
                axeManButton.gameObject.SetActive(false);
            }
            else
            {
                axeManButtonB.gameObject.SetActive(false);
                axeManButton.gameObject.SetActive(true);
            }
        }



        //butonlar yeteri kadar melzeme olmayýnca yok olur, yeteri malzeme gelince tekrardan dirilir
        
        if (resourceAmount.stoneNum < 80)
        {
            houseButtonB.gameObject.SetActive(true);
            houseButton.gameObject.SetActive(false);
        }
        else
        {
            houseButtonB.gameObject.SetActive(false);
            houseButton.gameObject.SetActive(true);
        }
        if (resourceAmount.stoneNum < 60)
        {
            mineButtonB.gameObject.SetActive(true);
            mineButton.gameObject.SetActive(false);
        }
        else
        {
            mineButtonB.gameObject.SetActive(false);
            mineButton.gameObject.SetActive(true);
        }


        if (resourceAmount.stoneNum < 200)
        {
            arrowTowerButtonB.gameObject.SetActive(true);
            arrowTowerButton.gameObject.SetActive(false);
        }
        else
        {
            arrowTowerButtonB.gameObject.SetActive(false);
            arrowTowerButton.gameObject.SetActive(true);
        }





    }

    

    public void RotateObject()//binayý rotate etmek için
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            posit = hit.point;
        }
    }

    public void uptadeMaterials()
    {
        if (pendingObject != null)
        {
            if (canPlace)
            {
                pendingObject.GetComponent<MeshRenderer>().material = materials[0];
            }
            else
            {
                pendingObject.GetComponent<MeshRenderer>().material = materials[1];
            }
        }
    }

    public void SelectObject(int index)//seçilen butona göre binanýn inþaa edilmesi
    {if(index == 0)
        {
            pendingObject = Instantiate(mainBase, posit, transform.rotation);
            baseCount++;
        }
       else if (index == 1)
        {
            pendingObject = Instantiate(house, posit, transform.rotation);
            
        }
        else if (index == 2)
        {
            pendingObject = Instantiate(mine, posit, transform.rotation);
            mineCount++;
        }
        else if (index == 3)
        {
            pendingObject = Instantiate(barrack, posit, transform.rotation);
            barrackCount++;
            barrackLocation = posit ; //inþaa edildiði lokasyon
        }
        else if (index == 4)
        {
            pendingObject = Instantiate(axeMan, posit, transform.rotation);
            axeManCount++;
            axeManLocation = posit;  //inþaa edildiði lokasyon
        }
        else if (index == 5)
        {
            pendingObject = Instantiate(arrowTower, posit, transform.rotation);
        }

    }

    public void ToggleGrid()
    {
        if (gridToggle.isOn)
        {
            gridOn = true;
        }
        else { gridOn = false; }

    }

    float RoadToNearestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if (xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }
}