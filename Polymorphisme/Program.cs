using Polymorphisme;
using StateMachineNS;
public class Programm
{

    #region cours
    abstract public class AShape
    {
        public abstract float GetAir();

    }

    public class Circle : AShape
    {
        private float m_r;

        public Circle(float a_rayon)
        {
            m_r = a_rayon;
        }



        public override float GetAir()
        {
            return (2 * (float)Math.PI * m_r);
        }

        public void Turn()
        {
            Console.WriteLine("Turn !");
        }

    }

    public class Square : AShape
    {
        private float m_c;

        public Square(float a_side)
        {
            m_c = a_side;
        }

        public override float GetAir()
        {
            return (m_c * m_c);
        }
    }
    public class Triangle : AShape
    {
        private float m_base;
        private float m_height;


        public Triangle(float a_base, float a_height)
        {
            m_base = a_base;
            m_height = a_height;
        }

        public override float GetAir()
        {
            return (m_base * m_height / 2);
        }
    }
    #endregion



    static void Main()
    {
        #region Cours
        AShape circle = new Circle(10);
        AShape square = new Square(10);
        AShape triangle = new Triangle(8, 5);

        //réutilisation spécifique a une classe
        Circle circle2 = (Circle)circle;
      //  circle2.Turn();

        List<AShape> shapes = new List<AShape>();
        shapes.Add(circle);
        shapes.Add(square);
        shapes.Add(triangle);

        foreach (AShape shape in shapes)
        {
            // Console.WriteLine(shape.GetAir());
        }

        #endregion

        #region Exos - Polymorphisme
        AItem potionHealth = new HealthPotion("HealthPotion", 10);
        AItem potionMana = new HealthPotion("ManaPotion", 1);
        AItem Sword = new Sword("Sword");
        AItem Book = new Book("Sword");

        List<AItem> items = new List<AItem>();
        items.Add(potionHealth);
        items.Add(potionMana);
        items.Add(Sword);
        items.Add(Book);
        items.Add(new Sword("Zelda Sword"));


        List<IConsumable> consumables = new List<IConsumable>();

        foreach (AItem item in items)
        {
            if (item is IConsumable consumable)
            {
                // consumables.Add(consumable);
            }
        }

        //Prints 
        foreach (AItem item in items)
        {
            // item.GetName();
            //item.Use();
        }


        foreach (IConsumable consumable in consumables)
        {
         //   consumable.Consume();
        }

        #endregion

        #region Cours - DesignPatern - StateMachine

        StateMachine statemachine = new StateMachine();

        statemachine.HandleRequestStateChangement(new FlyState());
        statemachine.HandleRequestStateChangement(new WalkState());


        while (true)
        {
            statemachine.ProcessUpdate();
            Thread.Sleep(1000);
        }
        #endregion
    }

}