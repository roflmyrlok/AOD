using UnityEngine;

namespace View
{
	using UnityEngine;

	public static class PositionalDistribution
	{
		private static Vector2[] screenPositions = new Vector2[8];

		static PositionalDistribution()
		{
			InitializeScreenPositions();
		}

		private static void InitializeScreenPositions()
		{
			// Dividing screen width into 24 parts
			float screenWidth = Screen.width;
			float partWidth = screenWidth / 24f;

			// Assign screen positions based on the mapping provided
			screenPositions[0] = GetMiddlePositionOfParts(4, 5, partWidth); // Position 1 -> parts 4 + 5
			screenPositions[1] = GetMiddlePositionOfParts(6, 7, partWidth); // Position 2 -> parts 6 + 7
			screenPositions[2] = GetMiddlePositionOfParts(8, 9, partWidth); // Position 3 -> parts 8 + 9
			screenPositions[3] = GetMiddlePositionOfParts(10, 11, partWidth); // Position 4 -> parts 10 + 11
			screenPositions[4] = GetMiddlePositionOfParts(14, 15, partWidth); // Position 5 -> parts 13 + 14
			screenPositions[5] = GetMiddlePositionOfParts(16, 17, partWidth); // Position 6 -> parts 15 + 16
			screenPositions[6] = GetMiddlePositionOfParts(18, 19, partWidth); // Position 7 -> parts 17 + 18
			screenPositions[7] = GetMiddlePositionOfParts(20, 21, partWidth); // Position 8 -> parts 20 + 21
		}

		private static Vector2 GetMiddlePositionOfParts(int part1, int part2, float partWidth)
		{
			// Calculate the middle point between two screen parts
			float xPosition = (part1 + part2) / 2f * partWidth;
			return new Vector2(xPosition, Screen.height / 2); // Assuming centered vertically
		}

		public static void MoveCharacterToPosition(Transform characterTransform, int position, Canvas canvas)
		{
			if (position < 1 || position > 8)
			{
				Debug.LogError("Invalid position. Must be between 1 and 8.");
				return;
			}

			// Get the target screen position
			Vector2 targetScreenPosition = screenPositions[position - 1]; // Subtract 1 because array is 0-indexed

			// Convert screen position to world position for canvas UI
			Vector3 worldPosition = canvas.worldCamera.ScreenToWorldPoint(new Vector3(targetScreenPosition.x,
				targetScreenPosition.y, canvas.planeDistance));

			// Move the character's transform to the new position
			characterTransform.position = new Vector3(worldPosition.x, worldPosition.y, characterTransform.position.z);
		}
	}
}