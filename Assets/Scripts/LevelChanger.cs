using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public void ChangeLevel(string NextLevel)
    {
        SceneManager.LoadScene(NextLevel);
    }

}
