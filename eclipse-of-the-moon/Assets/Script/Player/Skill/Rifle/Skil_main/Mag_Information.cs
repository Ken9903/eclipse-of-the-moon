using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Mag_Information : MonoBehaviour
{
    public string bullet_type;

    public int bullet_count = 10;
    public float bullet_speed;
    public GameObject bullet ;
    public float shot_time = 0; // �߻� ���ӽð�.

    public int useMp;

    GameObject gun;
    GunShot_Trigger gunShot_Trigger;
    GunShot_Audio gunShot_Audio;

    private bool equiped = false;

    public GameObject basic_shot_parent;    // �ִϸ��̼ǿ� (Grab Interact On/Off)
    public AudioClip sound_shot;

    public AudioClip inMagSound;
    public AudioSource audio_source;

    public MagicPrepare magicPrepare;
    IEnumerator destroyTime()
    {
        yield return new WaitForSeconds(10);
        if (gunShot_Trigger.magEquiped == false)
        {
            magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();
            magicPrepare.use = false;
            Destroy(basic_shot_parent);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gun = GameObject.Find("TriggerPoint");

        gunShot_Trigger = gun.GetComponent<GunShot_Trigger>();
        gunShot_Audio = gun.GetComponent<GunShot_Audio>();

        audio_source = GetComponent<AudioSource>();

        StartCoroutine(destroyTime());

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "mag_hole" && gunShot_Trigger.magEquiped == false && equiped == false)
        {
            equiped = true;
            gunShot_Trigger.magEquiped = true;

            gunShot_Trigger.bullet_count = this.bullet_count;
            gunShot_Trigger.bullet_speed = this.bullet_speed;
            gunShot_Trigger.shot_time = this.shot_time;

            gunShot_Audio.bullet_wav = this.sound_shot;


            gunShot_Trigger.bullet = this.bullet; // skill or bullet

            gunShot_Trigger.bullet_type = bullet_type; //�ݹ�sound

            gunShot_Trigger.current_mag = this.gameObject; //�� �ڽ��� ����

            gunShot_Trigger.useMpAtGun = this.useMp;

            basic_shot_parent.GetComponent<XRGrabInteractable>().enabled = false;  // ������ ���̻� �� �����̰�
            basic_shot_parent.GetComponent<Mag_In_Anim>().enabled = true; //�ִϸ��̼� ����


            basic_shot_parent.transform.parent = gun.transform;  // �Ѱ� ���� �ٴϵ���

            gunShot_Trigger.magEquiped = true;

            Debug.Log("����");
            audio_source.PlayOneShot(inMagSound);

            destory_other_mag();



            
        }
    }

    void destory_other_mag()
    {
        MagicPrepare magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();
        magicPrepare.DestroyAll(basic_shot_parent.name); // �� ������Ʈ �����ϰ� �� ���� (������Ʈ�� ��¥ �̸��� �θ� ����)
    }
}
