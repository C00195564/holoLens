using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;

public class ButtonActionBU : InteractionReceiver {

    public PartPositionControl controller;

    void Start()
    {
        
    }

    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
       // Debug.Log(obj.name + " : InputDown");
       // txt.text = obj.name + " : InputDown";
    }

    protected override void InputUp(GameObject obj, InputEventData eventData)
    {
        //Debug.Log(obj.name + " : InputUp");
       // txt.text = obj.name + " : InputUp";
    }

    protected override void InputClicked(GameObject obj, InputClickedEventData eventData)
    {
        Debug.Log(obj.name + " : InputClicked");
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
        }
    }
}
