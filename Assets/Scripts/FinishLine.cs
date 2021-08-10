using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLine : ObstacleScript
{
    public UnityEvent OnWinEvent;
    public override void TriggerObstacle(PlayerController plr)
    {
        if (plr.Dead)
            return;
        plr.Die();
        OnWinEvent.Invoke();
        print("win");
    }
}
