using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem;

public class GrabController : MonoBehaviour
{
    [SerializeField] private Transform _grabPoint;
    [SerializeField] private Transform _rayPoint;
    [SerializeField] private float _rayDistance;

    private GameObject grabbedObject;
    public LayerMask _layerIndex;

    AudioManager audioManager;
    public Animator animator;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current.qKey.wasReleasedThisFrame)
            OnAction();
    }

    public void OnAction()
    {
        if (grabbedObject == null)
            Grab();
        else
            Drop();
    }

    void Grab()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(_rayPoint.position, transform.right, _rayDistance, _layerIndex);

        if (hitInfo.collider != null)
        {
            grabbedObject = hitInfo.collider.gameObject;
            grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            grabbedObject.transform.position = _grabPoint.position;
            grabbedObject.transform.SetParent(transform);
            animator.SetBool("isGrabbed", true);
        }
    }

    void Drop()
    {
        grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        grabbedObject.transform.SetParent(null);
        grabbedObject = null;
        animator.SetBool("isGrabbed", false);

        if (gameObject.CompareTag("NonGrass"))
        {
            audioManager.PlaySFX(audioManager.fall);
            Debug.Log("player drop");
        }
        else
        {
            audioManager.PlaySFX(audioManager.fallOnGrass);
            Debug.Log("player frop grass");
        }
    }

}
