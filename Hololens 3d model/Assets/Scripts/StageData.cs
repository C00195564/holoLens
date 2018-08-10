using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stage 
{
    
    public Vector3[] position;
    public Vector3[] Rotation;
    public bool[] alive;
    public string text;
}

[System.Serializable]
public class StageData
{
    public string foldername;
    public string[] PartNames;
    public Vector3 Scale;
    public Stage[] data;
}
