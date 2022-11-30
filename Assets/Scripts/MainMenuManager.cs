using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text highScore;

    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = LoadScore();
        highScore.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    int LoadScore(){
        int defaultValue = 0;

        if(PlayerPrefs.HasKey("score"))
            return PlayerPrefs.GetInt("score");
        
        defaultValue = PlayerPrefs.GetInt("score");
        return defaultValue;
    }
}
