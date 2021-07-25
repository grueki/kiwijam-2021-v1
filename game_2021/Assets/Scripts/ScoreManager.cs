using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private float PlayerScore;
    public  GameObject DeathMenu;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScore = 0f;
        scoreText = DeathMenu.GetComponent<TextMeshProUGUI>();;
    }

    // Update is called once per frame
    void Update()
    {
        if(!DeathMenu.activeInHierarchy){
            PlayerScore += Time.deltaTime;
        }
        else{
            PlayerScore = (int)PlayerScore;
            scoreText.text = PlayerScore.ToString();
        }
    }
}
