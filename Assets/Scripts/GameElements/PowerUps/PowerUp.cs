using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public enum PowerUpTypes{Folder, KickMe, Trainee};
    public PowerUpTypes powerUpType;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (!col.gameObject.GetComponent<Animator>().GetBool("Jumping"))
            {
                col.gameObject.GetComponent<PlayerPowerUps>().GetPowerUp(powerUpType);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }        
    }
}
