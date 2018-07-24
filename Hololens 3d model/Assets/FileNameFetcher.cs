using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileNameFetcher : MonoBehaviour {

    public List<string> filenames;
    // Use this for initialization
    void Start()
    {
        DirectoryInfo directorypath = new DirectoryInfo(Application.streamingAssetsPath + "/guides/");
        FileInfo[] info = directorypath.GetFiles();

        foreach (FileInfo file in info)
        {
            if (file.Extension == ".json")
            {
                Debug.Log(file.FullName);
                filenames.Add(file.FullName);
            }
        }
    }
    
}
