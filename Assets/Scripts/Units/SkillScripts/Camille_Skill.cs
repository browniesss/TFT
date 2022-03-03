using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camille_Skill : MonoBehaviour
{
   

    public void OnTrigerEnter(Collider other)
    {
        Debug.Log(other.name + "카밀한테 맞아써");
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.transform.name + "카밀한테 맞아써ㅑ");
    //}
}
