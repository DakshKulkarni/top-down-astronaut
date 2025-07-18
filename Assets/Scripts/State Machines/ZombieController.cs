using UnityEngine;
public class ZombieController : MonoBehaviour
{
    public Transform player;
    public float walkRange = 8f;
    public float attackRange = 2.5f;
    public float walkSpeed = 1.5f;
    public float runSpeed = 3.0f;

    private ZombieState currentState;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeState(new IdleState());
    }

    void Update()
    {
        currentState?.Update(this);
    }

    public void ChangeState(ZombieState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    public void MoveTowardsPlayer(float speed)
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    public bool PlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= walkRange;
    }

    public bool CloseToPlayer()
    {
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }

    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }
}
