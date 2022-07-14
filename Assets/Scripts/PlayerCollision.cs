using UnityEngine;
public class PlayerCollision : MonoBehaviour {
    public CameraFollow cameraFollow;
    public CameraShake cameraShake;
    public GroundFollow groundFollow;
    // Instance of the script PlayerMovement.cs
    PlayerMovement playerMovement;
    Rigidbody rb;
    void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.collider.tag == "obstacle") {
            cameraFollow.enabled = false;
            groundFollow.enabled = false;
            StartCoroutine(cameraShake.shake(0.3f, Mathf.Sqrt(rb.velocity.magnitude) / 25));
            FindObjectOfType<PlayManage>().gameOver();
        } else if(collisionInfo.collider.tag == "ground") {
            StartCoroutine(cameraShake.shake(0.1f, Mathf.Sqrt(rb.velocity.magnitude) / 100));
            playerMovement.setInGround(true);
        }
    }
    void OnCollisionExit(Collision collisionInfo) {
        if(collisionInfo.collider.tag == "ground") {
            playerMovement.setInGround(false);
        }
    }
}
