using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinController : MonoBehaviour
{
    [SerializeField] private Button _buttonSkinRed, _buttonSkinBlue, _buttonSkinCyan, _buttonSkinGreen, _buttonSkinMagenta, _buttonSkinYellow;
    [SerializeField] private Image _player;
    [SerializeField] private Color _color;
    private void Start()
    {

    }
    private void OnEnable()
    {
        _buttonSkinRed.onClick.AddListener(SelectSkinRed);
        _buttonSkinBlue.onClick.AddListener(SelectSkinBlue);
        _buttonSkinCyan.onClick.AddListener(SelectSkinCyan);

        _buttonSkinGreen.onClick.AddListener(SelectSkinGreen);
        _buttonSkinMagenta.onClick.AddListener(SelectSkinMagenta);
        _buttonSkinYellow.onClick.AddListener(SelectSkinYellow);

    }
    public void SelectSkinRed()
    {
        _player.color = Color.red;
        PlayerPrefs.SetInt("indexColor", 1);
    }
    public void SelectSkinBlue()
    {
        _player.color = Color.blue;
        PlayerPrefs.SetInt("indexColor", 2);
    }
    public void SelectSkinCyan()
    {
        _player.color = Color.cyan;
        PlayerPrefs.SetInt("indexColor", 3);
    }
    public void SelectSkinGreen()
    {
        _player.color = Color.green;
        PlayerPrefs.SetInt("indexColor", 4);
    }
    public void SelectSkinMagenta()
    {
        _player.color = Color.magenta;
        PlayerPrefs.SetInt("indexColor", 5);
    }
    public void SelectSkinYellow()
    {
        _player.color = Color.yellow;
        PlayerPrefs.SetInt("indexColor", 6);
    }

}
