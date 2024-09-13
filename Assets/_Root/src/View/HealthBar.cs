using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHealth(int value)
        {
            slider.maxValue = value;
        }
    
        public void SetCurrentHealth(int value)
        {
            slider.value = value;
        }
    }
}
