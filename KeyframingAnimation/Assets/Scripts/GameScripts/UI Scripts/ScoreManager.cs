using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	private int score = 0;
	private float gameTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameTimer += Time.deltaTime;
		//gameTimer = Mathf.Round (gameTimer * 100f) / 100;
		Debug.Log (gameTimer.ToString("F2"));
	}

	public void addScore(int value) {
		score += value;
	}

	public int getScore() {
		return score;
	}
}
