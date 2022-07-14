using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayManage : MonoBehaviour {
    public PlayerMovement playerMovement;
    public ScoreShow scoreShow;
    bool hasEnded = false;
    public void gameOver() {
        if (!hasEnded) {
            hasEnded = true;
            playerMovement.enabled = false;
            Invoke("restart", 2f);
        }
    }
    void restart() {
        int score = scoreShow.getScore();
        // Get the variable "highscore" or zero by default
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        if (highScore < score) {
            // Set the highscore to score since is higher
            PlayerPrefs.SetInt("highscore", score);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
