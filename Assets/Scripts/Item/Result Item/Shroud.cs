using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroud : ItemInfo
{
    public override void Item_Battle_Init(ChampionData champ)
    {
        GameObject prefab_laser = Resources.Load("Prefabs/Bullets/Shroud_Laser") as GameObject;

        GameObject laser = GameObject.Instantiate(prefab_laser, champ.transform);
        laser.GetComponent<Shroud_Laser>().shoot_Champ = champ.gameObject;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
