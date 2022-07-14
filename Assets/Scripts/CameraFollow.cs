using UnityEngine;
public class CameraFollow : MonoBehaviour {
    public Transform player;
    Vector3 offset;
    void Start() {
        offset = player.position;
    }
    void FixedUpdate() {
        // Camera position
        transform.localPosition = player.localPosition - offset;
        Vector3 pos = transform.localPosition;
        // Camera rotation
        transform.localRotation = Quaternion.Euler(pos.y * 2,-pos.x, pos.x);
    }
}
