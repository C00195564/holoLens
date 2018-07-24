using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;
using UnityEngine.SceneManagement;

public class PartSelectButtonAction : InteractionReceiver
{
    StringHolder holder;
    private void Start()
    {
        holder = FindObjectOfType<StringHolder>();
    }
    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
    }

    protected override void InputUp(GameObject obj, InputEventData eventData)
    {
    }

    protected override void InputClicked(GameObject obj, InputClickedEventData eventData)
    {
        //Debug.Log(obj.name + " : InputClicked");
        holder.filepath = obj.name;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SpacialMapping"));
    }
}
