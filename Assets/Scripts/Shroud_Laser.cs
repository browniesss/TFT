using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroud_Laser : MonoBehaviour
{
    public GameObject shoot_Champ;

    private void OnTriggerEnter(Collider other)
    {
        if (shoot_Champ.CompareTag("MyTeam"))
        {
            if (other.CompareTag("Enemy"))
            {
                ChampionData otherChamp = other.GetComponent<ChampionData>();

                otherChamp.MP = 0;
            }
        }
        else
        {
            if (other.CompareTag("MyTeam"))
            {
                ChampionData otherChamp = other.GetComponent<ChampionData>();

                otherChamp.MP = 0;
            }
        }
    }

    void Start()
    {
        transform.localScale *= 1.35f;
    }

    void Update()
    {

    }
}
