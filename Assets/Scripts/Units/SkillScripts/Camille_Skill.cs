using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camille_Skill : MonoBehaviour
{
   

    public void OnTrigerEnter(Collider other)
    {
        Debug.Log(other.name + "ī������ �¾ƽ�");
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.transform.name + "ī������ �¾ƽ��");
    //}
}
