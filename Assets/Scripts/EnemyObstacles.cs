using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyObstacles : ObstacleScript
{
    public Colors _col = Colors.Red;
    SpriteRenderer _spr;

    public UnityEvent OnKillEvent;

    public override void TriggerObstacle(PlayerController plr)
    {
        if (_col != plr._playerCol&& !plr.Dead)
        {

            print("killed : " + plr.ToString());
            plr.Die();

            OnKillEvent.Invoke();
        }
    }
    private void Awake()
    {
        _spr = GetComponent<SpriteRenderer>();
        SetColor(_col);
    }

    public void SetColor(Colors col = Colors.Red)
    {
        _col = col;
        _spr.color = ColorGetter.GetColor(col);
    }
}
