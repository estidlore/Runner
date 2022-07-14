using UnityEngine;
using UnityEngine.UI;
public class ScoreShow : MonoBehaviour {
    public Transform player;
    Text text;
    int score;
    void Start() {
        score = 0;
        text = GetComponent<Text>();
    }
    void Update() {
        score = (int) player.position.z;
        text.text = score.ToString();
    }

    public int getScore() {
        return score;
    }
}
