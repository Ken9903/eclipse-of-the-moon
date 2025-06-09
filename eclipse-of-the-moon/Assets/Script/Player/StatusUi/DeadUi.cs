using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class DeadUi : MonoBehaviour
{
    DataController controller;
    bool isclicked = false;
    // Start is called before the first frame update

  IEnumerator waitTeleport()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(controller.gameData.sceneName);
        Player_Status player_Status = GameObject.Find("Player").GetComponent<Player_Status>();
        player_Status.isdead = false;
        player_Status.set_hp_init();

        Canvas.ForceUpdateCanvases();
        Destroy(gameObject);

    }
   

  

    public void OnClick()
    {
        if(isclicked == false)
        {
            isclicked = true;
           
            controller = GameObject.Find("DataController").GetComponent<DataController>();
            controller.LoadGameData();

            TeleportationProvider teleportationProvider = GameObject.Find("XR Rig").GetComponent<TeleportationProvider>();
            teleportationProvider.enabled = true;

            StartCoroutine(waitTeleport());
        }
      
    }

}
