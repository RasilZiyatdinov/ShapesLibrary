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
    /// Класс - треугольник
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// Треугольник
        /// </summary>
        /// <param name="sideA">1 сторона</param>
        /// <param name="sideB">2 сторона</param>
        /// <param name="sideC">3 сторона</param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0d)
                throw new ArgumentException("Некорректная длина стороны", nameof(sideA));

            if (sideB <= 0d)
                throw new ArgumentException("Некорректная длина стороны", nameof(sideB));

            if (sideC <= 0d)
                throw new ArgumentException("Некорректная длина стороны", nameof(sideC));

            if (!(sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA))
            {
                throw new ArgumentException("Cумма двух сторон треугольника должна быть больше третьей");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            isRight = new Lazy<bool>(CheckIsRight);
        }

        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        private readonly Lazy<bool> isRight;
        public bool IsRightTriangle => isRight.Value;

        /// <summary>
        /// Проверить треугольник на прямоугольность
        /// </summary>
        /// <returns></returns>
        private bool CheckIsRight()
        {
            double max = SideA, b = SideB, c = SideC;
            if (b > max)
                Utils.Swap(ref max, ref b);

            if (c > max)
                Utils.Swap(ref max, ref c);

            return Math.Pow(max, 2) - Math.Pow(b, 2) - Math.Pow(c, 2) == 0d;
        }

        /// <summary>
        /// Вычислить площадь
        /// </summary>
        /// <returns></returns>
        public double CalculateSquare()
        {
            double semiP = (SideA + SideB + SideC) / 2d;
            //формула Герона
            double square = Math.Sqrt(semiP * (semiP - SideA) * (semiP - SideB) * (semiP - SideC));
            return square;
        }
    }
}
