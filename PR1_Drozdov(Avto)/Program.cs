using PR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassAndObjects_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Avto avto = new Avto();
            avto.Info("205", 40, 515, 8);

            avto.Out();

            avto.Move();

            avto.Out();
        }

    }

}
