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
        // Debug.Log(Input.mousePosition); // 마우스 좌표 = Screen 픽셀

        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition )); // 픽셀을 비율화
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            

            Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red, 1.0f);
            RaycastHit hit;
            LayerMask m1 = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall"); // 비트 플래그 대신
            int mask = (1 << 8)|(1<<9);
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"RayCast Camera @ {hit.collider.gameObject.name}");
                Debug.Log($"RayCast Camera @ {hit.collider.gameObject.tag}");
            }
        }

        /*if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition ); // 아래 3줄을 이 한줄로 끝
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
