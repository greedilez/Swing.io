using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Human : MonoBehaviour
{
    private bool canSeatToNextSwing = false;

    private bool isFalledDown = false;

    public bool IsFalledDown{ get => isFalledDown; }

    private Collider nextSwingCollider = null;

    private Animator animator;

    private AudioSource source;

    [SerializeField] private AudioClip sitToNextSound, fallSound;

    public delegate void methodContainer();

    public event methodContainer onHumanWin, onHumanLose;

    private void Start(){
        InitializeParameters();
        SitDownToFirstSwing();
    }

    private protected void InitializeParameters(){
        source = GetComponent<AudioSource>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private protected void SitDownToFirstSwing(){
        SwingRoot[] swingsOnScene = FindObjectsOfType<SwingRoot>();
        transform.parent = swingsOnScene[1].transform; // 1 cuz it's inversed
        transform.position = swingsOnScene[1].SitPosition.position;
    }

    private void Update(){
        SyncRotationWithParent();
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            SitToNextOrFallByTouch(touch);
        }
    }

    private protected void SyncRotationWithParent(){
        if(transform.parent != null){
            transform.localRotation = Quaternion.Euler(-transform.parent.localRotation.x, 0, 0);
        }
    }

    private protected void SitToNextOrFallByTouch(Touch touch){
        if(touch.phase == TouchPhase.Began){
            if(canSeatToNextSwing && !nextSwingCollider.GetComponent<SwingRoot>().IsPassed && !isFalledDown){
                SitToNextSwing(nextSwingCollider.GetComponent<SwingRoot>());
                Debug.Log("Sit to next swing (win)");
            }
            else{
                FallToFloor();
                Debug.Log("Fall (lose)");
            }
        }
    }

    private protected void SitToNextSwing(SwingRoot swingRoot){
        source.PlayOneShot(sitToNextSound);
        transform.parent.GetComponent<SwingRoot>().IsPassed = true;
        transform.parent = swingRoot.transform;
        transform.position = swingRoot.SitPosition.position;
        onHumanWin();
    }

    private protected void FallToFloor(){
        if(!isFalledDown){
            MoveToFalledPosition(1);
            animator.SetBool("Fall", true);
            source.PlayOneShot(fallSound);
            isFalledDown = true;
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            onHumanLose();
        }
    }

    private protected void MoveToFalledPosition(int fallForce){
        Vector3 targetPosition = new Vector3(transform.position.x, 0.75f, transform.position.z + fallForce);
        transform.position = targetPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnTriggerStay(Collider col){
        if(col.gameObject != transform.parent.gameObject){
            if(col.tag == "SwingRoot"){
                nextSwingCollider = col;
                canSeatToNextSwing = true;
            }
        }
    }

    private void OnTriggerExit(Collider col){
        if(col.gameObject != transform.parent.gameObject){
            if(col.tag == "SwingRoot"){
                nextSwingCollider = null;
                canSeatToNextSwing = false;
            }
        }
    }
}
