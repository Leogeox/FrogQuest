using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    public Transform playerTransform;
    public float normalHeight, crouchHeight;
    public float speedCrouch = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, crouchHeight, playerTransform.localScale.z * speedCrouch * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            playerTransform.localScale = new Vector3(playerTransform.localScale.x, normalHeight, playerTransform.localScale.z * speedCrouch * Time.deltaTime);
        }
    }
}
