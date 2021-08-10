using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemy : EnemyObstacles
{
    public EnemyType _type;
    public List<EnemyObstacles> Parts;
    public float speed = 1f;
    public float constraintsMin=-2f;
    public float constraintsMax=2f;
    float currposx=0;
    private int curr_heading = -1;

    void Update()
    {
        Vector2 pos= transform.position;
        if(currposx <= constraintsMin)
            curr_heading = 1;
        if(currposx >= constraintsMax)
            curr_heading = -1;
        pos.x += curr_heading * speed * Time.deltaTime;
        currposx += curr_heading * speed * Time.deltaTime;
        transform.position = pos;

    }
}
