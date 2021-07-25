using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    void OnMouseDown(){
        GetComponentInParent<MenuController>().QuitGame();
    }

}
