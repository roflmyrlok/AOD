namespace Project.View.Objects
{
    using Model.Shapes;
    using UnityEngine;
    
    public abstract class SceneObject : MonoBehaviour
    {

        public abstract bool IsViewFor(Shape shape);
    }

    public abstract class SceneObject<TModel> : SceneObject
        where TModel : Shape
    {
        public override bool IsViewFor(Shape shape) => shape is TModel;
    }

}