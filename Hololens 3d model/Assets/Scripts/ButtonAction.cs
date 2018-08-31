using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;

public class ButtonAction : InteractionReceiver {

    public PartPositionControl controller;
    bool blownUp = false;

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
    }

    protected override void InputUp(GameObject obj, InputEventData eventData)
    {
    }

    protected override void InputClicked(GameObject obj, InputClickedEventData eventData)
    {
        //Debug.Log(obj.name + " : InputClicked");
        switch(obj.name)
        {
            case "ResetButton":
                controller.reset();
                break;
            case "PrevButton":
                controller.PreviousStage();
                break;
            case "NextButton":
                controller.NextStage();
                break;
            case "FirstButton":
                controller.FirstStage();
                break;
            case "LastButton":
                controller.LastStage();
                break;
            case "BlowUpButton":
                if (blownUp == false)
                {
                    controller.NextStage();
                    blownUp = true;
                }
                else
                {
                    controller.PreviousStage();
                    blownUp = false;
                }
                break;
        }
    }
}
