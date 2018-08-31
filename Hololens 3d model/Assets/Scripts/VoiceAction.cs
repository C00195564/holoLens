using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;


public class VoiceAction : MonoBehaviour, ISpeechHandler {

    public PartPositionControl controller;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ISpeechHandler.OnSpeechKeywordRecognized(SpeechEventData eventData)
    {

        Debug.Log(eventData.RecognizedText.ToLower());

        switch(eventData.RecognizedText.ToLower())
        {
            case "expand":
                controller.NextStage();
                break;
            case "contract":
                controller.PreviousStage();
                break;
            case "next":
                controller.NextStage();
                break;
            case "previous":
                controller.PreviousStage();
                break;
            case "first":
                controller.FirstStage();
                break;
            case "last":
                controller.LastStage();
                break;
            case "reset":
                controller.reset();
                break;
            case "main menu":
                StartCoroutine("GoToScene", 1);
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
