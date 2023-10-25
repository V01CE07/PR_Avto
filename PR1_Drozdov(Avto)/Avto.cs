using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PR1
{
    internal class Avto
    {
        public string nom { get; set; } //номер машины
        public double bak { get; set; } //объем бака в реальном времени
        public int ras { get; set; } //расстояние до цели
        public double fuelRashod { get; set; } //расход топлива на 100 км
        public double fuelAll { get; set; } //кол-во топлива нужное для поездки
        public double Probeg { get; set; }
        public double rasNew { get; set; } //новое расстояние для метода out
        public double bakOst { get; set; } //остаток топлива в баке 
        public double bakFull { get; set; } //общий объем бака
        public double bakNew { get; set; }
        private int speed { get; set; }

        public void Info(string Nom, float Bak, int Ras, double FuelRashod) //метод для записи информации
        {
            this.nom = Nom;
            this.bak = Bak;
            bakFull = bak;
            this.ras = Ras;
            rasNew = ras;
            this.fuelRashod = FuelRashod;

        }
        public void Out() //метод вывода информации
        {
            Console.WriteLine($"Номер машины: {nom}");
            Console.WriteLine($"Объем топливного бака в данный момент: {bak}");
            Console.WriteLine($"Объем топливного бака в целом: {bakFull}");
            Console.WriteLine($"Расстояние до цели в км: {rasNew}");
            Console.WriteLine($"Расход топлива на 100 км: {fuelRashod}");
            Console.WriteLine("");
        }
        public void Zapravka()
        {
            bakOst = bak;
            bakOst = Math.Round(bakOst, 2, MidpointRounding.ToEven);
            double Amount;
            double bakNew;

            rasNew = ras - Probeg;

            Console.WriteLine($"У вас осталось {bakOst} л. топлива.");
            Console.WriteLine($"Осталось проехать до цели {rasNew} км.");
            Console.WriteLine("Вы хотите заправиться?");
            string fuelAnswer = Console.ReadLine();
            string answer = fuelAnswer.ToLower();

            if (answer == "yes")
            {
                Console.WriteLine("Введите количество топлива, которое вы хотите заправить: ");
                Console.WriteLine($"Не забывайте, что ваш бак рассчитан на {bakFull} литров топлива.");
                Amount = Convert.ToDouble(Console.ReadLine());
                bakNew = bakOst + Amount;
                if (bakNew > bakFull)
                {
                    Console.WriteLine("Ошибка. Объем вашего бака меньше, чем количество топлива, которое вы пытаетесь залить в бак.");


                }
                else
                {
                    Console.WriteLine($"Вы заправились на {Amount} литров топлива, ваше количество топлива: {bakNew}");
                    bak = bakNew;
                }

            }
            else if (answer == "no")
            {
                Console.WriteLine("Заправка отменена.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Введена неверная команда.");
            }

        }
        public void Move()
        {
            double Fuel1Km;
            fuelAll = (fuelRashod * ras) / 100; //расчет топлива на всю поездку
            Fuel1Km = fuelRashod / 100; //расчет топлива на 1км для дальнейших вычислений
            Fuel1Km = Math.Round(Fuel1Km, 3, MidpointRounding.ToEven);
            Console.WriteLine($"Количество топлива нужное для поездки: {fuelAll}");
            Probeg = 0;
            Console.WriteLine($"Ваш путь при поездке составит {ras} км.");
            Console.WriteLine(Fuel1Km);
            while (Probeg < ras) //цикл езды
            {
                Probeg++;

                bak -= Fuel1Km;
                if (bak < 5)
                {
                    Zapravka();
                }
                if (Probeg == ras)
                {
                    Console.WriteLine($"Вы успешно завершили поездку. Пробег {Probeg} км.");
                    bak = Math.Round(bak, 2, MidpointRounding.ToEven);
                    Zapravka();
                }


            }
        }
        public void Razgon(int g) //метод разгона
        { speed += g; }
        public void Tormoz(int g) //метод торможения
        { speed -= g; }

    }
}
