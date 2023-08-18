using System.Collections;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private DistanceJoint2D distanceJoint;
    [SerializeField] private float grappleCooldown;

    private bool canUseGrappler;
    private Animator am;
    private Rigidbody2D rb;

    void Start()
    {
        canUseGrappler = true;
        distanceJoint.enabled = false;
        am = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canUseGrappler)
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, mousePos);
            lineRenderer.SetPosition(1, transform.position);
            distanceJoint.connectedAnchor = mousePos;
            distanceJoint.enabled = true;
            lineRenderer.enabled = true;
            canUseGrappler = false;

           StartCoroutine(EnableGrapplerCooldown());
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            distanceJoint.enabled = false;
            lineRenderer.enabled = false;
        }
        if (distanceJoint.enabled)
        {
            lineRenderer.SetPosition(1, transform.position);
        }
        print(rb.velocity.sqrMagnitude);
        am.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }

    IEnumerator EnableGrapplerCooldown()
    {
        yield return new WaitForSeconds(grappleCooldown);
        canUseGrappler = true;
    }
}
