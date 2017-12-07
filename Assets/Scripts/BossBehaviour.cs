using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
	public GameObject shot;
    public GameObject explosion;
    private GameController gameController;
    public Boundary boundary;
	public Transform bossShotSpawn;
    public int speed;
    public int bossLife;
    public int direction;
	private float Schuss;
    public GUIText bossLifeText;

	// Use this for initialization
	void Start ()
    {
        GameObject Life = GameObject.FindWithTag("BossLife");
        if (Life != null)
        {
            bossLifeText = Life.GetComponent<GUIText>();
        }
        bossLifeText.text = "";

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
        GetComponent<Rigidbody>().velocity = transform.right * speed;

        if (bossLife == 0)
        {
            Destroy(gameObject);
            gameController.AddScore(250);
            gameController.bossFight = false;
            gameController.waveCounter++;
        }

       
        
            Schuss = Random.value;

            if (Schuss < 0.07)
            {
                Instantiate(shot, bossShotSpawn.position, bossShotSpawn.rotation);
            }
        

        if (gameController.gameOver == true)
        {
            bossLifeText.text = "";
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other )
	{
		if (other.tag == "BossBoundary") 
		{
			speed *= -1;
		}

        if (other.tag == "Shot")
        {
            bossLife--;
            Instantiate(explosion, transform.position, transform.rotation);
        }
	}

    void UpdateLife()
    {
        if (gameController.bossFight == true)
        {
            bossLifeText.text = "HP: " + bossLife;
        }
    }
}