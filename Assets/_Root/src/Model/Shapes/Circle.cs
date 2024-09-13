namespace Model.Shapes
{
    using System;

    public class Circle : Shape
    {
        private ICircleView view;

        public event Action OnYield;

        private int position;
        
        //2. interface
        public void InitView(ICircleView view)
        {
            this.view = view;
            view.InitPosition(position);
        }

        public void Yield()
        {
            //1. events
            OnYield?.Invoke();
            
            //2.interface
            view.Yield();   
        }
    }

    public interface ICircleView
    {
        void Yield();
        
        void InitPosition(int position);
    }

    public interface ICreatureView
    {
        void ChangePlace(int position);

        void Damage(int amount, int total);

        void Heal(int amount, int total);
    }
}