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

    public bool Move = true;
    /// <summary>
    /// list of objects that is used to construct the complete object
    /// </summary>
    public List<GameObject> parts;

    public StageData stgdt;
    // Use this for initialization
    void Start () {
        stgdt = FindObjectOfType<DataController>().LoadData();
        //look at parts in the build AND CREATE THEM
        for(int i = 0; i < stgdt.PartNames.Length;i++)
        {
            Debug.Log(stgdt.PartNames[i]);
            GameObject temp = Instantiate(Resources.Load("Prefabs/" + stgdt.PartNames[i], typeof(GameObject))) as GameObject;
            parts.Add(temp);
            temp.transform.parent = transform.parent;
        }
        text = GameObject.FindGameObjectWithTag("TextController").GetComponent<Displaytext>();
        currentStage = 0;
        UpdateStage();
	}
	
    public void NextStage()
    {
        if (Move == true)
        {
            currentStage++;
            Debug.Log("Going to Stage: " + currentStage);
            //Debug.Log("No of stages: " + stgdt.data.Length);
            if (currentStage >= stgdt.data.Length)
            {
                currentStage = stgdt.data.Length - 1;
                return;
            }
            Move = false;
            StartCoroutine(SmoothMove());
            //UpdateStage();
        }
    }

    public void PreviousStage()
    {
        if (Move == true)
        {
            currentStage--;
            Debug.Log("Going to Stage: " + currentStage);
            if (currentStage < 0)
            {
                currentStage = 0;
                return;
            }
            Move = false;
            StartCoroutine(SmoothMove());
            //UpdateStage();
        }
    }

    void UpdateStage()
    {
        //Debug.Log("changing stage");
        for(int i = 0; i < stgdt.data[currentStage].position.Length; i++)
        {
            //Vector3 temp = stgdt.data[currentStage].position[i];

            parts[i].transform.localPosition = stgdt.data[currentStage].position[i];
            parts[i].transform.localRotation = stgdt.data[currentStage].Rotation[i];
            parts[i].GetComponent<MeshRenderer>().enabled = stgdt.data[currentStage].alive[i];
            //Debug.Log(stgdt.data[currentStage].alive[i]);
        }
        
    }

    public void Reset()
    {
        currentStage = 0;
        UpdateStage();
    }

    IEnumerator SmoothMove()
    {
        float elapsedtime = 0;
        float time = 1;
        while (elapsedtime < time)
        {
            if (text != null)
            {
                text.updateText(currentStage);
            }
            for (int i = 0; i < stgdt.data[currentStage].position.Length; i++)
            {
                parts[i].transform.localPosition = Vector3.Lerp(parts[i].transform.localPosition, stgdt.data[currentStage].position[i], (elapsedtime/time));
                parts[i].transform.localRotation = Quaternion.Lerp(parts[i].transform.localRotation, stgdt.data[currentStage].Rotation[i], (elapsedtime/time));
                parts[i].GetComponent<MeshRenderer>().enabled = stgdt.data[currentStage].alive[i];
            }

            elapsedtime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        Move = true;
    }
}
