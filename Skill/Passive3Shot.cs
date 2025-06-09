using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive3Shot : MonoBehaviour
{
    public GameObject passive3Bullet; //실체
    public float bulletSpeed;

    public float ShotWaitTime;

    Transform pass3point1;
    Transform pass3point2;
    Transform pass3point3;
    Transform pass3point4;

    public int passive3Level;
    int shot_count;
    IEnumerator Shot_passive3()
    {
        yield return new WaitForSeconds(ShotWaitTime);

        if (shot_count == 1)
        {
            GameObject pass1 = Instantiate(passive3Bullet, pass3point1.position, pass3point1.rotation);
            pass1.GetComponent<Rigidbody>().AddForce(pass1.transform.forward * bulletSpeed);

            //진동
            //오디오
        }
        else if (shot_count == 2)
        {
            GameObject pass1 = Instantiate(passive3Bullet, pass3point1.position, pass3point1.rotation);
            pass1.GetComponent<Rigidbody>().AddForce(pass1.transform.forward * bulletSpeed);

            GameObject pass2 = Instantiate(passive3Bullet, pass3point2.position, pass3point2.rotation);
            pass2.GetComponent<Rigidbody>().AddForce(pass2.transform.forward * bulletSpeed);


        }
        else if (shot_count == 3)
        {
            GameObject pass1 = Instantiate(passive3Bullet, pass3point1.position, pass3point1.rotation);
            pass1.GetComponent<Rigidbody>().AddForce(pass1.transform.forward * bulletSpeed);

            GameObject pass2 = Instantiate(passive3Bullet, pass3point2.position, pass3point2.rotation);
            pass2.GetComponent<Rigidbody>().AddForce(pass2.transform.forward * bulletSpeed);

            GameObject pass3 = Instantiate(passive3Bullet, pass3point3.position, pass3point3.rotation);
            pass3.GetComponent<Rigidbody>().AddForce(pass3.transform.forward * bulletSpeed);

        }
        else if (shot_count == 4)
        {
            GameObject pass1 = Instantiate(passive3Bullet, pass3point1.position, pass3point1.rotation);
            pass1.GetComponent<Rigidbody>().AddForce(pass1.transform.forward * bulletSpeed);

            GameObject pass2 = Instantiate(passive3Bullet, pass3point2.position, pass3point2.rotation);
            pass2.GetComponent<Rigidbody>().AddForce(pass2.transform.forward * bulletSpeed);

            GameObject pass3 = Instantiate(passive3Bullet, pass3point3.position, pass3point3.rotation);
            pass3.GetComponent<Rigidbody>().AddForce(pass3.transform.forward * bulletSpeed);

            GameObject pass4 = Instantiate(passive3Bullet, pass3point4.position, pass3point4.rotation);
            pass4.GetComponent<Rigidbody>().AddForce(pass4.transform.forward * bulletSpeed);
        }
       else
        {
            Debug.Log("Passive3 error");
        }



    }

    // Start is called before the first frame update
    void Start()
    {
        shot_count = Random.Range(1, (int)passive3Level / 3);

        if(passive3Level != 0)
        {
            if (shot_count == 1)
            {
                pass3point1 = GameObject.Find("shotgunPoint_left").GetComponent<Transform>();
            }
            else if (shot_count == 2)
            {
                pass3point1 = GameObject.Find("shotgunPoint_left").GetComponent<Transform>();
                pass3point2 = GameObject.Find("shotgunPoint_right").GetComponent<Transform>();
            }
            else if (shot_count == 3)
            {
                pass3point1 = GameObject.Find("shotgunPoint_left").GetComponent<Transform>();
                pass3point2 = GameObject.Find("shotgunPoint_right").GetComponent<Transform>();
                pass3point3 = GameObject.Find("shotgunPoint_down").GetComponent<Transform>();
            }
            else if (shot_count >= 4)
            {
                pass3point1 = GameObject.Find("shotgunPoint_left").GetComponent<Transform>();
                pass3point2 = GameObject.Find("shotgunPoint_right").GetComponent<Transform>();
                pass3point3 = GameObject.Find("shotgunPoint_down").GetComponent<Transform>();
                pass3point4 = GameObject.Find("shotgunPoint_up").GetComponent<Transform>();
            }
            else
            {
                Debug.Log("passive3Shot shotcount error");
            }

            StartCoroutine(Shot_passive3());
        }



       
    }

  
}
