using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{

    Camera myCam;

    //graphical
    [SerializeField]
    RectTransform boxVisual;

    //logical
    Rect selectionBox;

    Vector2 startPosition;
    Vector2 endPosition;
    void Start()
    {
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();// bunun sayesinde yeþil karenin oyun baþlangýcýnda görünmesini engelliyoruz

    }

    // Update is called once per frame
    void Update()
    {
        // týkladýðýmýzda
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }
        // when dragging
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        // týklamayý býraktýðýmýzda
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }


    }

    void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x- boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;

    }

    void DrawSelection()
    {
        // do x calculation
        if (Input.mousePosition.x < startPosition.x)
        {
            //dragging left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            //draging right
            selectionBox.xMin = startPosition.x; 
            selectionBox.xMax = Input.mousePosition.x;
        }

        //do y calculation
        if (Input.mousePosition.y < startPosition.y)
        {
            //dragging down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;

        }
        else
        {
            //draging up
            selectionBox.yMin = startPosition.y; 
            selectionBox.yMax = Input.mousePosition.y;
        }

    }

    void SelectUnits()
    {
        // tüm unitler için loop yapma
        foreach(var unit in UnitSelections.Instance.unitList)
        {
            // if unit is within the bounds of tselection rect
            if (selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)))
            {
                // if any unit is within the selecton add them to selection
                UnitSelections.Instance.DragSelect(unit);
            }
        }
    }
}
