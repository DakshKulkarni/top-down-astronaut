public class IdleState : ZombieState
{
    public override void Enter(ZombieController zombie)
    {
        zombie.PlayAnimation("idle");//if not yet spotted the player, it will be in the idle state 
    }

    public override void Update(ZombieController zombie)
    {
        if (zombie.PlayerInRange())
            zombie.ChangeState(new WalkState());
    }

    public override void Exit(ZombieController zombie) { }
}
