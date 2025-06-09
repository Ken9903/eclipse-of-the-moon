using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Change_Main : MonoBehaviour
{
    public GameObject gunMain;

    // Start is called before the first frame update
    void Start()
    {
        Catch_Gun catch_Gun = GameObject.Find("Bag").GetComponent<Catch_Gun>();
        catch_Gun.gun = gunMain;

        MagicPrepare magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();
        magicPrepare.use = false;


        if(GameObject.Find("TriggerPoint") != null)
        {
            Destroy(GameObject.Find("TriggerPoint"));
            Destroy(GameObject.Find("Rifle_for_tuto(Clone)"));

            catch_Gun.isequiped = false;

        }
    }
}
