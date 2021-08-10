using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuScript : MonoBehaviour
{
    public int score;
    public TMP_Text scoreUI;
    public AudioSource aud;
    public LevelChanger lvl;
    public ZoomAnim anim;
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        lvl.ChangeLevel("Level1");
    }
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        foreach(GameObject obj in objs)
            Destroy(obj);
    }
    private void Start()
    {
        score = PlayerPrefs.GetInt("LastScore",0);
        scoreUI.text = "Last Score : " + score;
    }
    public void exit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        aud.Play();
        anim.enable = false;
        StartCoroutine(Wait());
    }
}
