using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Mag_In_Anim : MonoBehaviour
{
    IEnumerator LeftHandMoveBack()
    {
        yield return new WaitForSeconds(0.1f);
        leftHand.GetComponent<XRController>().enabled = true;
        Debug.Log("매그 애니메이션 컨트롤러 온");
        this.enabled = false;

    }

    public GameObject leftHand;
    public Transform anim_end_point;
    // Start is called before the first frame update
    void Start()
    {
        leftHand = GameObject.Find("LeftHand Controller");
        leftHand.GetComponent<XRController>().enabled = false;   // 애니메이션중 이동 금지.
        Debug.Log("매그 애니메이션 컨트롤러 오프");

        anim_end_point = GameObject.Find("anim_end_point").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position,anim_end_point.position,0.2f);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, anim_end_point.rotation, 0.2f);
        leftHand.transform.position = Vector3.Lerp(leftHand.transform.position, anim_end_point.position, 0.2f);
        leftHand.transform.rotation = Quaternion.Lerp(leftHand.transform.rotation, anim_end_point.rotation, 0.2f);

        StartCoroutine(LeftHandMoveBack());
    }

    private void OnDisable()
    {
        leftHand.GetComponent<XRController>().enabled = true;
    }
}
