using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionOperators
{
    class Fraction
    {

        int num, den;

        public Fraction(int num, int den)
        {
            this.num = num;
            this.den = den;
        }

        // overload operator +  
        // all operator overload definitions should be: public static  
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);
        }

        // overload operator *
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.num, a.den * b.den);
        }

        //overload operator <
        public static bool operator <(Fraction a, Fraction b)
        {
            if ( ((double) a.num / (double) a.den) < ((double) b.num / (double) b.den))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //overload operator >
        public static bool operator >(Fraction a, Fraction b)
        {
            Fraction c = new Fraction((b.den * a.num),(b.den * a.den));
            Fraction d = new Fraction((a.den * b.num),(a.den * b.den));

            if((c.num - d.num) <= 0){
                return false;
            } else {
                return true;
            }
        }

        //overload operator ==
        public static bool operator ==(Fraction a, Fraction b)
        {
            if(a.den == b.den && a.num == b.num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //overload operator !=
        public static bool operator !=(Fraction a, Fraction b)
        {
            if (a.den != b.den && a.num != b.num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //override equals
        public override bool Equals(object obj)
        {
            if(obj.GetType() != this.GetType()){
                return false;
            } else  {
                Fraction fraction = (Fraction)obj;
                if (fraction.num == this.num && fraction.den == this.den){
                    return true;
                } else {
                    return false;
                }
            }
        }


        // user-defined conversion from Fraction to double
        //  In general, implicit conversion operators should:
        //	- never throw exceptions and 
        //	- never lose information
        public static implicit operator double (Fraction f)
        {
            return (double)f.num / f.den;
        }

        public static explicit operator Fraction(int e)
        {
            return new Fraction(e, 1);
        }

        public override string ToString()
        {
            return string.Format($"({num} / {den})");
        }

        
    }
}
