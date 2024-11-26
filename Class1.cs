using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4ooap
{
    public interface IPayment // відокр логіку визначення типу оплати від працівника)
    {
        decimal CalculateSalary(decimal hoursWorked, decimal workDone, decimal rate);
    }

    public class HourlyPayment : IPayment // реалізації
    {
        public decimal CalculateSalary(decimal hoursWorked, decimal workDone, decimal rate)
        {
            return hoursWorked * rate;
        }
    }

    public class PieceworkPayment : IPayment //реалізації
    {
        public decimal CalculateSalary(decimal hoursWorked, decimal workDone, decimal rate)
        {
            return workDone * rate;

        }
    }

    public abstract class Employee //абстракція (Задає базову структуру для всіх працівників)
    {
        public string Name { get; set; }
        public string Position { get; set; }
        protected IPayment PaymentType;

        protected Employee(IPayment paymentType)
        {
            PaymentType = paymentType;
        }

        public abstract decimal HourlyRate { get; } //ставки
        public abstract decimal PieceworkRate { get; }

        //    public decimal GetSalary(decimal hoursWorked, decimal workDone)
        //    {
        //        if (hoursWorked < 0 || workDone < 0)
        //        {
        //            throw new ArgumentException("Значення не може бути від'ємним");
        //        }

        //        if (PaymentType is HourlyPayment) //метод в залежності від типу оплати обчисл
        //        {
        //            return PaymentType.CalculateSalary(hoursWorked, 0, HourlyRate);
        //        }
        //        else if (PaymentType is PieceworkPayment)
        //        {
        //            return PaymentType.CalculateSalary(0, workDone, PieceworkRate);
        //        }
        //        return 0;
        //    }
        //}

        //public string GetSalary(decimal hoursWorked, decimal workDone)
        //{
        //    if (hoursWorked < 0 || workDone < 0)
        //    {
        //        return "Від'ємне значення";
        //    }

        //    if (PaymentType is HourlyPayment) //метод в залежності від типу оплати обчислює зарплату
        //    {
        //        return PaymentType.CalculateSalary(hoursWorked, 0, HourlyRate).ToString("F2");
        //    }
        //    else if (PaymentType is PieceworkPayment)
        //    {
        //        return PaymentType.CalculateSalary(0, workDone, PieceworkRate).ToString("F2");
        //    }
        //    return "0";
        //}




        public decimal GetSalary(decimal hoursWorked, decimal workDone)
        {
            if (hoursWorked < 0 || workDone < 0)
            {
                return 0-0;
            }

            if (PaymentType is HourlyPayment) //метод в залежності від типу оплати обчисл
            {
                return PaymentType.CalculateSalary(hoursWorked, 0, HourlyRate);
            }
            else if (PaymentType is PieceworkPayment)
            {
                return PaymentType.CalculateSalary(0, workDone, PieceworkRate);
            }
            return 0;
        }
    }


    public class Manager : Employee
    {
        public Manager(IPayment paymentType) : base(paymentType) { } //Передає тип оплати  в базовий клас Employe

        public override decimal HourlyRate => 50;
        public override decimal PieceworkRate => 300;
    }

        public class Worker : Employee
        {
            public Worker(IPayment paymentType) : base(paymentType) { }

            public override decimal HourlyRate => 30;
            public override decimal PieceworkRate => 150;
        }

        public class Engineer : Employee
        {
            public Engineer(IPayment paymentType) : base(paymentType) { }

            public override decimal HourlyRate => 40;
            public override decimal PieceworkRate => 200;
        }
    
}