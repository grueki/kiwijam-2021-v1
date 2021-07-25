using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    void OnMouseDown(){
        GetComponentInParent<MenuController>().PlayGame();
    }

}
