using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerController", menuName = "InputController/PlayerController")]
public class PlayerController : InputController
{
    public override bool RetrieveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override float RetrieveVerticalInput()
    {
        return Input.GetAxisRaw("Vertical");
    }

    public override int RetrieveArrowKeyLeftRight()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return -1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public override bool RetrieveAttackInputOne()
    {
        return Input.GetMouseButtonDown(0);
    }

    public override bool RetrieveAttackInputTwo()
    {
        return Input.GetMouseButtonDown(1);
    }

    public override bool RetrieveInteract()
    {
        return Input.GetKeyDown(KeyCode.F);
    }
}
