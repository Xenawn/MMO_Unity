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
        GetText((int)Texts.ScoreText).text = "Bind Text";

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        UI_EventHandler evt = go.GetComponent<UI_EventHandler>();
        evt.OnDragHandler +=((PointerEventData data)=>{ evt.transform.position = data.position; });
    }

    public void OnButtonCLicked()
    {
        score++;
      
        _text.text = $"Á¡¼ø: {score}Á¡";
    }
}
