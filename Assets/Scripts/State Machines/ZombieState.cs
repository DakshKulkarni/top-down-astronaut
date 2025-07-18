public abstract class ZombieState
{
    public abstract void Enter(ZombieController zombie);
    public abstract void Update(ZombieController zombie);
    public abstract void Exit(ZombieController zombie);
}
