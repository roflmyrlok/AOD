using UnityEngine;
using UnityEngine.UI;

namespace View
{
	public static class HealthBar
	{
		public static void SetMaxHealth(Slider slider, int value)
		{
			slider.maxValue = value;
		}

		public static void SetCurrentHealth(Slider slider, int value)
		{
			slider.value = value;
		}
	}
}