using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUp : MonoBehaviour
{
    public GameObject CylindersLight;
    private Vector3 CameraViewPoint;
    private float startMouseX;
    //private float startMouseY;

    void Start()
    {
        GameObject floorBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floorBox.transform.localScale = new Vector3(10, 1, 10);
        floorBox.transform.position = Vector3.zero;
        floorBox.name = "FloorBox";
        GameObject backBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        backBox.transform.localScale = new Vector3(10, 10, 1);
        backBox.transform.position = new Vector3(0, 5, 5);
        backBox.name = "BackBox";
        GameObject leftBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftBox.transform.localScale = new Vector3(1, 10, 10);
        leftBox.transform.position = new Vector3(-5, 5, 0);
        leftBox.name = "LeftBox";
        GameObject rightBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightBox.transform.localScale = new Vector3(1, 10, 10);
        rightBox.transform.position = new Vector3(5, 5, 0);
        rightBox.name = "RightBox";
        GameObject topBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        topBox.transform.localScale = new Vector3(10, 1, 10);
        topBox.transform.position = new Vector3(0, 10, 0);
        topBox.name = "TopBox";
        
        floorBox.layer= backBox.layer= leftBox.layer= rightBox.layer= topBox.layer= LayerMask.NameToLayer( "Walls");
        CameraViewPoint = new Vector3(0, 5, 0);
        Camera.main.transform.position = new Vector3(0, 5, -15);
        Camera.main.transform.LookAt(CameraViewPoint);
        Raycaster raycaster = GetComponent<Raycaster>();
        raycaster.cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        raycaster.cylinder.transform.localScale = new Vector3(1, 1, 1);
        raycaster.cylinder.name = "Cylinder";
        CylindersLight.transform.SetParent(raycaster.cylinder.transform);

    }

    // Update is called once per frame
    void Update()
    {
        float f = Input.mouseScrollDelta.y;
        if(f!=0)
        {
            Camera.main.transform.position += Camera.main.transform.forward * f;
        }
        if(Input.GetMouseButtonDown(1))
        {
            startMouseX = Input.mousePosition.x;
            //startMouseY = Input.mousePosition.y;

        }
        if(Input.GetMouseButton(1))
        {
            float rotateAngleX = startMouseX - Input.mousePosition.x;
            //float rotateAngleY = startMouseX - Input.mousePosition.x;
            Camera.main.transform.RotateAround(CameraViewPoint, Vector3.up, rotateAngleX / 100);
            //Camera.main.transform.RotateAround(CameraViewPoint, Vector3.right, rotateAngleY / 100);
        }
        
    }
}
