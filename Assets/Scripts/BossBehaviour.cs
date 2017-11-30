using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
	public GameObject shot;
    private GameController gameController;
    public Boundary boundary;
	public Transform bossShotSpawn;
    public int speed;
    public int bossLife;
    public int direction;
	private float Schuss;

	// Use this for initialization
	void Start ()
    {
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
        GetComponent<Rigidbody>().velocity = transform.right * speed;

        if (bossLife == 0)
        {
            Destroy(gameObject);
        }

        Schuss = Random.value;

        if (Schuss < 0.07)
        {
            Instantiate(shot, bossShotSpawn.position, bossShotSpawn.rotation);
        }

        if (gameController.gameOver == true)
        {
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
        }
	}
}
