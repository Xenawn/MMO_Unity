using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1.��ġ ����
// 2.���� ����


public class PlayerController : MonoBehaviour
{
    // GameObject (Player)  
    // Transform  // �θ� ���ٽ� transform.gameObject
    // PlayerController

    [SerializeField]
    float _speed = 10.0f;
    Vector3 _destPos;
    float wait_run_ratio = 0;
    PlayerState _state = PlayerState.Idle;
    private void Start()
    {

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }
    void UpdateDie()
    {

    }

    void UpdateMoving()
    {

        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.001f) // float�� ���� ���������� ����
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);
            //if(moveDist>=dir.magnitude) // Mathf.Calmp�� ������� �Ȱ���
            //    moveDist = dir.magnitude;
            transform.position += dir.normalized * moveDist;
            // �̵��ϴ� ���� ���� �츮�� ���� �Ÿ����ٴ� �۾ƾ��Ѵ�.
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
        }

        if (_state == PlayerState.Moving)
        {

            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1.0f, 10.0f * Time.deltaTime);
            //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio", wait_run_ratio);
            anim.Play("WAIT_RUN");
        }
        


    }
    void UpdateIdle()
    {
            wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0.0f, 10.0f * Time.deltaTime);

            Animator anim = GetComponent<Animator>();
            anim.SetFloat("wait_run_ratio", wait_run_ratio);
            anim.Play("WAIT_RUN");
        
    }
    public enum PlayerState
    {
        Die,
        Idle,
        Moving
    }
    void Update()
    {
        // Local => World
        // TransformDirection

        //World => Local
        // InverseTransformDirection


        switch (_state)
        {

            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
        }


    }


    void OnMouseClicked(Define.MouseEvent evt)
    {
        if (_state == PlayerState.Die) return;
        Debug.Log("OnMouseClicked");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
        {
            Debug.Log($"RayCast Camera @ {hit.collider.gameObject.name}");
            Debug.Log($"RayCast Camera @ {hit.collider.gameObject.tag}");
            _destPos = hit.point;
            _state = PlayerState.Moving;

        }
    }
}
