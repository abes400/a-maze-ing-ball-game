using UnityEngine;
using System;

public class Teleport : MonoBehaviour
{
    [Header("-----    Teleport Settings   -----")]
    [SerializeField] short channel;
    [SerializeField] bool locked = false;

    [Header("")]
    [SerializeField] Sprite LockSprite;
    [SerializeField] Sprite UnlockSprite;
    private SpriteRenderer spriteRenderer;

    protected bool canTeleport = true;
    protected bool canHandle = true;

    public static event Action<Teleport, GameObject, short> OnTeleport;

    Teleport caller;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = locked ? LockSprite : UnlockSprite;
    }

    private void OnEnable()
    {
        OnTeleport += HandleTeleport;
        Key.OnUnlock += HandleUnlock;
    }

    private void OnDisable()
    {
        OnTeleport -= HandleTeleport;
        Key.OnUnlock -= HandleUnlock;
    }

    private void HandleTeleport(Teleport caller, GameObject ball, short channel)
    {
        if (canHandle && channel == this.channel)
        {
            this.caller = caller;
            canTeleport = false;
            ball.transform.position = transform.position;
            AudioManager.PlaySound?.Invoke(AudioManager.SFXName.TELEPORT);

        }
    }

    private void HandleUnlock(short channel)
    {
        if (channel == this.channel)
        {
            locked = false;
            spriteRenderer.sprite = UnlockSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball") && canTeleport && !locked)
        {
            canHandle = false;
            OnTeleport?.Invoke(this, collision.gameObject, channel);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTeleport = true;
        if (caller != null) caller.canHandle = true;
    }
}
