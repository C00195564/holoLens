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
            case "PrevButton":
                controller.PreviousStage();
                break;
            case "NextButton":
               
                controller.NextStage();
                break;
            case "FirstButton":
                break;
            case "LastButton":
                break;
            case "BlowUpButton":
                if (!blownUp)
                {
                    if (controller.NextStage())
                    {
                        blownUp = true;
                        Debug.Log("blow up");
                    }
                }
                else
                {
                    if (controller.PreviousStage())
                    {
                        blownUp = false;
                        Debug.Log("shrink back");
                    }
                }

                break;
        }
    }
}
