using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptMenu : MonoBehaviour
{
    public GameObject panelKonfirmasi;
    public GameObject panelAbout;
    public GameObject panelOption;
    public GameObject panelWin;
    public void exit()
    {
        Application.Quit();
        Debug.Log("Keluar...");
    }
    public void play(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

    public void KonfirmasiClicked()
    {
        panelKonfirmasi.SetActive(true);
        panelAbout.SetActive(false);
        panelOption.SetActive(false);
        panelWin.SetActive(false);

    }

    public void AboutClicked()
    {
        panelAbout.SetActive(true);
        panelKonfirmasi.SetActive(false);
        panelOption.SetActive(false);
        panelWin.SetActive(false);

    }

    public void OptionClicked()
    {
        panelOption.SetActive(true);
        panelAbout.SetActive(false);
        panelKonfirmasi.SetActive(false);
        panelWin.SetActive(false);

    }

    public void Kembali()
    {
        panelKonfirmasi.SetActive(false);
        panelAbout.SetActive(false);
        panelOption.SetActive(false);
        panelWin.SetActive(false);
    }

    public void Win()
    {
        panelKonfirmasi.SetActive(false);
        panelAbout.SetActive(false);
        panelOption.SetActive(false);
        panelWin.SetActive(true);
    }
}
