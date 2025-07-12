using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TestScriptableObject")]

public class Scenario_Excute : ScriptableObject
{
    public VolumeEffect volumeEffect;
 

    public void WakeUp()
    {
        volumeEffect = GameObject.Find("ScenarioSupporter").GetComponent<VolumeEffect>();
        volumeEffect.playWakeUp();
    }
    public void WakeDown()
    {
        volumeEffect = GameObject.Find("ScenarioSupporter").GetComponent<VolumeEffect>();
        volumeEffect.playWakeDown();
    }
    public void Particle()
    {
        PlayParticle particleSys = GameObject.Find("ScenarioSupporter").GetComponent<PlayParticle>();
        particleSys.playParticle();
    }

    public void testWavePlay()
    {
        Wave_Test wave_Test = GameObject.Find("ScenarioSupporter").GetComponent<Wave_Test>();
        wave_Test.PlayWaveTest();
    }
    public void blurEyePlay()
    {
        volumeEffect = GameObject.Find("ScenarioSupporter").GetComponent<VolumeEffect>();
        volumeEffect.blurEye();
    }
}
