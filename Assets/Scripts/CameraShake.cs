using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public IEnumerator shake(float duration, float magnitude) {
        float elapsed = 0; // elapsed time
        Vector3 position = transform.localPosition;
        while (elapsed < duration) {
            Vector3 move = new Vector3(Random.Range(-1, 1),
                    Random.Range(-1, 1), 0) * magnitude;
            transform.localPosition = position + move;
            elapsed += Time.deltaTime;
            yield return null; // because of the IEnumerator
        }
        transform.localPosition = position;
    }
    
}
