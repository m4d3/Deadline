using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public enum PowerUpTypes{Folder, KickMe, Trainee};
    public PowerUpTypes powerUpType;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player")) {
            col.gameObject.GetComponent<PlayerPowerUps>().GetPowerUp(powerUpType);
        }
        Destroy(gameObject);
    }
}
