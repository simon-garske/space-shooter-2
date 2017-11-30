using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int shield;
    public bool gameOver;
    public GameController gameController;


    void Start ()
    {
    }

    void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossShot")
        {
            if (shield == 0)
            {
                gameController.GameOver();
                Destroy(gameObject);
            }
            shield--;

        }
    }
}
