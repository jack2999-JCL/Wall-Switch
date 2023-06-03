using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _buttonBack;
    [SerializeField] private Button _buttonReset;
    [SerializeField] private Button _buttonMenu;
    [SerializeField] private Image _popUpEnd;
    [SerializeField] public GameObject _objectGame;
    [SerializeField] private List<GameObject> _posSpawn = new List<GameObject>();
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private EnemyController _pointPrefab;
    [SerializeField] private GameObject _tutorial;
    [SerializeField] private TextMeshProUGUI CurrentScore;
    [SerializeField] private TextMeshProUGUI CurrentScoreEnd;
    private int _score;
    private int _scorePoint;
    private int _index;
    private float _timeDelayCurrent;
    private float _timeDelay;

    private IEnumerator Start()
    {
        _score = 0;
        _index = 0;
        _scorePoint = 1;
        _timeDelay = 6f;
        _tutorial.gameObject.SetActive(true);
        yield return new WaitForSeconds(7);
        StartCoroutine(StartSpawn());
        _tutorial.gameObject.SetActive(false);

    }

    IEnumerator StartSpawn()
    {
        _timeDelayCurrent = _timeDelay;
        GameObject go = _enemyPrefab.gameObject;
        if ((_score > _scorePoint) && (_timeDelay > 2))
        {
            _enemyPrefab.Speed += 1f;
            _pointPrefab.Speed += 1f;
            _scorePoint += 1;
            _timeDelay -= 0.1f;
        }
        _index++;
        if (_index == 4)
        {
            go = _pointPrefab.gameObject;
            _index = 0;
            _timeDelay -= 2f;
        }
        int number = Random.Range(0, _posSpawn.Count);
        GameObject item = Instantiate(go, _posSpawn[_index].transform.position, Quaternion.identity, _objectGame.transform);
        yield return new WaitForSeconds(_timeDelay);
        StartCoroutine(StartSpawn());
    }
    void OnEnable()
    {
        _buttonBack.onClick.AddListener(EndOpen);
        _buttonReset.onClick.AddListener(Reset);
        _buttonMenu.onClick.AddListener(Menu);
    }
    public void EndOpen()
    {
        _popUpEnd.gameObject.SetActive(true);
        _objectGame.gameObject.SetActive(false);
    }
    private void Reset()
    {
        SceneManager.LoadScene("PlayGame");
    }
    private void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void UpScore()
    {
        _score++;
    }
    void Update()
    {
        CurrentScore.text = _score.ToString();
        CurrentScoreEnd.text = PlayerPrefs.GetInt("HighestScore").ToString();
        if (_score > PlayerPrefs.GetInt("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", _score);
        }
    }

}
