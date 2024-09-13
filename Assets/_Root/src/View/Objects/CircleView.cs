namespace Project.View.Objects
{
    using Model.Shapes;
    using UnityEngine;

    public class CircleView : SceneObject<Circle>, ICircleView
    {
        public void OnCircleYield()
        {
            Debug.Log("Circle yielded!");
        }

        public void Yield()
        {
            Debug.Log("Circle yielded!");
        }

        public void InitPosition(int position)
        {
            transform.position = Vector3.one * position;
        }
    }

}