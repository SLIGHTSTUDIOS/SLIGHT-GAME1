using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    Vector2 direction;
    // Update is called once per frame
    void Update()
    {
        faceVelocity();

    }

    void faceVelocity()
    {
        direction = aiPath.desiredVelocity;
        transform.right = direction;
    }
}

