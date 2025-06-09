using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class HP_Ui_trans : MonoBehaviour
{
    private Material material;

    Color full_color = new Color(0/255f, 60/255f, 200/255f);

    public Volume volume;

    Vignette vignette;

    Color DamageColor = new Color(60, 0, 0);
    Color NotDamageColor = new Color(0, 0, 0);

    IEnumerator DamageEffect(string type)
    {
        if(type =="direct")
        {
            if (volume.profile.TryGet<Vignette>(out vignette))
            {
                yield return new WaitForSeconds(0.5f);

                vignette.active = true;
                vignette.intensity.value = 0.1f;
                vignette.color.Override(DamageColor);

                yield return new WaitForSeconds(0.6f);

                while (vignette.intensity.value <= 0)
                {
                    vignette.intensity.value -= 0.001f;
                    yield return new WaitForSeconds(0.1f);
                }
                vignette.color.Override(NotDamageColor);

            }
        }
        else
        {
            if (volume.profile.TryGet<Vignette>(out vignette))
            { 
                vignette.active = true;
                vignette.intensity.value = 0.1f;
                vignette.color.Override(DamageColor);

                yield return new WaitForSeconds(0.6f);

                while (vignette.intensity.value <= 0)
                {
                    vignette.intensity.value -= 0.001f;
                    yield return new WaitForSeconds(0.1f);
                }
                vignette.color.Override(NotDamageColor);

            }
        }
       
    }
    private void Start()
    {
        material = GetComponent<MeshRenderer>().material;

        material.SetColor("_Emission", full_color);
        volume = GameObject.Find("Global Volume").GetComponent<Volume>();


    }

    public void trans_Hp_Ui(int player_Max_Hp, int player_Hp, string type)
    {
        StartCoroutine(DamageEffect(type));

        double hp_ratio_ui_setblue = (double)player_Hp / (double)player_Max_Hp * 200;
        Color color = new Color(0 / 255f, 60 / 255f, (float)hp_ratio_ui_setblue / 255f);

        material.SetColor("_Emission", color);

    }

    public void trans_Hp_Ui_only(int player_Max_Hp, int player_Hp)
    {
        double hp_ratio_ui_setblue = (double)player_Hp / (double)player_Max_Hp * 200;
        Color color = new Color(0 / 255f, 60 / 255f, (float)hp_ratio_ui_setblue / 255f);

        material.SetColor("_Emission", color);
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        volume = GameObject.Find("Global Volume").GetComponent<Volume>(); 
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
