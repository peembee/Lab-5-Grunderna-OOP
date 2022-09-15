using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5GrundernaOOP
{
    internal class Triangle
    {       
        public double getArea(float baseOfTriangle, float heightOfTriangle) // calculate Area b*h/2
        {
            return baseOfTriangle * heightOfTriangle / 2;
        }

        public double getCircumference(float side1, float side2, float side3)  // calculate Circumference side + side + side
        {
            return side1 + side2 + side3;
        }

        public override string ToString()
        {
            return "Triangel";
        }
    }
}
