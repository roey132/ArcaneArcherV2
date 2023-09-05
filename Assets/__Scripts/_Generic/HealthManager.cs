using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class HealthManager : SerializedMonoBehaviour
{
    [SerializeField] private float _maxHealth;

    [ProgressBar(0, "_maxHealth", ColorGetter = "GetHealthBarColor")]
    [SerializeField] private float _currHealth;

    public event Action OnDeath;
    public event Action OnHealthHeal;
    public event Action OnHealthReduce;

    private Color GetHealthBarColor(float value)
    {
        return Color.Lerp(Color.red, Color.green, Mathf.Pow(value / _maxHealth, 2));
    }

    public float GetCurrHealth()
    {
        return _currHealth;
    }
    public float GetMaxHeath()
    {
        return _maxHealth;
    }

    public void SetCurrHealth(float value)
    {
        _currHealth = value;
    }

    public void SetMaxHealth(float value)
    {
        _maxHealth = value;
    }

    public void IncreaseMaxHealth(float value) 
    {
        _maxHealth += value;
        _currHealth += value;
    }

    public void DecreaseMaxHealth(float value)
    {
        _maxHealth -= value;
        // prevent curr health to be higher than max health
        if (_currHealth < _maxHealth) return;
        _currHealth = _maxHealth;
    }
    private void Update()
    {
    }
    public void ReduceHealth(float value)
    {
        _currHealth -= value;
        OnHealthReduce?.Invoke();

        if (_currHealth > 0) return;
        OnDeath?.Invoke();
    }
    public void HealHealth(float value)
    {
        float tempHealthValue = _currHealth + value;
        _currHealth = Mathf.Clamp(tempHealthValue, 0, _maxHealth);
        OnHealthHeal?.Invoke();
    }

    public void InitHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currHealth = maxHealth;
    }
}
