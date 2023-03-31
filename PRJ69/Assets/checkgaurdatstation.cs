using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Pathfinding { 
public class CheckIfGaurdsAtStation : MonoBehaviour
{
    AIDestinationSetter aIDestinationSetter;
    public GameObject Enemy;
    void Start()
    {
        aIDestinationSetter = Enemy.GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
                Debug.Log("IT WRKS");
            aIDestinationSetter.target = null;
        }
    }
}
}

