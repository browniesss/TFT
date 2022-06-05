using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_Particle : MonoBehaviour
{
    public GameObject target_Champ;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("≥≠ µÓ¿Â");

        StartCoroutine(flame_DOT());
    }

    IEnumerator flame_DOT()
    {
        int dot_Count = 0;

        while (dot_Count < 8)
        {
            ChampionData c_data = target_Champ.GetComponent<ChampionData>();

            c_data.Damaged(c_data.MaxHP * 0.01f, false);
            dot_Count++;

            yield return new WaitForSeconds(1f);
        }

        GameObject.Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
