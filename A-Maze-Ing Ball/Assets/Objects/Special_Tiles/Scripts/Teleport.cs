using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleport : MonoBehaviour
{
    protected bool canTeleport = true;
    protected bool canHandle   = true;

    [SerializeField] short channel;
    [SerializeField] bool  locked = false;

    public static event Action<Teleport, GameObject, short> OnTeleport;

    Teleport caller;

    private void Start()
    {
        OnTeleport += HandleTeleport;
        Key.OnUnlock += HandleUnlock;
    }

    private void HandleTeleport(Teleport caller, GameObject ball, short channel)
    {
        if(canHandle && channel == this.channel)
        {
            this.caller = caller;
            canTeleport = false;
            ball.transform.position = transform.position;
            
        }
    }

    private void HandleUnlock(short channel)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball") && canTeleport && !locked)
        {
            canHandle = false;
            OnTeleport(this, collision.gameObject, channel);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTeleport = true;
        if(caller != null) caller.canHandle = true;
    }
}
