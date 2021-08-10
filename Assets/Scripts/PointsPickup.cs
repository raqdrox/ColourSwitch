using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PointsPickup : ObstacleScript
{
    public UnityEvent OnScoreEvent;
    private bool isenabled=true;
    public override void TriggerObstacle(PlayerController plr)
    {
        if (isenabled)
        {
            enabled = false;
            OnScoreEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
