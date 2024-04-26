namespace AnimalKingdom
{
    public class Bat : Animal, IMammal, ICanFly
    {
        public int NumberOfNipples { get{ return 4; } }
        public int NumberOfWings { get{ return 2; } }
        public override string Sound()
        {
            return base.Sound() + "Tee tee tee tee tee";
        }
    }
}
