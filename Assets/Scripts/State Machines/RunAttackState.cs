public class RunAttackState : ZombieState
{
    public override void Enter(ZombieController zombie)
    {
        zombie.PlayAnimation("run_attack");  // One animation for both running + attacking
    }

    public override void Update(ZombieController zombie)
    {
        zombie.MoveTowardsPlayer(zombie.runSpeed);

        if (!zombie.CloseToPlayer())
            zombie.ChangeState(new WalkState());
    }

    public override void Exit(ZombieController zombie) { }
}
