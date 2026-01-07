using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;

        List<GameObject> list = new List<GameObject>();
        for(int i=0; i<5; i ++)
        {
            list.Add(Managers.Resource.Instantiate("UnityChan"));

        }

        foreach(GameObject obj in list)
        {
            Managers.Resource.Destory(obj);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Managers.Scene.LoadScene(Define.Scene.Game);
        } 
    }

    public override void Clear()
    {
        Debug.Log("LoginScene Clear");
    }
}
