using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CamerMode _mode = Define.CamerMode.QuaterView;
    [SerializeField]
    Vector3 _delta;
    [SerializeField]
    GameObject _player;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (Define.CamerMode.QuaterView == _mode)
        {
            transform.position = _player.transform.position + _delta;
            transform.LookAt(_player.transform);
        }
    }

    public void SetQuaterView(Vector3 delta)
    {
        _mode = Define.CamerMode.QuaterView;
        delta = delta;
    }
}
