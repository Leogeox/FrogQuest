// using System.Collections.Generic;
// using UnityEngine;

// public class ObjectsBehevior : MonoBehaviour
// {
//     public int id;
//     private ObjectsData _data;
//     public List<int> Keyid;


//     private SpriteRenderer _spriteRend;
//     private Collider2D _collider2d;


//     void Awake()
//     {
//         TryGetComponent(out _spriteRend);
//         TryGetComponent(out _collider2d);
//     }

//     void Start()
//     {
//         _data = DataBaseManager.Instance.GetData(id);
//         Init();
//     }

//     public void AddKey(int keyData)
//     {
//         Debug.Log("Key added" + id );
//         Keyid.Add(keyData);
//     }

//     public bool ContainsKey(int keyData)
//     {
//         return Keyid.Contains(keyData);
//     }

//     public void RemoveKey(int keyData)
//     {
//         Keyid.Remove(keyData);
//     }

//     private void Init()
//     {
//         _spriteRend.sprite = _data.sprite;
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {

//         // var existingData = DataBaseManager.Instance.dataBaseObjects(id => id.label == _data.label);


//         if (collision.gameObject.CompareTag("Player"))
//         {
//             Debug.Log("Player got an object");
//             AddKey(id);

//             Destroy(gameObject);

//             //    if (existingData != null)
//             //    {
//             //        existingData.value += 1;
//             //    }
//         }

//         // Move door opening logic to the inventory if you want the inventory to manage keys and door interactions.
//         // For now, keep this logic here if you want the object to handle it directly.
//         if (keydoor != null)
//         {
//             if (ContainsKey(keydoor.GetKeyId()))
//             {
//                 RemoveKey(keydoor.GetKeyId());
//                 keydoor.OpenDoor();
//                 Debug.Log("Open Door and Key erased");
//             }
//         }
//     }
// }
