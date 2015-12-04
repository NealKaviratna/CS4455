using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private int score = 0;
	private float gameTimer;

	public Text scoreText;
	//public Text timeText;

	//private int minutes;

	private bool inGame;

	// Use this for initialization
	void Start () {
		inGame = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (inGame) {
			gameTimer += Time.deltaTime;
			//minutes = Mathf.RoundToInt (gameTimer) / 60;
			gameTimer %= 60;
			//Debug.Log (gameTimer.ToString ("F2"));
			scoreText.text = "Score: " + score;
			/*if (minutes == 0) {
				timeText.text = gameTimer.ToString ("F2");
			} else {
				timeText.text = minutes + ":" + gameTimer.ToString ("F2");
			}*/
		}
	}

	public void SetGame(bool playing) {
		inGame = playing;
	}

	public void addScore(int value) {
		score += value;
	}

	public int getScore() {
		return score;
	}
}
