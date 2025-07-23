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


    private void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;
        Managers.Input.KeyAction += OnKeyboard;
    }
 
    void Update()
    {
       // Local => World
       // TransformDirection

        //World => Local
        // InverseTransformDirection
        
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
    }
}
