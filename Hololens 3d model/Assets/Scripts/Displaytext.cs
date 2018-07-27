using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displaytext : MonoBehaviour {
    
    public Text text;

    private void Start()
    {
        
    }

    public void updateText(string word)
    {
       
        text.text = word;
    }
}
