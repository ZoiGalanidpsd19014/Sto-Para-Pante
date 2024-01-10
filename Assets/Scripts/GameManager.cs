using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    // Start is called before the first frame update
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI timeTxt;
    public TextMeshProUGUI messagesTxt;

    int score = 0;
    float time = 90;

    public static GameManager instance;

    public enum State {  stopped, playing, paused }
    public State myState;

    void Start() {
        instance = this;
        myState = State.stopped;
    }

    // Update is called once per frame
    void Update() {
        switch (myState)
        {
            case State.stopped:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    myState = State.playing;
                    time = 30;
                }
                break;
            case State.playing:
                time -= Time.deltaTime;
                timeTxt.text = "Time: " + time.ToString("00.0");
                if (time<0)
                {
                    myState = State.stopped;
                    messagesTxt.text = "Game over. Press Fire to restart game";
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                    myState = State.paused;
                    messagesTxt.text = "Paused : press P to continue";
                }

                break;
            case State.paused:
                if (Input.GetKeyDown(KeyCode.P))
                {
                    myState = State.playing;
                    
                   
                }
                break;


        }
    }

    public void IncreaseScore(int inc) {
        score += inc;
        scoreTxt.text = "Score: " + score;
    }
}
