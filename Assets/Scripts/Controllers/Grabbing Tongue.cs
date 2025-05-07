using UnityEngine;

public class GrabbingTongue : MonoBehaviour
{
    [SerializeField] private float grappleLenght;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer tongue;

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        tongue.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(
            origin: Camera.main.ScreenToWorldPoint(Input.mousePosition),
            direction: Vector2.zero,
            distance: Mathf.Infinity,
            layerMask: grappleLayer
            );

            if (hit.collider != null)
            {
                grapplePoint = hit.point;
                grapplePoint.z = 0;
                joint.connectedAnchor = grapplePoint;
                joint.enabled = true;
                joint.distance = grappleLenght;
                tongue.SetPosition(0, grapplePoint);
                tongue.SetPosition(1, transform.position);
                tongue.enabled = true;
                audioManager.PlaySFX(audioManager.useTongue);
                Debug.Log("player tongue");

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            joint.enabled = false;
            tongue.enabled = false;
        }

        if (tongue.enabled == true)
        {
            tongue.SetPosition(1, transform.position);
        }
    }
}