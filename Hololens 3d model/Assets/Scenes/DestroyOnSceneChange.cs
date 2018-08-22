using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Destroy the attached game object when scene changes to zero scene
/// </summary>
public class DestroyOnSceneChange : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        SceneManager.sceneLoaded += OnLevelFinishLoading;
	}

    void OnLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishLoading;
    }
}
