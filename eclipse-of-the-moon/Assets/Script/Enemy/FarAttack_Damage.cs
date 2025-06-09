using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarAttack_Damage : MonoBehaviour
{
    private Player_Status player_Status;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        player_Status = GameObject.Find("Player").GetComponent<Player_Status>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player_Status.accept_Damage_Player(damage, "far");
            Destroy(gameObject);
        }else if(collision.gameObject.tag == "Enemy")
        {
            //do nothing
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
