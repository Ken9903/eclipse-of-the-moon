using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeEffect : MonoBehaviour
{
    public Volume volume;

    Vignette vignette;
    DepthOfField depthOfField;

    IEnumerator BlinkEffect_forWakeUp()
    {
        
        if (volume.profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.active = true;
            depthOfField.focusDistance.value = 0.5f;
        }
        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            vignette.intensity.value = 1;  // �� ���� ����
            yield return new WaitForSeconds(1);
        }
        if (volume.profile.TryGet<Vignette>(out vignette))
        {
            if (volume.profile.TryGet<DepthOfField>(out depthOfField))
            {
                while (vignette.intensity.value > 0.4f)
                {
                    vignette.intensity.value -= 0.005f;
                    depthOfField.focusDistance.value += 0.005f;
                    yield return new WaitForSeconds(0.005f);
                }

                while (vignette.intensity.value < 1)
                {
                    vignette.intensity.value += 0.005f;
                    depthOfField.focusDistance.value -= 0.005f;
                    yield return new WaitForSeconds(0.005f);
                }
                yield return new WaitForSeconds(1);
                while (vignette.intensity.value > 0f)
                {
                    if (volume.profile.TryGet<DepthOfField>(out depthOfField))
                    {

                        depthOfField.focusDistance.value += 0.01f;

                        vignette.intensity.value -= 0.01f;
                        yield return new WaitForSeconds(0.01f);


                    }
                    if (volume.profile.TryGet<DepthOfField>(out depthOfField))
                    {
                        depthOfField.active = false;
                    }
                }
            }
        }
     
    }

    IEnumerator BlinkEffect_forWakeDown()
    {
        if (volume.profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.focusDistance.value = 5;
            depthOfField.active = true;
            if (volume.profile.TryGet<Vignette>(out vignette))
            {
                vignette.intensity.value = 0;  // �� �߰� ����
                while (vignette.intensity.value < 1)
                {
                    vignette.intensity.value += 0.01f;
                    depthOfField.focusDistance.value -= 0.05f;
                    yield return new WaitForSeconds(0.01f);
                }
                yield return new WaitForSeconds(1);

                while (vignette.intensity.value > 0.4f)
                {
                    vignette.intensity.value -= 0.01f;
                    depthOfField.focusDistance.value += 0.05f;
                    yield return new WaitForSeconds(0.01f);
                }

                while (vignette.intensity.value < 1)
                {
                    vignette.intensity.value += 0.01f;
                    depthOfField.focusDistance.value -= 0.05f;
                    yield return new WaitForSeconds(0.01f);
                }

            }
        }
    }

    IEnumerator SceneCloserDepthOfField() //���� �帴������
    {
        if (volume.profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.focusDistance.value = 5;
            depthOfField.active = true;

            while(depthOfField.focusDistance.value > 0.2) //������� �ִ�ġ.
            {
                depthOfField.focusDistance.value -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
    IEnumerator SceneOpenerDepthOfField() //���� �Ƿ�������
    {
        if (volume.profile.TryGet<DepthOfField>(out depthOfField))
        {
            depthOfField.focusDistance.value = 0.2f;
            depthOfField.active = true;

            while (depthOfField.focusDistance.value < 5) 
            {
                depthOfField.focusDistance.value += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
            depthOfField.active = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //StopCoroutine(BlinkEffect_forWakeDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playWakeUp()
    {
        StartCoroutine(BlinkEffect_forWakeUp());
    }
    public void playWakeDown()
    {
        StartCoroutine(BlinkEffect_forWakeDown());
    }
    public void blurEye()
    {
        StartCoroutine(SceneCloserDepthOfField()); 
    }
    public void notblurEye()
    {
        StopCoroutine(SceneOpenerDepthOfField());
    }
}
