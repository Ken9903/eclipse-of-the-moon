using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Logic_Col : MonoBehaviour
{
    private bool leftReady;
    private bool rightReady;

    private Transform leftPos;
    private Transform rightPos;

    private GameObject EyeTrans;
    private GameObject EyeTrans2;
    private GameObject EyeTrans3;
    private GameObject EyeTrans4;

    public GameObject DrawCircle;
    public GameObject Bomb;    //Bomb스크립트에서 받아옴.
    public GameObject TempTrans;

    public GameObject failParticle;

    float handPosY;
    bool use = false;
    bool drawed = false;

    Catch_Stone catch_Stone;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = GameObject.Find("LeftHandTrans").GetComponent<Transform>();
        rightPos = GameObject.Find("RightHandTrans").GetComponent<Transform>();

        EyeTrans = GameObject.Find("EyeTrans");
        TempTrans = GameObject.Find("TempTrans");

       catch_Stone = GameObject.Find("Bag").GetComponent<Catch_Stone>();
        catch_Stone.magic_ing = true;
    }
        // Update is called once per frame
        void Update()
        {
         RaycastHit hit;       
        int layerMask = 1 << LayerMask.NameToLayer("Terrain");

        if (leftPos.position.y < handPosY - 0.5f && rightPos.position.y < handPosY - 0.5f && use == false)
        {
            use = true;       

            if (Physics.Raycast(EyeTrans.transform.position, EyeTrans.transform.forward, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 insPos = hit.point;
                Debug.Log(hit.distance);
                TempTrans.transform.position = insPos;
                /*
                if (drawed == false)
                {
                    Instantiate(DrawCircle, TempTrans.transform);
                    drawed = true;
                }
                */

                if (hit.distance > 30)
                {
                   
                    EyeTrans2 = GameObject.Find("EyeTrans2");
                    if (Physics.Raycast(EyeTrans2.transform.position, EyeTrans2.transform.forward, out hit, Mathf.Infinity, layerMask))
                    {
                        insPos = hit.point;
                        TempTrans.transform.position = insPos;

                        if (hit.distance > 30)
                        {
                            EyeTrans3 = GameObject.Find("EyeTrans3");
                            if (Physics.Raycast(EyeTrans3.transform.position, EyeTrans3.transform.forward, out hit, Mathf.Infinity, layerMask))
                            {
                                insPos = hit.point;
                                TempTrans.transform.position = insPos;

                                if (hit.distance > 30)
                                {
                                    EyeTrans4 = GameObject.Find("EyeTrans4");
                                    if (Physics.Raycast(EyeTrans4.transform.position, EyeTrans4.transform.forward, out hit, Mathf.Infinity, layerMask))
                                    {
                                        insPos = hit.point;
                                        TempTrans.transform.position = insPos;
                                        if (hit.distance > 30)
                                        {
                                            Debug.Log("실패");
                                            Instantiate(failParticle, leftPos);
                                            Instantiate(failParticle, rightPos);
                                            catch_Stone.isequiped = false;
                                            catch_Stone.magic_ing = false;
                                            Destroy(this.gameObject);
                                        }
                                        else
                                        {
                                            Instantiate(Bomb, TempTrans.transform);
                                            catch_Stone.isequiped = false;
                                            catch_Stone.magic_ing = false;
                                            Debug.Log("발동4");
                                            Destroy(this.gameObject);
                                        }
                                    }
                                }
                                else
                                {
                                    Instantiate(Bomb, TempTrans.transform);
                                    catch_Stone.isequiped = false;
                                    catch_Stone.magic_ing = false;
                                    Debug.Log("발동3");
                                    Destroy(this.gameObject);
                                }
                            }
                        }
                        else
                        {
                            Instantiate(Bomb, TempTrans.transform);
                            catch_Stone.isequiped = false;
                            catch_Stone.magic_ing = false;
                            Debug.Log("발동2");
                            Destroy(this.gameObject);
                        }
                    }
                }
                else
                {
                    Instantiate(Bomb, TempTrans.transform);
                    catch_Stone.isequiped = false;
                    catch_Stone.magic_ing = false;
                    Debug.Log("발동1");
                    Destroy(this.gameObject);
                }


            }else             // 처음부터 레이가 검출안되는경우 ex.하늘로 쏘아진 Ray
            {               
                        EyeTrans4 = GameObject.Find("EyeTrans4");
                        if (Physics.Raycast(EyeTrans4.transform.position, EyeTrans4.transform.forward, out hit, Mathf.Infinity, layerMask))
                        {
                            Vector4 insPos = hit.point;
                            TempTrans.transform.position = insPos;

                            if (hit.distance > 30)
                            {
                              Debug.Log("실패하늘");
                              Instantiate(failParticle, leftPos);
                              Instantiate(failParticle, rightPos);
                              catch_Stone.isequiped = false;
                              catch_Stone.magic_ing = false;
                              Destroy(this.gameObject);
                             }
                            else
                            {
                                Instantiate(Bomb, TempTrans.transform);
                                catch_Stone.isequiped = false;
                        catch_Stone.magic_ing = false;
                        Destroy(this.gameObject);
                                Debug.Log("발동4");
                            }
                }
                else
                {
                    Instantiate(failParticle, leftPos);
                    Instantiate(failParticle, rightPos);
                    catch_Stone.isequiped = false;
                    catch_Stone.magic_ing = false;
                    Destroy(this.gameObject);
                    Debug.Log("몰?루"); // 벽이나 이상한 물체에 맞아 예상치 못한 상황이 걸렸을 때(모든 if에 충족이 안됨)
                }


                
             }
                   
             }
        }
        

      
    
        void SetHandPos()
        {
            if (leftReady == true && rightReady == true)
            {
                handPosY = rightPos.position.y;
              
        }
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "MagicPrepare_L")
            {
                leftReady = true;
                SetHandPos();
            }

            if (other.gameObject.name == "MagicPrepare_R")
            {
                rightReady = true;
                SetHandPos();
            }

        }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "MagicPrepare_L")
        {
            leftReady = false;
            
        }
        if (other.gameObject.name == "MagicPrepare_R")
        {
            rightReady = false;
            
        }
    }
} 
