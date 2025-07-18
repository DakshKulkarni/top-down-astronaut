public class IdleState : ZombieState
{
    public override void Enter(ZombieController zombie)
    {
        zombie.PlayAnimation("Idle");
    }

    public override void Update(ZombieController zombie)
    {
        if (zombie.PlayerInRange())
            zombie.ChangeState(new WalkState());
    }

    public override void Exit(ZombieController zombie) { }
}
