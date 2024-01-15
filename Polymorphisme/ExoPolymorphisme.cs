using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphisme
{
    abstract public class AItem 
    {
        public string Name { get; protected set; }

        abstract public void Use();

        public virtual void Drop()
        {
            Console.WriteLine("Drop Item");
        }

        public string GetName() 
        {
            return Name; 
        }

        public AItem(string a_name)
        {
            Name =a_name ;
        }

    }

    public class HealthPotion : AItem, IConsumable
    {
        int m_quantity;
        public HealthPotion(string a_name, int a_quantity) : base(a_name)
        {
            this.m_quantity = a_quantity;
        }

        public void Consume()
        {
            Console.WriteLine($"{Name} Consume");
        }

        public override void Drop()
        {
            Console.WriteLine("Drop Potion");
        }

        public override void Use()
        {
            Console.WriteLine($"{Name} Use");
        }
    }

    public class Sword : AItem
    {
        public Sword(string a_name) : base(a_name)
        {
        }

        public override void Use()
        {
            Console.WriteLine("Sword Attack");
        }

        public override void Drop()
        {
            Console.WriteLine("Drop Sword");
        }
    }

    public class Book : AItem
    {
        public Book(string a_name) : base(a_name)
        {
        }

        public override void Use()
        {
            Console.WriteLine("Read Book");
        }

        public override void Drop()
        {
            base.Drop();    
        }
    }

    interface IConsumable
    {
        public void Consume();
    }
}
