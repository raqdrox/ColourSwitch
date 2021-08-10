using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController plr = collision.gameObject.GetComponent<PlayerController>();
        if (plr != null)
            TriggerObstacle(plr);
    }

    public virtual void TriggerObstacle(PlayerController plr){}
}
