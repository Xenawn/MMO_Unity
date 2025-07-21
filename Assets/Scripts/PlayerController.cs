using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1.위치 벡터
// 2.방향 벡터
struct MyVector
{
    public float x;
    public float y;
    public float z;
   
    public float manitude { get { return Mathf.Sqrt(x*x+y*y+z*z); } }
    public MyVector normalized { get { return new MyVector(x / manitude, y/manitude, z/manitude); } }   
    public MyVector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static MyVector operator *(MyVector a, float d)
    {
        return new MyVector(a.x *d, a.y *d, a.z *d);
    }

}
public class PlayerController : MonoBehaviour
{
    // GameObject (Player)  
        // Transform  // 부모 접근시 transform.gameObject
        // PlayerController

    [SerializeField]
    float _speed = 10.0f;


    private void Start()
    {
        MyVector to = new MyVector(10, 0, 0);
        MyVector from = new MyVector(5, 0, 0);
        MyVector dir = to - from;
        dir = dir.normalized;

        MyVector newPos = from + dir * _speed;
        // 방향 벡터
            // 1. 거리(크기) 5 normalized
            // 2. 실제 방향 ->
    }
    void Update()
    {
       // Local => World
       // TransformDirection

        //World => Local
        // InverseTransformDirection
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);
        }
    }
}
