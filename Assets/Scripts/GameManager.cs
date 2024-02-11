using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI messagesTxt;

    public Canvas gameCanvas;  // Drag your Canvas GameObject here in the Inspector

    public int score = 0;
    public float time = 120;

    public static GameManager instance;

    public enum State { stopped, playing, paused }
    public State myState;

    void Start()
    {
        instance = this;
        myState = State.paused;

        if (gameCanvas != null)
        {
            scoreTxt.rectTransform.SetParent(gameCanvas.transform, false);
            timeTxt.rectTransform.SetParent(gameCanvas.transform, false);
            messagesTxt.rectTransform.SetParent(gameCanvas.transform, false);

            scoreTxt.rectTransform.anchoredPosition = new Vector2(10f, -10f);
            timeTxt.rectTransform.anchoredPosition = new Vector2(10f, -30f);
            messagesTxt.rectTransform.anchoredPosition = new Vector2(0f, 0f);
            messagesTxt.text = "Paused: Press P to continue";
        }

        time = 120;
        UpdateTimeDisplay();

        // Pause the game at the start
        Time.timeScale = 0f;

        // Ensure the paused text is visible at the start
        messagesTxt.gameObject.SetActive(true);
    }

    void Update()
    {
        switch (myState)
        {
            case State.stopped:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    myState = State.playing;
                    messagesTxt.text = "";
                    Time.timeScale = 1f;
                    messagesTxt.gameObject.SetActive(false); // Hide the text when playing
                }
                break;
            case State.playing:
                time -= Time.deltaTime;
                UpdateTimeDisplay();
                if (time <= 0)
                {
                    myState = State.stopped;
                    messagesTxt.text = "Game over. Press Fire to restart game";
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    myState = State.paused;
                    messagesTxt.text = "Paused: Press P to continue";
                    Time.timeScale = 0f;
                    messagesTxt.gameObject.SetActive(true); // Show the text when paused
                }
                break;
            case State.paused:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    myState = State.playing;
                    messagesTxt.text = "";
                    Time.timeScale = 1f;
                    messagesTxt.gameObject.SetActive(false); // Hide the text when playing
                }
                break;
        }
    }

    void UpdateTimeDisplay()
    {
        timeTxt.text = "Time: " + Mathf.Max(0, time).ToString("00.0");
    }

    public void IncreaseScore(int inc)
    {
        score += inc;
        scoreTxt.text = "Score: " + score;
    }
}
