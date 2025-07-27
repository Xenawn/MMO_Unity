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
        // Debug.Log(Input.mousePosition); // ���콺 ��ǥ = Screen �ȼ�

        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition )); // �ȼ��� ����ȭ
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            

            Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red, 1.0f);
            RaycastHit hit;
            LayerMask m1 = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"); // ��Ʈ �÷��� ���
            int mask = (1 << 8)|(1<<9);
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"RayCast Camera @ {hit.collider.gameObject.name}");
                Debug.Log($"RayCast Camera @ {hit.collider.gameObject.tag}");
            }
        }

        /*if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition ); // �Ʒ� 3���� �� ���ٷ� ��
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            //Vector3 dir = mousePos - Camera.main.transform.position;
            //dir = dir.normalized;

            RaycastHit hit;

            Debug.DrawRay(Camera.main.transform.position, dir, Color.red, 1.0f);
            if (Physics.Raycast(Camera.main.transform.position, dir, out hit))
            {
                Debug.Log($"RayCast Camera @ {hit.collider.gameObject.name}");
            }
        }
       */
    }
}
