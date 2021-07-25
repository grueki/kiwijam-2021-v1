using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject PauseMenu;

    void Start(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    
    void OnMouseDown(){
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
}
