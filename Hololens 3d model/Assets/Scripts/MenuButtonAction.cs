using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;
using UnityEngine.SceneManagement;

public class MenuButtonAction : InteractionReceiver
{
    private void Start()
    {
        Debug.Log("Button reciever ready");
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
        switch (obj.name)
        {
           
            case "PartBuilderButton":
                Debug.Log("PB PUSH");
                StartCoroutine("GoToScene", 2);
                break;
            case "ScannerButton":
                Debug.Log("Scanner push");
                StartCoroutine("GoToScene", 4);
                break;
            default:
                Debug.Log(obj.name);
                break;
        }
    }

    IEnumerator GoToScene(int loadindex)
    {
        int unload = SceneManager.GetActiveScene().buildIndex;
        var loading = SceneManager.LoadSceneAsync(loadindex);
        yield return loading;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(loadindex));
        SceneManager.UnloadSceneAsync(unload);
    }
}
