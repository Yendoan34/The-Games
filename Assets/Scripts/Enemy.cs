using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform targetPosition;
    public Transform target;
    public Transform castlePosition;
    void Start()
    {
        target = targetPosition;
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        // If close to the target position, set a new target
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
        {
            SetNewTargetPosition();
        }
    }

    void SetNewTargetPosition()
    {
        target = castlePosition;
    }
}
