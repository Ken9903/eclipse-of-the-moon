using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive2Shot : MonoBehaviour
{
    public GameObject passive2Bullet; //실체
    public float bulletSpeed;
    public float bulletbetweenTime;

    Transform pass2point1;
    Transform pass2point2;
    Transform pass2point3;
    Transform pass2point4;
    Transform pass2point5;

    public int passive2Level;
    int shot_count;

    IEnumerator Shot_passive2()
    {
        if(shot_count == 1)
        {
            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass1 = Instantiate(passive2Bullet, pass2point1.position, pass2point1.rotation);
            pass1.GetComponent<Rigidbody>().AddForce(pass1.transform.forward * bulletSpeed);

            //진동
            //오디오
        }
        else if(shot_count == 2)
        {
            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass1 = Instantiate(passive2Bullet, pass2point1.position, pass2point1.rotation);
            pass1.GetComponent<Rigidbody>().AddForce(pass1.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass2 = Instantiate(passive2Bullet, pass2point2.position, pass2point2.rotation);
            pass2.GetComponent<Rigidbody>().AddForce(pass2.transform.forward * bulletSpeed);


        }
        else if(shot_count == 3)
        {
            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass1 = Instantiate(passive2Bullet, pass2point1.position, pass2point1.rotation);
            pass1.GetComponent<Rigidbody>().AddForce(pass1.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass2 = Instantiate(passive2Bullet, pass2point2.position, pass2point2.rotation);
            pass2.GetComponent<Rigidbody>().AddForce(pass2.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass3 = Instantiate(passive2Bullet, pass2point3.position, pass2point3.rotation);
            pass3.GetComponent<Rigidbody>().AddForce(pass3.transform.forward * bulletSpeed);

        }
        else if(shot_count == 4)
        {
            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass1 = Instantiate(passive2Bullet, pass2point1.position, pass2point1.rotation);
            pass1.GetComponent<Rigidbody>().AddForce(pass1.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass2 = Instantiate(passive2Bullet, pass2point2.position, pass2point2.rotation);
            pass2.GetComponent<Rigidbody>().AddForce(pass2.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass3 = Instantiate(passive2Bullet, pass2point3.position, pass2point3.rotation);
            pass3.GetComponent<Rigidbody>().AddForce(pass3.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass4 = Instantiate(passive2Bullet, pass2point4.position, pass2point4.rotation);
            pass4.GetComponent<Rigidbody>().AddForce(pass4.transform.forward * bulletSpeed);
        }
        else if(shot_count >= 5)
        {
            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass1 = Instantiate(passive2Bullet, pass2point1.position, pass2point1.rotation);
            pass1.GetComponent<Rigidbody>().AddForce(pass1.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass2 = Instantiate(passive2Bullet, pass2point2.position, pass2point2.rotation);
            pass2.GetComponent<Rigidbody>().AddForce(pass2.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass3 = Instantiate(passive2Bullet, pass2point3.position, pass2point3.rotation);
            pass3.GetComponent<Rigidbody>().AddForce(pass3.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass4 = Instantiate(passive2Bullet, pass2point4.position, pass2point4.rotation);
            pass4.GetComponent<Rigidbody>().AddForce(pass4.transform.forward * bulletSpeed);

            yield return new WaitForSeconds(bulletbetweenTime);
            GameObject pass5 = Instantiate(passive2Bullet, pass2point5.position, pass2point5.rotation);
            pass5.GetComponent<Rigidbody>().AddForce(pass5.transform.forward * bulletSpeed);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        shot_count = Random.Range(1, (int)passive2Level / 2);
        
        if(passive2Level != 0)
        {
            if (shot_count == 1)
            {
                pass2point1 = GameObject.Find("pass2point1").GetComponent<Transform>();
            }
            else if (shot_count == 2)
            {
                pass2point1 = GameObject.Find("pass2point1").GetComponent<Transform>();
                pass2point2 = GameObject.Find("pass2point5").GetComponent<Transform>();
            }
            else if (shot_count == 3)
            {
                pass2point1 = GameObject.Find("pass2point1").GetComponent<Transform>();
                pass2point2 = GameObject.Find("pass2point3").GetComponent<Transform>();
                pass2point3 = GameObject.Find("pass2point5").GetComponent<Transform>();
            }
            else if (shot_count == 4)
            {
                pass2point1 = GameObject.Find("pass2point1").GetComponent<Transform>();
                pass2point2 = GameObject.Find("pass2point2").GetComponent<Transform>();
                pass2point3 = GameObject.Find("pass2point3").GetComponent<Transform>();
                pass2point4 = GameObject.Find("pass2point5").GetComponent<Transform>();
            }
            else if (shot_count >= 5)
            {
                pass2point1 = GameObject.Find("pass2point1").GetComponent<Transform>();
                pass2point2 = GameObject.Find("pass2point2").GetComponent<Transform>();
                pass2point3 = GameObject.Find("pass2point3").GetComponent<Transform>();
                pass2point4 = GameObject.Find("pass2point4").GetComponent<Transform>();
                pass2point5 = GameObject.Find("pass2point5").GetComponent<Transform>();
            }
            else
            {
                Debug.Log("passive2Shot shotcount error");
            }
            StartCoroutine(Shot_passive2());
        }
    }
       

    
    
}
