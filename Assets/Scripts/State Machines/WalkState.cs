public class WalkState : ZombieState
{
    public override void Enter(ZombieController zombie)
    {
        zombie.PlayAnimation("zombie_walk");
    }

    public override void Update(ZombieController zombie)
    {
        zombie.MoveTowardsPlayer(zombie.walkSpeed);

        if (zombie.CloseToPlayer())
            zombie.ChangeState(new RunAttackState());

        else if (!zombie.PlayerInRange())
            zombie.ChangeState(new IdleState());
    }

    public override void Exit(ZombieController zombie) { }
}
