using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding
{
    public class SoundMechanism : MonoBehaviour
    {
        bool playerInSoundZone;
        public GameObject Enemy;
        AIDestinationSetter aIDestinationSetter;
        Transform SoundOrigin;
        void Start()
        {
            aIDestinationSetter = Enemy.GetComponent<AIDestinationSetter>();
            SoundOrigin = transform;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1") && playerInSoundZone)
            {
                
                aIDestinationSetter.target =SoundOrigin;
;           }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerInSoundZone = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerInSoundZone = false;
            }
        }
    }
}

