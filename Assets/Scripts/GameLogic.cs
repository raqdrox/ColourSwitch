using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] GameObject _playerSpawn;
    [SerializeField] Colors _playerColor;
    [SerializeField] LevelChanger _lvl;
    [SerializeField] string NextLevel;
    private AudioClip winAudio;
    private AudioClip loseAudio;
    private AudioSource audSrc;

    public GameObject winui;
    public GameObject loseui;
    public TMP_Text scoreui;

    IEnumerator Wait(int time, string lvl = "MainMenu")
    {
        yield return new WaitForSeconds(time);
        _lvl.ChangeLevel(lvl);

    }
    int score=0;
    private void OnEnable()
    {
        foreach (var enemy in GameObject.FindObjectsOfType<EnemyObstacles>())
            enemy.OnKillEvent.AddListener(Lose);
        foreach (var pick in GameObject.FindObjectsOfType<PointsPickup>())
            pick.OnScoreEvent.AddListener(Point);
        GameObject.FindObjectOfType<FinishLine>().OnWinEvent.AddListener(Win);
        score= PlayerPrefs.GetInt("CurrScore",0);

    }
    private void Awake()
    {
        winAudio = Resources.Load<AudioClip>("win");
        loseAudio = Resources.Load<AudioClip>("lose");
        audSrc = GetComponent<AudioSource>();
    }
    void Lose()
    {
        audSrc.PlayOneShot(loseAudio);
        loseui.SetActive(true);
        scoreui.text = "Score : " + score;
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.SetInt("CurrScore", 0);
        StartCoroutine(Wait(3));

    }
    void Win()
    {
        audSrc.PlayOneShot(winAudio);
        winui.SetActive(true);
        PlayerPrefs.SetInt("CurrScore", score);
        StartCoroutine(Wait(3,NextLevel));

    }

    void Point()
    {
        score += 1;
    }
    private void Start()
    {
        var obj=Instantiate(_playerPrefab, _playerSpawn.transform.position,Quaternion.identity);
        obj.GetComponent<PlayerController>().SetColor(_playerColor);
        var cam = Camera.main.gameObject.GetComponent<CameraControl>();
        cam.target = obj.transform;
        cam.enabled = true;
    }


}
