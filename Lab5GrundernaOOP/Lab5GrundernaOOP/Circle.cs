using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5GrundernaOOP
{
    /* Mohammed Boukhedimi
       Klass: NET22 */
    internal class Circle
    {
        private double pi = 3.1415926f;

        public Circle(float radius)
        {
            Console.WriteLine("En cirkel med radie " + radius + " har arean: " + getArea(radius));
            radius = 6;
            Console.WriteLine("En cirkel med radie " + radius + " har arean: " + getArea(radius));
        }         
        
        public double getArea(float radius)  // calculate AREA
        {           
            return radius * radius * pi;
        }

        public double getCircumference(float diameter) // calculate Circumference ( diameter * pi )
        {
            return diameter * pi;
        }

        public double getVolume(float radius) // calculate Volume ( Volume = 4 * pi *r^3 / 3 )
        {
            radius = radius * radius * radius;
            return 4 * pi * radius / 3;
        }

        public override string ToString()
        {
            return "Cirkel";
        }
    }
}
