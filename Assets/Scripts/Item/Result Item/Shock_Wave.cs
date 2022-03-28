using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock_Wave : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<ChampionData>().Damaged(100, false);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
