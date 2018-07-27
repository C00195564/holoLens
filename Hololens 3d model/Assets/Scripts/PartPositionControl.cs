﻿using System.Collections;
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

    StageData stgdt;

    void Start()
    {
        stgdt = FindObjectOfType<DataController>().dat;
        if(stgdt == null)
        {
            Debug.LogError("Data not loaded");
        }
        //look at parts in the build AND CREATE THEM
        for (int i = 0; i < stgdt.PartNames.Length; i++)
        {
            Debug.Log(stgdt.PartNames[i]);
            GameObject temp = Instantiate(Resources.Load("Prefabs/" + stgdt.PartNames[i], typeof(GameObject))) as GameObject;
            temp.transform.parent = this.transform;
            
            parts.Add(temp);
            
        }
        currentStage = 0;
        UpdateStage();
    }

    public bool NextStage()
    {
        if (Move == true)
        {
            currentStage++;
            if (currentStage > stgdt.data.Length - 1)
            {
                currentStage = stgdt.data.Length - 1;
                return false;
            }
            Debug.Log("Going to Stage: " + currentStage);
            Move = false;
            StartCoroutine(SmoothMove());
            //UpdateStage();
            return true;
        }
        return false;
    }

    public bool PreviousStage()
    {
        if (Move == true)
        {
          
            currentStage--;
            
            if (currentStage < 0)
            {
                currentStage = 0;
                return false;
            }
            Debug.Log("Going to Stage: " + currentStage);
            Move = false;
            StartCoroutine(SmoothMove());
            //UpdateStage();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Changes the position of the objects displayed to match the current stage
    /// </summary>
    void UpdateStage()
    {
        //Debug.Log("changing stage");
        if (text != null)
        {
            text.updateText(stgdt.data[currentStage].text);
        }
        for (int i = 0; i < stgdt.data[currentStage].position.Length; i++)
        {
            //Vector3 temp = stgdt.data[currentStage].position[i];

            parts[i].transform.localPosition = stgdt.data[currentStage].position[i];
            parts[i].transform.localRotation = stgdt.data[currentStage].Rotation[i];
            parts[i].GetComponent<MeshRenderer>().enabled = stgdt.data[currentStage].alive[i];
            //Debug.Log(stgdt.data[currentStage].alive[i]);
        }
        
    }

    /// <summary>
    /// Sets the stage back to the start
    /// </summary>
    public void Reset()
    {
        currentStage = 0;
        UpdateStage();
    }

    /// <summary>
    /// coroutine for the smooth movement of objects from one stage to the next
    /// </summary>
    /// <returns></returns>
    IEnumerator SmoothMove()
    {
        float elapsedtime = 0;
        float time = 1;
        while (elapsedtime < time)
        {
            
            if (text != null)
            {
                text.updateText(stgdt.data[currentStage].text);
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
