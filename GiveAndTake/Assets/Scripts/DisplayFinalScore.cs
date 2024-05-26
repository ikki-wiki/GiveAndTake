using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
    public Text finalScoreText;

    private void Start()
    {
        bool isScoreEnabled = PlayerPrefs.GetInt("ScoreEnabled", 1) == 1;
        bool isTimeEnabled = PlayerPrefs.GetInt("TimeEnabled", 1) == 1;
        if(isScoreEnabled && isTimeEnabled){
            finalScoreText.text = "Fizeste um total de " + (int) PlayerProfile.currentProfile.score + " pontos neste nível!";
        } else {
            finalScoreText.text = "Completaste o nível!";
        }
    }
}