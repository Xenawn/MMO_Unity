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

    public enum PlayerState
    {
        Idle,
        Moving,
        Die
    }
    [SerializeField]
    float _speed = 10.0f;
    Vector3 _destPos;
    PlayerState _state = PlayerState.Idle;
    float wait_run_ratio = 0;
    public Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        //Managers.Input.KeyAction -= OnKeyboard;
        //Managers.Input.KeyAction += OnKeyboard;

        Managers.Resource.Instantiate("UI/UI_Button");
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }
    void UpdateDie()
    {
    }
    void UpdateMoving()
    {

        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.00001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude);

            transform.position = transform.position + dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
            transform.LookAt(_destPos);
        }
        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10 * Time.deltaTime);
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
        anim.Play("WAIT_RUN");
        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
        // 현재 게임 상태에 대한 정보를 넘겨준다.
        //Animator anim = GetComponent<Animator>();
        //anim.SetFloat("speed", _speed);

    }
    void OnRunEvent(string a)
    {
        Debug.Log($"뚜벅 뚜벅{a}");
    }
    void UpdateIdle()
    {

        wait_run_ratio = Mathf.Lerp(wait_run_ratio, 0, 10 * Time.deltaTime);
        anim.SetFloat("wait_run_ratio", wait_run_ratio);
        anim.Play("WAIT_RUN");
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
                break;

        }

    }
    //void OnKeyboard()
    //{
    //    if (Input.GetKey(KeyCode.W))
    //    {
    //        // transform.rotation = Quaternion.LookRotation(Vector3.forward);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.5f);
    //        transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
    //    }
    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        //transform.rotation = Quaternion.LookRotation(Vector3.back);
    //        transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.5f);
    //    }
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.5f);

    //        transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
    //    }
    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.5f);
    //        transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
    //    }
    //    _moveToDest = false;
    //}

    void OnMouseClicked(Define.MouseEvent evt)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);
        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Wall")))
        {
            _destPos = hit.point;
            _state = PlayerState.Moving;
            //Debug.Log($"RayCast Camera @{hit.collider.gameObject.name}");
        } 
        Debug.Log("OnMouseClicked");
    }
}
