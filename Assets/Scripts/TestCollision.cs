using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 나한테 rigdbody (IsKinematic off)
    // 나한테 collider (IsTrigger: off)
    // 상대한테 collider (IsKinematic: off)

    // Trigger;
    // 1) 둘다 collider있어야함
    // 2) 둘 중ㅎ ㅏ나는 IsTrigger ON
    // 3) 둘 중 하나는 Rigdbody
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision{collision.gameObject.name}");

    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log($"Trigger{other.gameObject.name}");
        
    }

    private void Update()
    {
        // Local <=> World<=> Viewport <=> Screen
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position+Vector3.up, look*10, Color.red);
       
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
        foreach(RaycastHit hit in hits)
        {
            Debug.Log($"Raycast {hit.collider.gameObject.name}");
        }
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position+Vector3.up,look,out hit, 10))
        //{
        //    Debug.Log($"RayCast{hit.collider.gameObject.name}");
        //}
    }
}
