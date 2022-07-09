using UnityEngine;

public class HumanCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform humanTransform;

    private void Update() => FollowHuman(humanTransform);

    private protected void FollowHuman(Transform human){
        Vector3 target = new Vector3(transform.position.x, transform.position.y, humanTransform.position.z - 1.5f);
        transform.position = Vector3.MoveTowards(transform.position, target, 1f);
    }
}
