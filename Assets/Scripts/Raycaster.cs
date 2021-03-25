using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public GameObject cylinder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        LayerMask mask = 1 << 6;
        if(Physics.Raycast(ray, out hit,Mathf.Infinity,mask))
        {
            cylinder.transform.position = hit.normal+ hit.point-cylinder.transform.lossyScale/2;
            //cylinder.transform.rotation = Quaternion.LookRotation(hit.point);

            Debug.DrawLine(hit.normal+hit.point, hit.point,Color.red);
            Quaternion rota = Quaternion.FromToRotation(cylinder.transform.up, hit.normal);
            cylinder.transform.rotation = rota * cylinder.transform.rotation;
            //cylinder.transform.rotation = Quaternion.Slerp(cylinder.transform.rotation, slopeRotation * cylinder.transform.rotation, 10 * Time.deltaTime);
        }
    }
}
