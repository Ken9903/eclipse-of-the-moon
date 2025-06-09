using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class GunShot_Trigger : MonoBehaviour
{
    public XRController controllerR;

    public Player_Status player_Status;

    private XRGrabInteractable grabInteractable;
    public Transform shot_start_point;
    private GunShot_Audio gunShot_Audio;
    private MagicPrepare magicPrepare;


    public float bullet_speed;
    public int bullet_count;

    public string bullet_type;
    public GameObject current_mag;
    public GameObject bullet;   //기본 공격, 스킬 공격 통합
    public int useMpAtGun;

    public float shot_time;


    public bool magEquiped = false;


    private bool reload = true;  //단발용 변수

    public int passive1RandomPercent; //패시브 1 발동 확률
    public int passive2RandomPercent; // //    2 발동 확률
    public int passive3RandomPercent; // //    3 발동 확률

    public AudioClip outMagSound;
    public AudioSource audio_source;



    // Start is called before the first frame update
    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        controllerR = GameObject.Find("RightHand Controller").GetComponent<XRController>();
        gunShot_Audio = GetComponent<GunShot_Audio>();

        magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();

        player_Status = GameObject.Find("Player").GetComponent<Player_Status>();

        audio_source = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        if (controllerR.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue))
        {
            if (buttonValue == true && magEquiped == true) // 탄창제거
            {
                Delete_Mag();
                audio_source.PlayOneShot(outMagSound);
            }
        }

        if (magEquiped == true)
        {
            if (controllerR.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerTargetR))
            {
                if (triggerTargetR >= 0.9 && bullet_type == "basic" && reload == true)
                {
                    Shot();
                    reload = false;  
                }

                if (triggerTargetR >= 0.9 && bullet_type == "skill" && reload == true)
                {
                    if(player_Status.player_Mp > useMpAtGun)
                    {
                        Skill_Shot(shot_time);
                        reload = false;

                        player_Status.player_Mp -= useMpAtGun;
                    }
                    
                }






                if (triggerTargetR <= 0.5)
                {
                    reload = true;
                }

            }
        }


    }

    void Shot()
    {
        
        if (bullet_count > 0)
        {
            /* 모든 패시브 스킬은 Magic Prepare에 등록되어있는 곳에서 가져와 사용.
             * 
             * 
             * 1스킬 랜덤성공시
             * 원래 불릿대신 등록되어있는 강화 스킬이 나감
             * 패시브 스킬 레벨업 시 조건 받아 스킬 배수와 이펙트가 바뀐 오브젝트(불릿)를 새로 등록 해 줌.
             * 강화효과는 기존 슛과 동일
             * 
             * 2스킬 랜덤 성공시
             * 기존 불릿이 사출
             * 총 자체에 발사포인트 추가.
             * 추가로 등록되어있는 사출기가 나감.
             * 패시브 스킬 레벨업 시 스킬 배수와 이펙트가 바뀐 오브젝트(나름 불릿)를 새로 등록 해 줌.
             * 패시브 갯수 스킬 래벨업시 magicprepare에서 받아와 이곳에서 랜덤하게 생성해서 발사해줌
             * 사출기 내부 구현은 작성 해놓은 문서 대로
             * 
             * 3스킬 랜덤 성공시
             * 기존 불릿이 사출
             * 추가로 등록되어있는 오브젝트가 나가되 이 오브젝트는 총알 다중 발사를 위한 스크립트 전용 오브젝트.
             * 패시브 갯수 스킬 래벨업시 magicprepare에서 받아와 이곳에서 랜덤값을 스크립트 전용 오브젝트에 전달.
             * 총알 다중 발사 오브젝트에는 코루틴으로 살짝의 딜레이를 준다음 동시 불릿 사출.
             * 총 자체에 발사포인트를 4개를 추가
             * 패시브 스킬 레벨업시 발사포인트를 한개씩 열어줌. for문을 통해 instantiate를해서 갯수 제어 ex 패시브 레벨이 25일떄 /5해서 랜덤 값
             * 최대 정해서 발생후에 전달
             * 
             * 스킬 등록 여부 파악 필요
             * 
             */
            int randomPassive1 = Random.Range(1, passive1RandomPercent);
            int randomPassive2 = Random.Range(1, passive2RandomPercent);
            int randomPassive3 = Random.Range(1, passive3RandomPercent);


            if (randomPassive1 == 1) //1스킬 랜덤 성공시
            {
                GameObject passive1 = Instantiate(magicPrepare.passiveBullet[0], shot_start_point.position, shot_start_point.rotation);
                passive1.GetComponent<Rigidbody>().AddForce(passive1.transform.forward * bullet_speed);

                controllerR.SendHapticImpulse(0.2f, 0.2f);
                gunShot_Audio.sound_shot();

                bullet_count--;

                Debug.Log("passive1");
            }
            else //1스킬이 성공 못했다는 것은 일단 기본 불릿이 사출 되는 것
            {
                GameObject bullet_set = Instantiate(bullet, shot_start_point.position, shot_start_point.rotation);
                bullet_set.GetComponent<Rigidbody>().AddForce(bullet_set.transform.forward * bullet_speed);

                controllerR.SendHapticImpulse(0.2f, 0.2f);
                gunShot_Audio.sound_shot();

                bullet_count--;
            }

            if(randomPassive2 == 1) //2스킬 랜덤 성공시
            {
                GameObject passive2 = Instantiate(magicPrepare.passiveBullet[1], shot_start_point.transform); // 위치 초기화 이유는 총 삭제시 계층 구조를 통해 본 오브젝트도 삭제해주기 위함.
                passive2.GetComponent<Passive2Shot>().passive2Level = magicPrepare.passive2Level;
                Debug.Log("passive2");
            }

            if (randomPassive3 == 1) //2스킬 랜덤 성공시
            {
                GameObject passive3 = Instantiate(magicPrepare.passiveBullet[2], shot_start_point.transform);
                passive3.GetComponent<Passive3Shot>().passive3Level = magicPrepare.passive3Level;
                Debug.Log("passive3");
            }


        }

    }

    void Skill_Shot(float shot_time)
    {
        if(bullet_count > 0)
        {
            GameObject skill_set = Instantiate(bullet, shot_start_point.transform);
            skill_set.transform.SetParent(shot_start_point);

            controllerR.SendHapticImpulse(0.3f, shot_time); 
            gunShot_Audio.sound_shot();

            bullet_count--;
        }
    }

    void Delete_Mag()
    {
        magEquiped = false;
        bullet = null;
        bullet_count = 0;
        bullet_speed = 0;
        bullet_type = null;

        current_mag.GetComponent<Rigidbody>().isKinematic = false;
        current_mag.GetComponent<Rigidbody>().useGravity = true;
        current_mag.transform.parent = null;

        Destroy(current_mag, 0.4f);
    }

    void Destory_gun(XRBaseInteractor interactor)
    { 
        Destroy(this.gameObject);
    }

}


