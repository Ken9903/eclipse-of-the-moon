using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillConditionCheck : MonoBehaviour
{
    public SkillManager skillManager;

    public int debugMagic1Condition = 0;
    public int debugMagic2Condition = 0;
    public int debugMagic3Condition = 0;
    public int debugMagic4Condition = 0;
    public int debugMagic5Condition = 0;
    public int debugMagic6Condition = 0;

    void Start()
    {
        StartCoroutine("DebugMagic1");
        StartCoroutine("DebugMagic2");
        StartCoroutine("DebugMagic3");
        StartCoroutine("DebugMagic4");
        StartCoroutine("DebugMagic5");
        StartCoroutine("DebugMagic6");
    }

    IEnumerator DebugMagic1() // debugMagic1Condition �˻�
    {  
        while(true)
        {
          yield return new WaitForSeconds(0.1f);
          if(debugMagic1Condition >= 0) //���� �˻�
            {
                Debug.Log("DebugMagic1 ȹ��");
                skillManager.kakutokuAble.Add(Resources.Load<GameObject>("DebugMagic1"), 1);
                break;
            }     
        }
    }

    IEnumerator DebugMagic2() // debugMagic2Condition �˻�
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            if (debugMagic2Condition >= 0) //���� �˻�
            {
                Debug.Log("DebugMagic2 ȹ��");
                skillManager.kakutokuAble.Add(Resources.Load<GameObject>("DebugMagic2"), 2);
                break;
            }
        }
    }

    IEnumerator DebugMagic3() // debugMagic3Condition �˻�
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (debugMagic3Condition >= 0) //���� �˻�
            {
                Debug.Log("DebugMagic3 ȹ��");
                skillManager.kakutokuAble.Add(Resources.Load<GameObject>("DebugMagic3"), 3);
                break;
            }
        }
    }
    IEnumerator DebugMagic4() // debugMagic3Condition �˻�
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (debugMagic4Condition >= 0) //���� �˻�
            {
                Debug.Log("DebugMagic4 ȹ��");
                skillManager.kakutokuAble.Add(Resources.Load<GameObject>("DebugMagic4"), 4);
                break;
            }
        }
    }
    IEnumerator DebugMagic5() // debugMagic3Condition �˻�
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            if (debugMagic5Condition >= 0) //���� �˻�
            {
                Debug.Log("DebugMagic5 ȹ��");
                skillManager.kakutokuAble.Add(Resources.Load<GameObject>("DebugMagic5"), 5);
                break;
            }
        }
    }
    IEnumerator DebugMagic6() // debugMagic3Condition �˻�
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (debugMagic6Condition >= 0) //���� �˻�
            {
                Debug.Log("DebugMagic6 ȹ��");
                skillManager.kakutokuAble.Add(Resources.Load<GameObject>("DebugMagic6"), 6);
                break;
            }
        }
    }




}
