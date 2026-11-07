namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {




            Console.WriteLine(" Wellcome to Estimate for carpet cleaning service");



            double priceSmall = 25.0;
                double priceLarge = 35.0;
                double taxRate = 0.06;

                
                Console.WriteLine ("Number of small carpets: ");
                int smallcarpets =Convert.ToInt32 (Console.ReadLine());
                

                Console.WriteLine("Number of large carpets: ");
            int largecarpets = Convert.ToInt32(Console.ReadLine());


        
            Double subtotal = (smallcarpets * priceSmall) + (largecarpets * priceLarge);
                double tax = Math.Round(subtotal * taxRate, 2, MidpointRounding.AwayFromZero);
                double total = subtotal + tax;

                
                
                
             
           
                Console.WriteLine($"Price per small carpets: ${priceSmall}");
                Console.WriteLine($"Price per large carpets: ${priceLarge}");
                Console.WriteLine($"Cost : ${subtotal}");
                Console.WriteLine($"Tax: ${tax}");

                
                Console.WriteLine("Estimates are valid for 30 days");
            

            
        }
    }
    
}
