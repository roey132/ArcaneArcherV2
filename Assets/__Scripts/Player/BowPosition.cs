using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPosition : MonoBehaviour
{
    public static BowPosition Instance;
    [SerializeField] private Transform _player;
    [SerializeField] private float _radius;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - (Vector2)_player.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = (Vector2)_player.position + direction * _radius;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
