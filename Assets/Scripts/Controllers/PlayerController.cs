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
    PlayerState _state = PlayerState.Idle;
    [SerializeField]
    float _speed = 10.0f;
    Vector3 _destPos;

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

     
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;

        UI_Button ui = Managers.UI.ShowPopupUI<UI_Button>();
        Managers.UI.ClosePopupUI(ui); 
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

        //wait_run_ratio = Mathf.Lerp(wait_run_ratio, 1, 10.0f * Time.deltaTime);
        // 현재 게임 상태에 대한 정보를 넘겨준다.
        //Animator anim = GetComponent<Animator>();
        //anim.SetFloat("speed", _speed);
        anim.SetFloat("speed", _speed);
    }

    void UpdateIdle()
    {

        anim.SetFloat("speed", 0);
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
