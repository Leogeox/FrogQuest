using System.Collections.Generic;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DataBaseObjects", menuName = "Data/Objects", order = 1)]

// faire pour objects 
public class DataBaseObjects : ScriptableObject
{
    public List<ObjectsData> datas = new();

    public ObjectsData GetData (int id)
    {
        id = Mathf.Clamp(id, 0, datas.Count);
        return datas[id];
    }
}
