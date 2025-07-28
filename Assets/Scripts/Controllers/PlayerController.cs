using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1.위치 벡터
// 2.방향 벡터


public class PlayerController : MonoBehaviour
{
    // GameObject (Player)  
        // Transform  // 부모 접근시 transform.gameObject
        // PlayerController

    [SerializeField]
    float _speed = 10.0f;
    bool _moveToDset = false;
    Vector3 _destPos;

    private void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }
 
    void Update()
    {
        // Local => World
        // TransformDirection

        //World => Local
        // InverseTransformDirection

        if (_moveToDset)
        {
            Vector3 dir = _destPos-transform.position;
            if (dir.magnitude < 0.0001f) // float을 빼면 오차범위가 있음
            {
                _moveToDset = false;
            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
                //if(moveDist>=dir.magnitude) // Mathf.Calmp랑 사용방법이 똑같음
                //    moveDist = dir.magnitude;
                transform.position += dir.normalized * moveDist;
                // 이동하는 값이 현재 우리가 남은 거리보다는 작아야한다.
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir),10*Time.deltaTime);
            }          
            
        }
    }

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
           // transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.5f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.5f);

             transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.5f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        }
        _moveToDset = false;
    }
    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.Click)
            return;
        Debug.Log("OnMouseClicked");
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            Debug.Log($"RayCast Camera @ {hit.collider.gameObject.name}");
            Debug.Log($"RayCast Camera @ {hit.collider.gameObject.tag}");
            _destPos = hit.point;
            _moveToDset = true;
        
        }
    }
}
