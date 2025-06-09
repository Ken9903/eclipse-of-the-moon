using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerLevelUi : MonoBehaviour
{
    public int level;

    public Text levelText;
    public Button button;

    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(delegate { OnClick(); });

        levelText.text = level.ToString() + "Floar";
    }

    private void OnClick()
    {
        portal.SetActive(false);
        portal.SetActive(true);   
        portal.GetComponent<SceneChanger>().nextScene = level.ToString() + "Floar";
    }
}
