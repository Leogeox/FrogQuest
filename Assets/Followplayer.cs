using UnityEngine;

public class Followplayer : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}

