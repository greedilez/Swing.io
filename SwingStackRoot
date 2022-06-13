using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingStackRoot : MonoBehaviour
{
    [SerializeField] private List<SwingRoot> childrenSwings = new List<SwingRoot>();

    private Human human;

    private bool isCloned = false;

    private void Awake() => InitializeParameters();

    private void InitializeParameters(){
        human = FindObjectOfType<Human>();
        isCloned = false;
    }

    private void Update(){
        CloneSwingRootOnFirstPass();
        DestroyOnUnUse();
    }

    private protected void CloneSwingRootOnFirstPass(){
        if(childrenSwings[0].IsPassed){
            if(!isCloned){
                Transform previousHumanParent = human.transform.parent;
                human.transform.parent = null;
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 12f);
                Instantiate(gameObject, spawnPosition, Quaternion.identity);
                isCloned = true;
                human.transform.parent = previousHumanParent;
            }
        }
    }

    private protected void DestroyOnUnUse(){
        if(childrenSwings[0].IsPassed && childrenSwings[1].IsPassed){
            Debug.Log($"Destroying {gameObject.name} by un use");
            Destroy(gameObject, 1f);
        }
    }

    private void OnDestroy() => Debug.Log($"{gameObject.name} was successfully destroyed");
}
