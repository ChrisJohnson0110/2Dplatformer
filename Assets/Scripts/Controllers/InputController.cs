using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : ScriptableObject
{
    public abstract float RetrieveMoveInput();
    public abstract bool RetrieveJumpInput();
    public abstract float RetrieveVerticalInput();
    public abstract int RetrieveArrowKeyLeftRight();
    public abstract bool RetrieveAttackInputOne();
    public abstract bool RetrieveAttackInputTwo();
    public abstract bool RetrieveInteract();


}
