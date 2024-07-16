internal class Program
{
    static void VeryLongMethod() {
        Console.WriteLine("Inizio metodo lungo");
        Thread.Sleep(3000);
        Console.WriteLine("Fine metodo lungo");
    }
    private static async void Tasks() {
        Console.WriteLine("Chiamata sincrona");
        VeryLongMethod();
        Console.WriteLine("Fine chiamata sincrona");
        Console.WriteLine("Task asincrono");
        Task.Run(() => VeryLongMethod());
        Console.WriteLine("Il programma continua nel suo ciclo principale");
        Console.Write("Premi INVIO per proseguire"); Console.ReadLine();
        Console.WriteLine("Chiamata asincrona con attesa del risultato");
        await Task.Run(() => VeryLongMethod());
        Console.WriteLine("Fine");
    }
    public static void Main() {
        Tasks();
        Console.ReadLine();
    }
}