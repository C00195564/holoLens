using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displaytext : MonoBehaviour {
    
    public Text text;
    public Text stageText;
    int maxStage;
    private void Start()
    {
        
    }

    public void SetMaxStage(int num)
    {
        maxStage = num;
    }

    public void updateText(string word)
    {
        
        text.text = word;
    }

    public void setCurrentStage(int num)
    {
        stageText.text = num + "/" + maxStage;
    }
}
