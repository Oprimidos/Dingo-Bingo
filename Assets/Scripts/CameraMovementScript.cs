using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraMovementScript : MonoBehaviour
{
    public Transform cameraTransform;
    float movementSpeed = 0.8f;
    float normalSpeed = 0.8f;
    float fastSpeed = 1.4f;
    float movemenTime = 100f;
    float rotationSpeed = 0.6f;

    Vector3 zoomAmount = new Vector3(0,0.5f,0.5f);

    Vector3 newPosition;
    Quaternion newRotation;
    Vector3 newZoom;

    Vector3 rotateStartPosition;
    Vector3 rotateCurrentPosition;

    PhotonView view;
    void Start()
    {
      newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
            HandleMouseInput();
            HandleMovementInput();
       

    }

    void HandleMouseInput()
    {
        
            if (Input.mouseScrollDelta.y != 0)
            {
                newZoom += Input.mouseScrollDelta.y * zoomAmount;
            }

            //fare ile rotate yapma
            if (Input.GetMouseButtonDown(2))
            {
                rotateStartPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(2))
            {
                rotateCurrentPosition = Input.mousePosition;

                Vector3 difference = rotateStartPosition - rotateCurrentPosition;

                rotateStartPosition = rotateCurrentPosition;

                newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5));
            }
        // fare ile zoom yapma
        
    }
    void HandleMovementInput()
    {
        //shift ile hýzlandýrma
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }

        //normal movement asdw ile
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPosition += (transform.right * -movementSpeed);
        }


        // q ve e ile rotation yapma
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationSpeed);
        }


        //r ve t ile zoom in zoom out yapma
        if (Input.GetKey(KeyCode.R))
        {
            newZoom += zoomAmount;

        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomAmount;
        }


        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime*movemenTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime*movemenTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom,  Time.deltaTime*movemenTime);
    }
}
