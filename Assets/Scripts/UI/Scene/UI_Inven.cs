using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }

    string _name; 
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));

        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
        {
            Managers.Resource.Destory(child.gameObject);
        }

        for(int i=0; i<8; i++)
        {
            GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Inven_Item");
            item.transform.SetParent(gridPanel.transform);

            UI_Inven_Item inven_Item= Util.GetOrAddComponent<UI_Inven_Item>(item);
            inven_Item.SetInfo($"집행검{i}번");

        }

    }

  
}
