using Microsoft.VisualBasic;
using Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    /// <summary>
    /// Класс - круг
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Круг
        /// </summary>
        /// <param name="radius">Радиус</param>
        /// <exception cref="ArgumentException"></exception>
		public Circle(double radius)
        {
            if (radius <= 0d)
                throw new ArgumentException("Некорректная длина радиуса", nameof(radius));
            Radius = radius;
        }

        public double Radius { get; }

        /// <summary>
        /// Вычислить площадь
        /// </summary>
        /// <returns></returns>
        public double CalculateSquare()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
