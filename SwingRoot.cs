using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwingRoot : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private Transform sitPosition;

    public Transform SitPosition{ get => sitPosition; }
    
    [SerializeField] private bool isPassed = false;

    public bool IsPassed{ get => isPassed; set => isPassed = value; }

    private void Awake(){
        InitializeParameters();
        MoveSwingWithRandomInterval();
    }

    private protected void InitializeParameters(){
        isPassed = false;
        animator = GetComponent<Animator>();
    }

    private protected void MoveSwingWithRandomInterval(){
        if(!isPassed){
            animator.SetTrigger("MoveSwing");
        }
        StartCoroutine(IntervalBetweenMove());
    }

    private protected IEnumerator IntervalBetweenMove(){
        yield return new WaitForSeconds(Random.Range(2.5f, 6f));{
            MoveSwingWithRandomInterval();
        }
    }
}
