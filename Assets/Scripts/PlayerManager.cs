using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerManager : MonoBehaviour
{
    private int _index;
    [SerializeField] private SpriteRenderer _player;
    [SerializeField] private List<Color> _indexColor = new List<Color>();
    private int _number;
    [SerializeField] private GameObject _playerPos1;
    [SerializeField] private GameObject _playerPos2;
    [SerializeField] private Button _buttonMovePlayer;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private SfxManager _soundManager;
    private float _speed = 0.1f;

    private void Awake()
    {
        _index = 0;
        _number = PlayerPrefs.GetInt("indexColor");
    }
    private void Start()
    {
        for (int i = 0; i < _indexColor.Count; i++)
        {
            if ((_number - 1) == i)
            {
                _player.color = _indexColor[i];
                break;
            }
        }
    }
    void OnEnable()
    {
        _buttonMovePlayer.onClick.AddListener(MoveTo);
    }
    void OnDisable()
    {
        _buttonMovePlayer.onClick.RemoveListener(MoveTo);
    }
    private void MoveTo()
    {
        _index++;
        _soundManager.PlayEffect();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _gameManager.EndOpen();
        }
        if (other.gameObject.CompareTag("Point"))
        {
            _gameManager.UpScore();
            Destroy(other.gameObject);
        }

    }
    private void Update()
    {
        if (_index != 0)
        {
            if (_index % 2 != 0)
            {
                if (this.transform.position.y > _playerPos2.transform.position.y)
                {
                    this.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y - 1f), this.transform.position.z);
                }
            }
            else
            {
                if (this.transform.position.y < _playerPos1.transform.position.y)
                {
                    this.transform.position = new Vector3(this.transform.position.x, (this.transform.position.y + 1f), this.transform.position.z);
                }
            }
        }
    }
}