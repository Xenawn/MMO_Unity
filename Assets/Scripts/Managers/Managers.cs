using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers:MonoBehaviour
{
    static Managers s_instance;
    static Managers Instance { get { Init(); return s_instance; } }// 유일한 매니저를 갖고온다.
    InputManager _input = new InputManager();
    ResourceManager _resouce = new ResourceManager();
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get { return Instance._resouce; } }    
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        _input.OnUpdate();
    }
    static void Init()
    {

        if (s_instance == null)
        {
            
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();
        }
    }
}
