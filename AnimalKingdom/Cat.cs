namespace AnimalKingdom
{
    public class Cat : Animal, IMammal
    {
        public int NumberOfNipples { get{ return 8; } }
        public override string Sound()
        {
            return base.Sound() + "Miau";
        }
    }
}
