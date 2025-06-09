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
    public GameObject bullet;   //�⺻ ����, ��ų ���� ����
    public int useMpAtGun;

    public float shot_time;


    public bool magEquiped = false;


    private bool reload = true;  //�ܹ߿� ����

    public int passive1RandomPercent; //�нú� 1 �ߵ� Ȯ��
    public int passive2RandomPercent; // //    2 �ߵ� Ȯ��
    public int passive3RandomPercent; // //    3 �ߵ� Ȯ��

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
            if (buttonValue == true && magEquiped == true) // źâ����
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
            /* ��� �нú� ��ų�� Magic Prepare�� ��ϵǾ��ִ� ������ ������ ���.
             * 
             * 
             * 1��ų ����������
             * ���� �Ҹ���� ��ϵǾ��ִ� ��ȭ ��ų�� ����
             * �нú� ��ų ������ �� ���� �޾� ��ų ����� ����Ʈ�� �ٲ� ������Ʈ(�Ҹ�)�� ���� ��� �� ��.
             * ��ȭȿ���� ���� ���� ����
             * 
             * 2��ų ���� ������
             * ���� �Ҹ��� ����
             * �� ��ü�� �߻�����Ʈ �߰�.
             * �߰��� ��ϵǾ��ִ� ����Ⱑ ����.
             * �нú� ��ų ������ �� ��ų ����� ����Ʈ�� �ٲ� ������Ʈ(���� �Ҹ�)�� ���� ��� �� ��.
             * �нú� ���� ��ų �������� magicprepare���� �޾ƿ� �̰����� �����ϰ� �����ؼ� �߻�����
             * ����� ���� ������ �ۼ� �س��� ���� ���
             * 
             * 3��ų ���� ������
             * ���� �Ҹ��� ����
             * �߰��� ��ϵǾ��ִ� ������Ʈ�� ������ �� ������Ʈ�� �Ѿ� ���� �߻縦 ���� ��ũ��Ʈ ���� ������Ʈ.
             * �нú� ���� ��ų �������� magicprepare���� �޾ƿ� �̰����� �������� ��ũ��Ʈ ���� ������Ʈ�� ����.
             * �Ѿ� ���� �߻� ������Ʈ���� �ڷ�ƾ���� ��¦�� �����̸� �ش��� ���� �Ҹ� ����.
             * �� ��ü�� �߻�����Ʈ�� 4���� �߰�
             * �нú� ��ų �������� �߻�����Ʈ�� �Ѱ��� ������. for���� ���� instantiate���ؼ� ���� ���� ex �нú� ������ 25�ϋ� /5�ؼ� ���� ��
             * �ִ� ���ؼ� �߻��Ŀ� ����
             * 
             * ��ų ��� ���� �ľ� �ʿ�
             * 
             */
            int randomPassive1 = Random.Range(1, passive1RandomPercent);
            int randomPassive2 = Random.Range(1, passive2RandomPercent);
            int randomPassive3 = Random.Range(1, passive3RandomPercent);


            if (randomPassive1 == 1) //1��ų ���� ������
            {
                GameObject passive1 = Instantiate(magicPrepare.passiveBullet[0], shot_start_point.position, shot_start_point.rotation);
                passive1.GetComponent<Rigidbody>().AddForce(passive1.transform.forward * bullet_speed);

                controllerR.SendHapticImpulse(0.2f, 0.2f);
                gunShot_Audio.sound_shot();

                bullet_count--;

                Debug.Log("passive1");
            }
            else //1��ų�� ���� ���ߴٴ� ���� �ϴ� �⺻ �Ҹ��� ���� �Ǵ� ��
            {
                GameObject bullet_set = Instantiate(bullet, shot_start_point.position, shot_start_point.rotation);
                bullet_set.GetComponent<Rigidbody>().AddForce(bullet_set.transform.forward * bullet_speed);

                controllerR.SendHapticImpulse(0.2f, 0.2f);
                gunShot_Audio.sound_shot();

                bullet_count--;
            }

            if(randomPassive2 == 1) //2��ų ���� ������
            {
                GameObject passive2 = Instantiate(magicPrepare.passiveBullet[1], shot_start_point.transform); // ��ġ �ʱ�ȭ ������ �� ������ ���� ������ ���� �� ������Ʈ�� �������ֱ� ����.
                passive2.GetComponent<Passive2Shot>().passive2Level = magicPrepare.passive2Level;
                Debug.Log("passive2");
            }

            if (randomPassive3 == 1) //2��ų ���� ������
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


