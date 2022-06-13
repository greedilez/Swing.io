using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Update(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            GetTapToStart(touch);
        }
    }

    private void GetTapToStart(Touch touch){
        if(touch.phase == TouchPhase.Began) LoadGame();
    }

    private void LoadGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
