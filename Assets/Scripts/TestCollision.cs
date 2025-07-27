using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // ������ rigdbody (IsKinematic off)
    // ������ collider (IsTrigger: off)
    // ������� collider (IsKinematic: off)

    // Trigger;
    // 1) �Ѵ� collider�־����
    // 2) �� �ߤ� ������ IsTrigger ON
    // 3) �� �� �ϳ��� Rigdbody
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
