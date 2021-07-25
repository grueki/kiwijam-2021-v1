using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtn : MonoBehaviour
{
    void OnMouseDown(){
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
    }
}
