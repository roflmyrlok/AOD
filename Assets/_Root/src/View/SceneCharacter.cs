using Model;
using UnityEngine;

namespace View
{
	public abstract class SceneCharacter : MonoBehaviour
	{ 
		public abstract bool IsViewFor(Character shape);
	}
	
	public abstract class SceneCharacter<TModel> : SceneCharacter
		where TModel : Character
	{
		public override bool IsViewFor(Character shape) => shape is TModel;
	}
}