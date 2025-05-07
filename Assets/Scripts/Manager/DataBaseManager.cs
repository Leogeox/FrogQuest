using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    private static DataBaseManager _instance;
    public static DataBaseManager Instance => _instance;

    [SerializeField] public DataBaseObjects dataBaseObjects;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public ObjectsData GetData(int id)
    {
        id = Mathf.Clamp(id, 0, dataBaseObjects.datas.Count - 1);
        return dataBaseObjects.datas[id];
    }

}
