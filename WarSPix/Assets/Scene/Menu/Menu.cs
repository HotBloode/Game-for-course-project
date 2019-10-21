using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject panel;
    public void  NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void About()
    {
        panel.SetActive(!panel.activeSelf);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
