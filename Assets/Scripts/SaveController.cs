using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
	public Color colorEnemyStart;
	public Color colorPlayerStart;

	public Color colorEnemy;
	public Color colorPlayer;

    private static SaveController _instance;

	public string namePlayer;
	public string nameEnemy;

	private string saveWinnerkey = "SavedWinner";

	public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveController>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

	public string GetName(bool isPlayer)
	{
		return isPlayer ? namePlayer : nameEnemy;
	}

	public void Reset()
	{
		nameEnemy = "";
		namePlayer = "";
		colorEnemy = colorEnemyStart;
		colorPlayer = colorPlayerStart;
	}

	public void SaveWinner(string winner)
	{
		PlayerPrefs.SetString(saveWinnerkey, winner);
	}
	public string GetLastWinner()
	{
		return PlayerPrefs.GetString(saveWinnerkey);
	}

	public void ClearSave()
	{
		PlayerPrefs.DeleteAll();
		Instance.Reset();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
