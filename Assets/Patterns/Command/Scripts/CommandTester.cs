using JetBrains.Annotations;
using UnityEngine;

public class CommandTester : MonoBehaviour
{
    [SerializeField] PlayerMover playerMover;


 

    private void Update()
    {
        HandleMove();
    }

    public void HandleMove()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ICommand command = new MoveCommand(playerMover, new Vector3(0,0,1));
            CommandExecute.ExecuteCommand(command);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ICommand command = new MoveCommand(playerMover, new Vector3(0, 0, -1));
            CommandExecute.ExecuteCommand(command);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ICommand command = new MoveCommand(playerMover, new Vector3(-1, 0, 0));
            CommandExecute.ExecuteCommand(command);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ICommand command = new MoveCommand(playerMover, new Vector3(1, 0, 0));
            CommandExecute.ExecuteCommand(command);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
           CommandExecute.UndoCommand();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CommandExecute.RedoCommand();
        }

    }
}