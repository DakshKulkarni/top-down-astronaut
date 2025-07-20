public abstract class ZombieState
{
    // this is the base class where every state will derive these functions 
    public abstract void Enter(ZombieController zombie);
    public abstract void Update(ZombieController zombie);
    public abstract void Exit(ZombieController zombie);
}
