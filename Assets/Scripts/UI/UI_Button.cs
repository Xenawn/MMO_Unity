using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
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
    
    [SerializeField]
    Text _text;
    int score = 0;


    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));

        GetText((int)Texts.ScoreText).text = "Bind Text";
    }

    public void OnButtonCLicked()
    {
        score++;
      
        _text.text = $"Á¡¼ø: {score}Á¡";
    }
}
