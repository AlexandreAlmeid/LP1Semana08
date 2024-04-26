namespace AnimalKingdom
{
    public class Dog : Animal, IMammal
    {
        public int NumberOfNipples { get{ return 10; } }
        public override string Sound()
        {
            return base.Sound() + "Woof!";
        }
    }
}
