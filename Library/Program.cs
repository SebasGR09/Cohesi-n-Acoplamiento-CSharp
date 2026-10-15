using System;


public interface INotification
{
    void Send();
}


public interface ICalculate
{
    void Calculate();
}


namespace Library
{

    public class Notification : INotification
    {
        public void Send()
        {
            Console.WriteLine("Se ha enviado la notificacion por correo");
        }
    }

    public class NotificationSMS : INotification
    {
        public void Send()
        {
            Console.WriteLine("Se ha enviado la notificacion por SMS");
        }
    }


    public class CalculateStadistics : ICalculate
    {
        public void Calculate()
        {
            Console.WriteLine("Calculando Estadisticas");
        }
    }


    public class LibraryService
    {

        private readonly INotification notification = new Notification();
        private readonly ICalculate calculate = new CalculateStadistics();

        public LibraryService(INotification notification, ICalculate calculate) 
        {
            this.notification = notification;
            this.calculate = calculate;
        }


        public void RegisterManga()
        {
            Console.WriteLine("Se ha registrado el manga");
            notification.Send();
        }

        public void DeleteManga()
        {
            Console.WriteLine("Se ha eliminado el manga");
        }

        public void Calculate()
        {
            calculate.Calculate();
        }
    }


    

    // Prueba
    public class Program
    {
        static void Main(string[] args)
        {
            var libreria = new LibraryService(new NotificationSMS(), new CalculateStadistics());

            libreria.RegisterManga();
        }
    }
}