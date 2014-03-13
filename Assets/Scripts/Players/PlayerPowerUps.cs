using UnityEngine;
using System.Collections;

public class PlayerPowerUps : MonoBehaviour
{
    
    public int[] powerUps;

    public ParticleSystem paperStorm;
    public float paperStormTimer = 5.0f;
    float paperStormTimerBuffered;

    public KickBlockSpawner kickMe;

    public bool traineeActive = false;
    public float traineeTime = 5.0f;
    float traineeTimeBuffered;
    public float collectRadius;
    Collider2D[] coinsInRange;

    // Use this for initialization
    void Start()
    {
        powerUps = new int[3];

        paperStorm.enableEmission = false;
        paperStormTimerBuffered = paperStormTimer;

        traineeTimeBuffered = traineeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (paperStorm.enableEmission)
        {
            paperStormTimer -= Time.deltaTime;
            if (paperStormTimer <= 0)
            {
                paperStormTimer = paperStormTimerBuffered;
                paperStorm.enableEmission = false;
            }
        }
        if (traineeActive)
        {
            coinsInRange = Physics2D.OverlapCircleAll(transform.position, collectRadius);
            foreach (Collider2D col in coinsInRange)
            {
                if (col.CompareTag("Coin"))
                {
                    col.GetComponent<Coin>().Pull(gameObject);
                }
            }
            traineeTime -= Time.deltaTime;
            if (traineeTime <= 0)
            {
                traineeTime = traineeTimeBuffered;
                traineeActive = false;
            }
        }
    }

    internal void GetPowerUp(PowerUp.PowerUpTypes powerUpType)
    {
        if (powerUpType == PowerUp.PowerUpTypes.Folder && powerUps[0] < 3)
        {
            powerUps[0]++;
            if (powerUps[0] >= 3)
            {
               paperStorm.enableEmission = true;
               print("PAPER STOOOORM");
               powerUps[0] = 0;
            }
        }
        else if (powerUpType == PowerUp.PowerUpTypes.KickMe && powerUps[1] < 3)
        {
            powerUps[1]++;
            if (powerUps[1] >= 3)
            {
                kickMe.activated = true;
                print("KICK MEEE");
                powerUps[1] = 0;
            }
        }
        else if (powerUpType == PowerUp.PowerUpTypes.Trainee && powerUps[2] < 3)
        {
            powerUps[2]++;
            if (powerUps[2] >= 3)
            {                
                print("TRAINEEEE");
                powerUps[2] = 0;
                traineeActive = true;
            }
        }
    }
}
