using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int shield;
    public bool gameOver;
    public GameController gameController;
    public GUIText shieldText;


    void Start ()
    {
        shieldText.text = "";
    }

    void Update ()
    {
        UpdateShield();
        if (gameController.shieldScore == 100)
        {
            shield++;
            gameController.shieldScore = 0;
        }
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

    void UpdateShield()
    {
        shieldText.text = "Schildstärke bei " + shield + "0%";
    }
}
