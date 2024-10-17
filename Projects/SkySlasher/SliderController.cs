using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private void Start()
    {
        _health = FindObjectOfType<Health>();
    }

    private void Update()
    {
        _slider.value = _health._health / _health.MaxHealth;
    }

   
}