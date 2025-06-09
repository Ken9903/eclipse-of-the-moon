using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(start());
    }

    IEnumerator start()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("StartScene");
    }

    
}
