using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{
    public class SoundMechanism : MonoBehaviour
    {
        bool playerInSoundZone;
        bool enemyAtSoundZone;
        public GameObject Enemy;
        AIDestinationSetter aIDestinationSetter;
        Transform SoundOrigin;

       //how long a guard waits to see why the sound hapened
        float timeCountdown = 0f;
        float TimeLeft = 3f;
        void Start()
        {
            aIDestinationSetter = Enemy.GetComponent<AIDestinationSetter>();
            aIDestinationSetter.target = null;
            SoundOrigin = transform;
            timeCountdown = TimeLeft;
        }

        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetButtonDown("Jump") && playerInSoundZone)
            {
                aIDestinationSetter.target =transform;
;           }
            if (enemyAtSoundZone)
            {
                timeCountdown -= 1 * Time.deltaTime;
                print(timeCountdown);
            }
            if (timeCountdown <= 0 && enemyAtSoundZone)
            {
                aIDestinationSetter.target = aIDestinationSetter.gaurdStation;
                enemyAtSoundZone = false;
            }
            if(Enemy.transform.position == SoundOrigin.position)
            {
                aIDestinationSetter.target = null;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerInSoundZone = false;
            }
            if (collision.gameObject.tag == "Enemy")
            {
                enemyAtSoundZone = false;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            string objecttag = collision.gameObject.tag;
            Debug.Log(objecttag);
            if (collision.gameObject.tag == "Player")
            {
                playerInSoundZone = true;
            }
            if (collision.gameObject.tag == "Enemy")
            {
                enemyAtSoundZone = true;
            }

        }
    }
}

