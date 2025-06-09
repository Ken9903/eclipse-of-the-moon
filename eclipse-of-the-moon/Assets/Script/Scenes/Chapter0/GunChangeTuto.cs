using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunChangeTuto : MonoBehaviour
{
    public GameObject tutoGun;

    // Start is called before the first frame update
    void Start()
    {
        Catch_Gun catch_Gun = GameObject.Find("Bag").GetComponent<Catch_Gun>();

        catch_Gun.gun = tutoGun;

        MagicPrepare magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();
        magicPrepare.use = true;

        if(GameObject.Find("BasicShot(Clone)") != null)
        {
            Destroy(GameObject.Find("BasicShot(Clone)"));
        }
    }

}
