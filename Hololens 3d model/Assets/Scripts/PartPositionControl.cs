using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that determines the state of objects from the "parts" list
/// </summary>
public class PartPositionControl : MonoBehaviour {


    /// <summary>
    /// Describes the state of objects from the "parts" list at every stage.
    /// </summary>
    public Displaytext text;
    public int currentStage;
    public int noOfobjects;
    /// <summary>
    /// list of objects that is used to construct the complete object
    /// </summary>
    public List<GameObject> parts;

    public StageData stgdt;
    // Use this for initialization
    void Start () {
        stgdt = FindObjectOfType<DataController>().LoadData();
        text = GameObject.FindGameObjectWithTag("TextController").GetComponent<Displaytext>();
        currentStage = 0;
        UpdateStage();
	}
	
    public void NextStage()
    {
        currentStage++;
        Debug.Log("Going to Stage: " + currentStage);
        Debug.Log("No of stages: " + stgdt.data.Length);
        if (currentStage >= stgdt.data.Length)
        {
            currentStage = stgdt.data.Length - 1;
            return;
        }
        UpdateStage();
    }

    public void PreviousStage()
    {
        currentStage--;
        if (currentStage < 0)
        {
            currentStage = 0;
            return;
        }
        UpdateStage();
    }

    void UpdateStage()
    {
        Debug.Log("changing stage");
        for(int i = 0; i < stgdt.data.Length; i++)
        {
            Vector3 temp = stgdt.data[currentStage].position[i];

            parts[i].transform.position = stgdt.data[currentStage].position[i];
            
            parts[i].transform.rotation = stgdt.data[currentStage].Rotation[i];
            parts[i].GetComponent<MeshRenderer>().enabled = stgdt.data[currentStage].alive[i];
            Debug.Log(stgdt.data[currentStage].alive[i]);
        }
        text.updateText(currentStage);
    }

    public void Reset()
    {
        currentStage = 0;
        UpdateStage();
    }
}
