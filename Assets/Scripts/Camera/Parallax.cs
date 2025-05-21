using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public float mouvementScale;
    public Camera mainCamera;

    void Update()
    {
        this.transform.position = new Vector3(mainCamera.transform.position.x * mouvementScale, mainCamera.transform.position.y * mouvementScale, mainCamera.transform.position.z * mouvementScale);
    }

}

