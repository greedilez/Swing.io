using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover : MonoBehaviour
{
    private Human human;

    private void Awake(){
        InitializeParameters();
        SubscribeToRestartOnLose();
    }

    private protected void InitializeParameters(){
        human = FindObjectOfType<Human>();
    }

    private protected void SubscribeToRestartOnLose(){
        human.onHumanLose += () => {
            StartCoroutine(SceneRestartDelay());
        };
    }

    private protected IEnumerator SceneRestartDelay(){
        yield return new WaitForSeconds(2f);{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
