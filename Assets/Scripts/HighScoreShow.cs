using UnityEngine;
using UnityEngine.UI;

public class HighScoreShow : MonoBehaviour {
    void Start() {
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        GetComponent<Text>().text = highScore.ToString();
    }
}
