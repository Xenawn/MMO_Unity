using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
   
    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        PointText,
        ScoreText
    }
    
    enum GameObjects
    {
        TestObject
    }
    enum Images
    {
        ItemIcon,
    }
    
    [SerializeField]
    Text _text;
    int score = 0;


    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
     

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnButtonClicked);
        GameObject go = GetImage((int)Images.ItemIcon).gameObject;

        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);
        //UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        //evt.OnDragHandler +=((PointerEventData data)=>{ evt.transform.position = data.position; });
    }

    public void OnButtonClicked(PointerEventData data)
    {
        score++;

        GetText((int)Texts.ScoreText).text = $"Á¡¼ö: {score}";
    }
}
