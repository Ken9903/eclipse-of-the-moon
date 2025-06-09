using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using PixelCrushers.DialogueSystem;

public class PlayerDead : MonoBehaviour
{
    public Volume volume;
    ColorAdjustments colorAdjustments;

    SkillManager skillManager;

    public Transform uiTrans;
    public GameObject DeadUi;
    // Start is called before the first frame update
   
    public void die()
    {
        volume = GameObject.Find("Global Volume").GetComponent<Volume>();

        if (volume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            colorAdjustments.active = true;
            colorAdjustments.colorFilter.Override(Color.grey);
        }
        TeleportationProvider teleportationProvider = GameObject.Find("XR Rig").GetComponent<TeleportationProvider>();
        teleportationProvider.enabled = false;

        Player_Status status = GameObject.Find("Player").GetComponent<Player_Status>();
        status.attackPoint = 0;

        DialogueManager.StopConversation();

        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        skillManager.currentMagic.Clear();
        //skillManager.DestroySkillUi();

        Instantiate(DeadUi, uiTrans);
    }

    



  

   
    
}
