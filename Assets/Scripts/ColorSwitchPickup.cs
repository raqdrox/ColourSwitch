using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitchPickup : ObstacleScript
{
    public Colors _col = Colors.Red;

    public override void TriggerObstacle(PlayerController plr)
    {
        plr.SetColor(_col);
        print("set color :"+_col.ToString());
        Destroy(gameObject);
    }
}
