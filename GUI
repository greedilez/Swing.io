using UnityEngine;
using TMPro;

public class GUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private TextMeshProUGUI winOrLoseText;

    private Animator winOrLoseTextAnimator;

    private Score score;

    private Human human;

    private void Awake(){
        InitializeParameters();
        SubscribeToMoveTextOnLoseOrOnWin();
        ChangeTextOnWinOrOnLose();
    }

    private protected void InitializeParameters(){
        winOrLoseTextAnimator = winOrLoseText.GetComponent<Animator>();
        score = FindObjectOfType<Score>();
        human = FindObjectOfType<Human>();
    }

    private protected void SubscribeToMoveTextOnLoseOrOnWin(){
        human.onHumanLose += () => {
            winOrLoseTextAnimator.SetTrigger("TextMove");
        };

        human.onHumanWin += () => {
            winOrLoseTextAnimator.SetTrigger("TextMove");
        };
    }

    private protected void ChangeTextOnWinOrOnLose(){
        human.onHumanLose += () => {
            winOrLoseText.text = "You lose! Restarting!";
        };

        human.onHumanWin += () =>{
            winOrLoseText.text = "Nice!";
        };
    }

    private void Update(){
        SyncTextWithScore();
    }

    private protected void SyncTextWithScore() => scoreText.text = $"Your score: {score.PlayerScore}";
}
