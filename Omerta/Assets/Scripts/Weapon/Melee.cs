using System.Threading.Tasks;

namespace Weapon
{
    public class Melee : Weapon
    {
        public int Damage { get; protected set; }
        public int TimeBetweenHits { get; private set; }

        public void Hit()
        {
            Task.Delay(TimeBetweenHits);
        }
    }
}