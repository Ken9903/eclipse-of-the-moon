using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachStone : MonoBehaviour
{

    public Catch_Stone catch_Stone;

    public bool hand_in_bag;
    // Start is called before the first frame update
    void Start()
    {
        catch_Stone = GameObject.Find("Bag").GetComponent<Catch_Stone>();
    }

    public void detach()
    {
        catch_Stone.isequiped = false;
        this.gameObject.GetComponent<Bomb>().isSelect = false;
        transform.parent = null;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;       

    }
    public void destroy()
    {
        Destroy(this.gameObject);
    }

    public void detachForTest()
    {
        catch_Stone.stone = this.gameObject;
        catch_Stone.isequiped = false;
        this.gameObject.GetComponent<Bomb>().isSelect = false;
        transform.parent = null;
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;


    }




}
