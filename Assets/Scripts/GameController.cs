using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public GameObject boss;
	public Vector3 spawnValues;
	public int hazardCount;
	public int shield;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Vector3 bossSpawnValues;
	public Quaternion bossSpawnRotation;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText shieldText;

	public bool gameOver;
	private bool restart;
    public bool bossFight;
    private int score;
	private int waveCounter;


	void Start ()
	{
		gameOver = false;
		restart = false;
        bossFight = false;
		restartText.text = "";
		gameOverText.text = "";	
		shieldText.text = "";
		score = 0;
        waveCounter = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves());

	}

	void Update ()
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}

	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			if (bossFight == false && waveCounter == 0 ) 
			{
				Vector3 bossSpawnPosition = new Vector3 (bossSpawnValues.x, bossSpawnValues.y, bossSpawnValues.z);
				Quaternion bossSpawnRotation = new Quaternion(0,180,0,0);
				Instantiate (boss, bossSpawnPosition, bossSpawnRotation);
                bossFight = true;
			}
            if (waveCounter != 10 && bossFight == false)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                    waveCounter++;

                }
             }
            yield return new WaitForSeconds (waveWait);


		

			if (gameOver) 
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}


}