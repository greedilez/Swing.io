using UnityEngine;

public class Score : MonoBehaviour
{
    private Human human;

    private int score = 0;

    public int PlayerScore{ get => score; }

    private void Awake(){
        InitializeParameters();
        SubscribeToChangeScoreOnWin();
    }

    private protected void InitializeParameters(){
        LoadToIntFromPP();
        human = FindObjectOfType<Human>();
    }

    private protected void SubscribeToChangeScoreOnWin(){
        human.onHumanWin += () => {
            score++;
            SaveToPP();
        };
    }

    private void SaveToPP() => PlayerPrefs.SetInt("Score", score);

    private void LoadToIntFromPP() => score = PlayerPrefs.GetInt("Score", 0);
}
