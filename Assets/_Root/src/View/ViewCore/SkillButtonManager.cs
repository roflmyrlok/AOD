using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
	public class SkillButtonManager : MonoBehaviour
	{
		public void PutButtonsToTheLayout(Dictionary<Button, GameObject> buttonReturnParentDict)
		{
			foreach (var kvp in buttonReturnParentDict)
			{
				Button button = kvp.Key;
				GameObject originalParent = kvp.Value;

				button.transform.SetParent(this.transform, true); // Temporarily parent to ButtonManager
				button.transform.localPosition = Vector3.zero; // Reset local position for layout
                
				button.gameObject.SetActive(true); // Ensure the button is active
			}

			LayoutRebuilder.ForceRebuildLayoutImmediate(this.GetComponent<RectTransform>());
            
			foreach (var kvp in buttonReturnParentDict)
			{
				Button button = kvp.Key;
				GameObject originalParent = kvp.Value;

				button.transform.SetParent(originalParent.transform, true); // Return to original parent
			}
		}
	}
}