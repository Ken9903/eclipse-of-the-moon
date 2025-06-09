using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindCamera : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }
    void OnEnable()
    {       
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
