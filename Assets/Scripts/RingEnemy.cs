using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingEnemy : MonoBehaviour
{
    public EnemyType _type;
    public List<EnemyObstacles> Parts;
    public float speed = 1.5f;
    void Update()
    {
        transform.Rotate(0, 0, speed);
    }

}
