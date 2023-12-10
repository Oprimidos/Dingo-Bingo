using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject pendingObject;

    public float rotateAmount = 45f;

    private Vector3 posit;//position

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    public float gridSize;
    bool gridOn = true;
    [SerializeField] private Toggle gridToggle;

    // Update is called once per frame
    void Update()
    {
        if(pendingObject != null)
        {
            if (gridOn)
            {
                pendingObject.transform.position = new Vector3(RoadToNearestGrid(posit.x), RoadToNearestGrid(posit.y), RoadToNearestGrid(posit.z));
            }
            else
            { 
                pendingObject.transform.position = posit;
            }

           
            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                RotateObject();
            }
        }
    }

    public void PlaceObject() // ayrý bir method oluþturmamýn sebebi daha sonradan bunu belli bir kaynak ile inþaa edebilme þartý koyacaðým o yüzden
    {
        pendingObject = null;
    }

    public void RotateObject()//binayý rotate etmek için
    {
        pendingObject.transform.Rotate(Vector3.up, rotateAmount);
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            posit = hit.point;
        }
    }

    public void SelectObject(int index)
    {
        pendingObject = Instantiate(objects[index],posit,transform.rotation);
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
