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

    public void destroy_Coroutine_Start()
    {
        StartCoroutine(destroy_Coroutine());
    }

    IEnumerator destroy_Coroutine()
    {
        yield return new WaitForSeconds(0.4f);

        GameManager.Resource.Destroy(this.gameObject);
    }

    void Update()
    {

    }
}
