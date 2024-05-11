using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
    public Text finalScoreText;

    private void Start()
    {
        bool isScoreEnabled = PlayerPrefs.GetInt("ScoreEnabled", 1) == 1;
        if(isScoreEnabled){
            finalScoreText.text = (int) PlayerProfile.currentProfile.score + " pontos!";
        } else {
            finalScoreText.text = "Completaste o nível!";
        }
    }
}