using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camille_Skill : MonoBehaviour
{
   

    public void OnTrigerStay(Collider other)
    {
        Debug.Log(other.name + "ī������ �¾ƽ�");
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Enemy")
        {
            
            Debug.Log(collision.transform.name + "ī������ �¾ƽ��");
        }
        
    }
}
