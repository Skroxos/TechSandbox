using UnityEngine;

public class MoveCommand : ICommand
{
    PlayerMover playerMover;
    Vector3 dir;

    public MoveCommand(PlayerMover playerMover, Vector3 dir)
    {
        this.playerMover = playerMover;
        this.dir = dir;
    }

    public void Execute()
    {
        playerMover.Move (dir);
    }

    public void Undo()
    {
        playerMover.Move(-dir);
    }
}
