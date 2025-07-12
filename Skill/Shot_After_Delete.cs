using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_After_Delete : MonoBehaviour
{
    public float DeleteDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, DeleteDelay);
    }
}
