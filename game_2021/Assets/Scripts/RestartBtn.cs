using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour
{
    public GameObject DeathMenu;

    void OnMouseDown(){
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene"); 
        DeathMenu.SetActive(false);
    }
}
