using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForceMultiplier = 10f;
    private Rigidbody rb;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isJumping = true;
            }

            if (touch.phase == TouchPhase.Ended && isJumping)
            {
                touchEndPos = touch.position;
                Vector2 swipe = touchEndPos - touchStartPos;

                GetComponent<Animator>().enabled = false;

                transform.parent = null;

                rb.isKinematic = false;
                rb.useGravity = true;

                Vector3 jumpForce = new Vector3(3f, swipe.y / 300f, -swipe.x / 300f) * jumpForceMultiplier;
                rb.AddForce(jumpForce, ForceMode.Impulse);

                isJumping = false;
            }
        }
    }
}
