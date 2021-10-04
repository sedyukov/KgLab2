using System;
using System.Collections.Generic;
using System.Text;

namespace KgLab2
{
    class Comp
    {
        public double Re;
        public double Im;

        public Comp(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public Comp CompAdd(Comp X)
        {
            Comp Result = new Comp(0, 0);
            Result.Re = this.Re + X.Re;
            Result.Im = this.Im + X.Im;
            return Result;
        }

        public Comp CompMult(Comp X)
        {
            Comp Result = new Comp(0, 0);
            Result.Re = this.Re * X.Re - this.Im * X.Im;
            Result.Im = this.Re * X.Im + this.Im * X.Re;
            return Result;
        }

        public double CompAbs()
        {
            return Math.Sqrt(this.Re * this.Re + this.Im * this.Im);
        }

    }
}
