using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_1_Chapter6 : MonoBehaviour
{
    public Transform[] spawnPoint = new Transform[11];

    public GameObject[] monster = new GameObject[13];

    public float betweenTime = 10;

    IEnumerator Wave1()
    {
        foreach(Transform t in spawnPoint)
        {
            Instantiate(monster[0], t);
        }
        yield return new WaitForSeconds(betweenTime);

        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[1], t);
        }
        yield return new WaitForSeconds(betweenTime);

        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[2], t);
        }
        yield return new WaitForSeconds(betweenTime);

        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[3], t);
        }
        yield return new WaitForSeconds(betweenTime);
    }

    IEnumerator Wave2()
    {
        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[7], t);
        }
        yield return new WaitForSeconds(betweenTime);

        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[5], t);
        }
        yield return new WaitForSeconds(betweenTime);

        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[6], t);
        }
        yield return new WaitForSeconds(betweenTime);

        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[7], t);
        }
        yield return new WaitForSeconds(betweenTime);
    }

    IEnumerator Wave3()
    {
        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[8], t);
        }
        yield return new WaitForSeconds(betweenTime);

        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[9], t);
        }
        yield return new WaitForSeconds(betweenTime);

        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[5], t);
        }
        yield return new WaitForSeconds(betweenTime);

        foreach (Transform t in spawnPoint)
        {
            Instantiate(monster[11], t);
        }
        yield return new WaitForSeconds(betweenTime);
    }




    public void playWave1()
    {
        StartCoroutine(Wave1());
    }
    public void playWave2()
    {
        StartCoroutine(Wave2());   
    }
    public void playWave3()
    {
        StartCoroutine(Wave3());
    }
}
