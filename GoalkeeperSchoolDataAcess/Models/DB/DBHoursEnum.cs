using System.ComponentModel.DataAnnotations;
using GoalkeeperSchoolDataAcess.Models.Core;

namespace GoalkeeperSchoolDataAcess.Models
{
    public class DBHoursEnum : BaseModel
    {
        [Required]   public bool One { get; set; }
        [Required]public bool Two { get; set; }
        [Required] public bool Three { get; set; }
        [Required]public bool Four { get; set; }
        [Required]public bool Five { get; set; }
        [Required] public bool Six { get; set; }
        [Required] public bool Seven { get; set; }
        [Required] public bool Eight { get; set; }
        [Required] public bool Nine { get; set; }
        [Required]  public bool Ten { get; set; }
        [Required]  public bool Eleven { get; set; }
        [Required]  public bool Twelve { get; set; }
        [Required] public bool Thirteen { get; set; }
        [Required]  public bool Fourteen { get; set; }
        [Required]   public bool Fifteen { get; set; }
        [Required]   public bool Sixteen { get; set; }
        [Required]   public bool Seventeen { get; set; }
        [Required]    public bool Eighteen { get; set; }
        [Required]   public bool Nineteen { get; set; }
        [Required]     public bool Twenty { get; set; }
        [Required]   public bool TwentyOne { get; set; }
        [Required]   public bool TwentyTwo { get; set; }
        [Required]    public bool TwentyThree { get; set; }
        [Required] public bool TwentyFour { get; set; }

        public DBHoursEnum(bool one, bool two, bool three, bool four, bool five, bool six, bool seven, bool eight, bool nine, bool ten, bool eleven, bool twelve, bool thirteen, bool fourteen, bool fifteen, bool sixteen, bool seventeen, bool eighteen, bool nineteen, bool twenty, bool twentyOne, bool twentyTwo, bool twentyThree, bool twentyFour)
        {
            One = one;
            Two = two;
            Three = three;
            Four = four;
            Five = five;
            Six = six;
            Seven = seven;
            Eight = eight;
            Nine = nine;
            Ten = ten;
            Eleven = eleven;
            Twelve = twelve;
            Thirteen = thirteen;
            Fourteen = fourteen;
            Fifteen = fifteen;
            Sixteen = sixteen;
            Seventeen = seventeen;
            Eighteen = eighteen;
            Nineteen = nineteen;
            Twenty = twenty;
            TwentyOne = twentyOne;
            TwentyTwo = twentyTwo;
            TwentyThree = twentyThree;
            TwentyFour = twentyFour;
        }

        protected bool Equals(DBHoursEnum other)
        {
            return One == other.One && Two == other.Two && Three == other.Three && Four == other.Four 
                   && Five == other.Five && Six == other.Six && Seven == other.Seven && Eight == other.Eight 
                   && Nine == other.Nine && Ten == other.Ten && Eleven == other.Eleven && Twelve == other.Twelve 
                   && Thirteen == other.Thirteen && Fourteen == other.Fourteen && Fifteen == other.Fifteen 
                   && Sixteen == other.Sixteen && Seventeen == other.Seventeen && Eighteen == other.Eighteen 
                   && Nineteen == other.Nineteen && Twenty == other.Twenty && TwentyOne == other.TwentyOne 
                   && TwentyTwo == other.TwentyTwo && TwentyThree == other.TwentyThree && TwentyFour == other.TwentyFour;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DBHoursEnum)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(One);
            hashCode.Add(Two);
            hashCode.Add(Three);
            hashCode.Add(Four);
            hashCode.Add(Five);
            hashCode.Add(Six);
            hashCode.Add(Seven);
            hashCode.Add(Eight);
            hashCode.Add(Nine);
            hashCode.Add(Ten);
            hashCode.Add(Eleven);
            hashCode.Add(Twelve);
            hashCode.Add(Thirteen);
            hashCode.Add(Fourteen);
            hashCode.Add(Fifteen);
            hashCode.Add(Sixteen);
            hashCode.Add(Seventeen);
            hashCode.Add(Eighteen);
            hashCode.Add(Nineteen);
            hashCode.Add(Twenty);
            hashCode.Add(TwentyOne);
            hashCode.Add(TwentyTwo);
            hashCode.Add(TwentyThree);
            hashCode.Add(TwentyFour);
            return hashCode.ToHashCode();
        }
    }
}