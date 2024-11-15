using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Transform playerPaddle;
	public Transform enemyPaddle;
	public BallController ballController;
	public int playerScore = 0;
	public int enemyScore = 0;

	public TextMeshProUGUI textPointsPlayer;
	public TextMeshProUGUI textPointsEnemy;

    public int winPoints = 5;

    public GameObject screenEndGame;

	public TextMeshProUGUI textEndGame;

	void Start()
	{
		ResetGame();
	}

	public void ResetGame()
	{
	playerPaddle.position = new Vector3(7f, 0f, 0f);
	enemyPaddle.position = new Vector3(-7f, 0f, 0f);
	ballController.ResetBall();

	playerScore = 0;
	enemyScore = 0;
	textPointsEnemy.text = enemyScore.ToString();
	textPointsPlayer.text = playerScore.ToString();

    screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
		playerScore++;
		textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
		enemyScore++;
		textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
		if (enemyScore >= winPoints || playerScore >= winPoints)
		{
            EndGame();
        }
    }

	public void EndGame()
	{
		ballController.gameObject.SetActive(false);
		screenEndGame.SetActive(true);
		string winner = SaveController.Instance.GetName(playerScore > enemyScore);
		textEndGame.text = "Vitória " + winner;
		SaveController.Instance.SaveWinner(winner);
		Invoke("LoadMenu", 1.5f);
	}

	private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
