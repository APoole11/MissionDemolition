using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class RigidbodySleep : MonoBehaviour
{
    private int sleepCountDown = 4;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sleepCountDown > 0)
        {
            rigid.Sleep();
            sleepCountDown--;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Projectile proj = collision.gameObject.GetComponent<Projectile>();
        if (proj != null)
        {
            Rigidbody rigid = proj.GetComponent<Rigidbody>();
            if(rigid.velocity.magnitude > 12.0f )
            {
                Debug.Log(rigid.velocity.magnitude);
                Destroy(this.gameObject);
            }
            
        }
    }


}
