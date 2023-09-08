using UnityEngine;

public class InteractableTester : Interactable
{
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        
    }

    public override void Interact()
    {
        print(gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        CollidingWithPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        CollidingWithPlayer = false;
    }
}
