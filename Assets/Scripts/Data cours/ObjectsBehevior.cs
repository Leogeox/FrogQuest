using System.Collections.Generic;
using UnityEngine;

public class ObjectsBehevior : MonoBehaviour
{
    public int id;
    private ObjectsData data;

    private SpriteRenderer _spriteRend;
    private Collider2D _collider2d;

    void Awake()
    {
        TryGetComponent(out _spriteRend);
        TryGetComponent(out _collider2d);
    }

    void Start()
    {
        data = DataBaseManager.Instance.GetData(id);
        Init();
    }

    private void Init()
    {
        _spriteRend.sprite = data.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //var existingData = DataBaseManager.Instance.dataBaseObjects(id => id.label == data.label);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player got an object");
            Destroy(gameObject);


            //if (existingData != null)
            //{
            //existingData.value += 1;
            //}
            //else
            //{
            //DataBaseManager.Instance.dataBaseObjects.Add(new ObjectsData(data.label, 1, data.sprite));
            //}
        }
    }   
}
