using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock_Wave : MonoBehaviour
{
    List<GameObject> champ_List = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!champ_List.Contains(other.gameObject))
            {
                other.GetComponent<ChampionData>().Damaged(100, false);
                champ_List.Add(other.gameObject);
            }
        }
    }

    void Start()
    {
        champ_List.Clear();
    }

    public void Shock_Wave_Init()
    {
        champ_List.Clear();
    }

    void Update()
    {

    }
}
