using System.Collections;
using UnityEngine;
public class PlayerMovement : MonoBehaviour {
    Rigidbody rb;
    float forwardForce = 1000f, jumpForce = 500f, sideSpeed = 25f;
    bool inGround;
    void Start() {
        rb = GetComponent<Rigidbody>();
        inGround = true;
    }
    void FixedUpdate() {
        // move forward
        rb.AddForce(0, 0, (forwardForce + Mathf.Sqrt(transform.position.z)) * Time.deltaTime);
        // lateral movement
        float sideForce = sideSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        rb.AddForce(sideForce, 0, 0, ForceMode.VelocityChange);
        // if fall
        if (rb.position.y <= 0) {
            FindObjectOfType<PlayManage>().gameOver();
        }
        // Rotate player when is on the air
        if (!inGround) {
            transform.RotateAround(transform.position, Vector3.right, 60f * Time.deltaTime);
        }
    }
    void Update() {
        // jump
        if (Input.GetKeyDown("w") && inGround) {
            // without deltaTime because it's called only once
            rb.AddForce(0, jumpForce, 0);
        }
    }
    public void setInGround(bool inGround) {
        this.inGround = inGround;
    }
}
