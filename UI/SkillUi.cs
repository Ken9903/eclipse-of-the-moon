using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUi : MonoBehaviour
{
    private SkillManager skillManager;

    public Text nameText;
    public Button button;

    private GameObject tempUiObj;

    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { OnClick(); });
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
    }

    public void Init(GameObject name)
    {
        nameText.text = name.name;
        tempUiObj = name;
    }
    private void OnClick()
    {
        skillManager.tempApplyMagic = tempUiObj;
    }
}
