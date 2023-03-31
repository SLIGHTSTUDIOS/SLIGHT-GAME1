using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{ 
public class KillingMechanism : MonoBehaviour
{
        AIDestinationSetter aIDestinationSetter;
    bool playerInKillZone;
    GameObject enemy;
    /*countdown variables.time till player dies afer he is exposed to gaurds.he can avoid this 
     by killing them before tim runs out*/
    float timeCountdown = 0f;
    float TimeLeft = 3f;
    bool enemyAlerted;
    void Start()
    {
        timeCountdown = TimeLeft;
            
    }

   
    void Update()
    {
            
        if (Input.GetButtonDown("Fire1") && playerInKillZone)
        {
            Debug.Log("killed");
            enemyAlerted = false;
            Destroy(enemy);
        }
        if(enemyAlerted == true)
        {
                  
            timeCountdown -= 1 * Time.deltaTime;
            print(timeCountdown);
            
        }
        if(timeCountdown <= 0 )
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("enemy alerted");
            enemyAlerted = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyVeiwArea")
        {
            Debug.Log("enemy alerted");
            enemyAlerted = true;
            enemy = collision.gameObject;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            playerInKillZone = true;
            enemy = collision.gameObject;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerInKillZone = false;
        }
    }

}
}
