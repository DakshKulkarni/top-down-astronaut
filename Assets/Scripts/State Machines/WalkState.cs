public class WalkState : ZombieState
{
    //zombie variable provide with an instance of the zombie controller and all the functions like PlayAnimation
    //and CloseToPlayer 
    public override void Enter(ZombieController zombie)
    {
        zombie.PlayAnimation("zombie_walk");
    }
    //similarly for MoveTowardsPlayer and ChangeState
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
