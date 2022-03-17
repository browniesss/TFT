using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Util : Singleton<Util>
{
    public GameObject FindNearestObjectByTag(string tag)
    {
        // 탐색할 오브젝트 목록을 List 로 저장합니다.
        var objects = GameObject.FindGameObjectsWithTag(tag).ToList();

        // LINQ 메소드를 이용해 가장 가까운 적을 찾습니다.
        var neareastObject = objects
            .OrderBy(obj =>
            {
                return Vector3.Distance(transform.position, obj.transform.position);
            })
        .FirstOrDefault();

        return neareastObject;
    }

    public GameObject FindNearestObjectByTag(GameObject champ, string tag)
    {
        // 탐색할 오브젝트 목록을 List 로 저장합니다.
        var objects = GameObject.FindGameObjectsWithTag(tag).ToList();

        objects.Remove(champ);

        // LINQ 메소드를 이용해 가장 가까운 적을 찾습니다.
        var neareastObject = objects
            .OrderBy(obj =>
            {
                return Vector3.Distance(champ.transform.position, obj.transform.position);
            })
        .FirstOrDefault();

        return neareastObject;
    }

    public List<GameObject> FindNearestObjectsByTag(GameObject champ, string tag)
    {
        // 탐색할 오브젝트 목록을 List 로 저장합니다.
        var objects = GameObject.FindGameObjectsWithTag(tag).ToList();

        // LINQ 메소드를 이용해 가장 가까운 적을 찾습니다.
        var neareastObjects = objects
            .OrderBy(obj =>
            {
                return Vector3.Distance(champ.transform.position, obj.transform.position);
            }).ToList<GameObject>();

        return neareastObjects;
    }
}
