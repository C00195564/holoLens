using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;

public class MenuButtonAction : InteractionReceiver
{

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
    }

    protected override void InputUp(GameObject obj, InputEventData eventData)
    {
    }

    protected override void InputClicked(GameObject obj, InputClickedEventData eventData)
    {
        //Debug.Log(obj.name + " : InputClicked");
        switch (obj.name)
        {
            case "PartBuilderButton":
                Debug.Log("PB PUSH");
                break;
            case "ScannerButton":
                Debug.Log("Scanner push");
                break;
        }
    }
}
