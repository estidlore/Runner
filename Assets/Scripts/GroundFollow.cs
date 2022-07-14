using UnityEngine;

public class GroundFollow : MonoBehaviour {
    public Transform player;
    float offset;
    void Start() {
        offset = transform.position.z - player.position.z;
    }
    void FixedUpdate() {
        transform.position = new Vector3(0, 0, player.position.z + offset);
    }
}
