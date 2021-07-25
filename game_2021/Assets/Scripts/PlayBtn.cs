using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtn : MonoBehaviour
{
    void OnMouseDown(){
        GetComponentInParent<MenuController>().PlayGame();
    }

}
