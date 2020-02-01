using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoundState : FallingState
{
    private bool entered = true;
    public override PlayerState HandleInput(PlayerController p)
    {
        return null;
    }

    public override PlayerState Update(PlayerController p)
    {
        Debug.Log("Ground Pound");
        if (entered)
        {
            entered = false;
            p.body.velocity = new Vector3(0, p.GPSPEED, 0);
        }
        return base.Update(p);
    }
}