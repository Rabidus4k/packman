using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private Image _image;

    private int _maxHealth = 3;

    public void SetMaxHealth(int health)
    {
        _maxHealth = health;
    }
    
    public void SetHealth(int value)
    {
        _image.fillAmount = (float)value / _maxHealth;
    }
}
