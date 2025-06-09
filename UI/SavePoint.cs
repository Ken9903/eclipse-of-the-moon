using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public string sceneName;
    public int initpos;

    public GameObject saveUi;
    public GameObject localUi;
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Body")
        {
            localUi = Instantiate(saveUi, this.transform);
            localUi.GetComponentInChildren<SaveYesUi>().init(sceneName, initpos);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Body")
        {
            Destroy(localUi);
        }
    }

}
