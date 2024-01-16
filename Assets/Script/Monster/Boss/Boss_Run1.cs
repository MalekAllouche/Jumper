using UnityEngine;

public class Boss_Run1 : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public bool canRun = true;
    private int lastEnrageThreshold;
    private Transform player;
    private Rigidbody2D rb;
    private Boss1 boss;
    private BossHealth1 health;
    private int lastHealthThreshold;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss1>();
        health = animator.GetComponent<BossHealth1>();
        lastHealthThreshold = health.health;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!canRun) return;
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            // Check if health has crossed a threshold since the last update
            if ((lastHealthThreshold > 400 && health.health <= 400) ||
                (lastHealthThreshold > 300 && health.health <= 300) ||
                (lastHealthThreshold > 200 && health.health <= 200) ||
                (lastHealthThreshold > 100 && health.health <= 100))
            {
                animator.SetTrigger("EnAttack");
                lastHealthThreshold = health.health; // Update the last health threshold
            }
            else
            {
                animator.SetTrigger("Attack");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("EnAttack");
        animator.ResetTrigger("Attack");
    }
}
