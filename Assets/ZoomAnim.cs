using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoomAnim : MonoBehaviour
{
    public bool enable = true;
    TMP_Text txt;
    public float FontconstraintMin=60f;
    public float FontconstraintMax=80f;
    public float speed = 0.2f;
    float curr_fontsize;
    [SerializeField]private int curr_heading = -1;
    private void Awake()
    {
        txt = GetComponent<TMP_Text>();

    }
    void Update()
    {
        if (enable)
        {
            if (txt.fontSize <= FontconstraintMin)
                curr_heading = 1;
            if (txt.fontSize >= FontconstraintMax)
                curr_heading = -1;
            txt.fontSize += speed * curr_heading;
        }
    }
}
