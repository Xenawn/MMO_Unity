using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestCollision : MonoBehaviour
{
    RaycastHit hit;
   
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition); // Screen
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // Viewport
       

        if (Input.GetMouseButtonDown(0))
        {

           

        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 dir = mousePos - Camera.main.transform.position;
        //    dir = dir.normalized;
        //    RaycastHit hit;
        //    Debug.DrawRay(Camera.main.transform.position, dir*100, Color.red, 1.0f);
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit,100))
        //    {
        //        Debug.Log($"RayCast Camera @{hit.collider.gameObject.name}");
        //    }
        //}
    }
}
