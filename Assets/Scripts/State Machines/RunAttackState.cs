public class RunAttackState : ZombieState
{
    public override void Enter(ZombieController zombie)
    {
        zombie.PlayAnimation("run_attack");  //zombie will start running behind the player if it is within that range
    }

    public override void Update(ZombieController zombie)
    {
        zombie.MoveTowardsPlayer(zombie.runSpeed);

        if (!zombie.CloseToPlayer())
            zombie.ChangeState(new WalkState());
    }

    public override void Exit(ZombieController zombie) { }
}
