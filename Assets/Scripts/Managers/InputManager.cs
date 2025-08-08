using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager
{
    public Action KeyAction = null; // µ®∏Æ∞‘¿Ã∆Æ
    public Action<Define.MouseEvent> MouseAction = null;

    bool _perssed = false;
    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (Input.anyKey && KeyAction != null) KeyAction.Invoke();

        if (MouseAction != null)
        {
            if (Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _perssed = true;
            }
            else
            {
                if (_perssed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _perssed = false;

            }
        }
    }
}
