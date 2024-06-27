using UnityEngine;
// Move the enemy
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform targetPosition; // first attack point
    public Transform target;
    public Transform castlePosition; // place to reach to pass intothe castle
    private bool isBeingPushed = false;
    private float pushDuration = 4f;
    private float pushTimer = 0f;
    void Start()
    {
        target = targetPosition; // set the first target
    }

    void Update()
    {
        // check if enemy is pushed by weapon or not
        if (isBeingPushed)
        {
            pushTimer += Time.deltaTime;
            if (pushTimer >= pushDuration)
            {
                isBeingPushed = false;
                pushTimer = 0f;
            }
        }
        else
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            // If close to the target position, set a new target
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                SetNewTargetPosition();
            }
        }
    }
    public void ApplyPush(Vector3 direction, float force, float duration)
    {
        transform.position += direction * force;
        isBeingPushed = true;
        pushDuration = duration;
        pushTimer = 0f;
    }
    void SetNewTargetPosition()
    {
        target = castlePosition;
    }
}
