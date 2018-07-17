using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {
    /// <summary>
    /// hardcoding what file to load is not acceptable
    /// figure out a way to load
    /// </summary>
    public string DataFileName;

    public StageData dat;
    private void Start()
    {
        DontDestroyOnLoad(this);
        LoadData();
    }

    public StageData LoadData()
    {
        string filepath = Path.Combine(Application.streamingAssetsPath, DataFileName);

        if(File.Exists(filepath))
        {
            string jsonData = File.ReadAllText(filepath);
            StageData loadedData = JsonUtility.FromJson<StageData>(jsonData);
            return loadedData;
        }
        Debug.LogError("Error: Data File not found");
        return null;
    }
}
