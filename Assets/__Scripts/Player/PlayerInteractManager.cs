using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractManager : MonoBehaviour
{
    [SerializeField] private List<Collider2D> _colliders;
    [SerializeField] private string _interactableLayerMask;
    [SerializeField] private Collider2D _closestCollider;
    private void OnEnable()
    {
        _colliders = new List<Collider2D>();
        PlayerInputsManager.OnInteractInput += OnInteractInput;
    }

    private void Update()
    {
        _closestCollider = GetClosestCollider();
    }

    private void OnInteractInput()
    {
        if (_closestCollider == null) return;
        _closestCollider.GetComponent<Interactable>().Interact();
    }
    private Collider2D GetClosestCollider()
    {
        float minDistance = 9999f;
        Collider2D closest = null;
        foreach (Collider2D collider in _colliders) 
        {
            float distance = (collider.transform.position - transform.position).magnitude;
            float absDistance = Mathf.Abs((collider.transform.position - transform.position).magnitude);
            if (absDistance < minDistance)
            {
                closest = collider;
                minDistance = absDistance;
            }
        }
        print(closest);
        return closest;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer(_interactableLayerMask)) return;
        print($"enter collision with {collision.gameObject.name}");
        _colliders.Add(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer(_interactableLayerMask)) return;
        print($"exit collision with {collision.gameObject.name}");
        _colliders.Remove(collision);
    }
}
