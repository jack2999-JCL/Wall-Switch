using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonSettingOpen;
    [SerializeField] private Button _buttonStoreOpen;
    [SerializeField] private Button _buttonSettingClose;
    [SerializeField] private Button _buttonStoreClose;
    [SerializeField] private Image _popUpSetting;
    [SerializeField] private Image _popUpStore;

    void OnEnable()
    {
        _buttonPlay.onClick.AddListener(PlaySceneGame);
        _buttonSettingOpen.onClick.AddListener(PopupSettingOpen);
        _buttonStoreOpen.onClick.AddListener(PopupStoreOpen);
        _buttonSettingClose.onClick.AddListener(PopupSettingClose);
        _buttonStoreClose.onClick.AddListener(PopupStoreClose);

    }
    public void PlaySceneGame()
    {
        SceneManager.LoadScene("PlayGame");
    }
    public void PopupSettingOpen()
    {
        _popUpSetting.gameObject.SetActive(true);
    }
    public void PopupStoreOpen()
    {
        _popUpStore.gameObject.SetActive(true);
    }
    public void PopupSettingClose()
    {
        _popUpSetting.gameObject.SetActive(false);
    }
    public void PopupStoreClose()
    {
        _popUpStore.gameObject.SetActive(false);
    }
    public void ResetData()
    {
        PlayerPrefs.SetInt("HighestScore", 0);
        PlayerPrefs.SetInt("indexColor",1);
        PlayerPrefs.SetInt("muted", 1);
    }
}
