
namespace MiniProjects.ProductPricingCalculator;

public class ProductPricingProgram
{
    double totalPrice;
    double totalTax;
    double totalDiscount;
    public void StartProductPricingProgram()
    {
        bool runProgram = true;
        Console.Clear();

        do
        {
            Console.Write("Enter the base price of the product: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double basePrice))
            {
                CalculateAndPrint(basePrice);
                Console.Clear();
            }
            else
            {
                FinalizeCalculations();
                runProgram = false;
                Console.ReadKey();
            }
        } while (runProgram);

    }


    public void CalculateAndPrint(double basePrice)
    {
        var tax = ApplyTax(basePrice);
        var discount = CalculateDiscount(basePrice);
        var price = tax - discount;

        totalPrice += price;
        totalTax += tax;
        totalDiscount += discount;

        Console.WriteLine($"Original Item Price: ${basePrice}");
        Console.WriteLine($"Item Price After Tax: ${tax}");
        Console.WriteLine($"Item Discount Applied: ${discount} ");
        Console.WriteLine($"Final Item Price: ${price} ");
        Console.WriteLine($"Total Price: ${totalPrice} ");
    }

    public double CalculateDiscount(double basePrice)
    {
        if (basePrice > 99 && basePrice < 500)
            return basePrice * 0.05;
        else if (basePrice > 499)
            return basePrice * 0.1;
        else
            return 0;
    }

    public double ApplyTax(double basePrice) => basePrice + (basePrice * 0.1);


    public void FinalizeCalculations()
    {
        Console.WriteLine($"Total Tax: ${totalPrice - totalTax}");
        Console.WriteLine($"Total Discount Applied: ${totalDiscount}");
        Console.WriteLine($"Total Price: ${totalPrice}");
    }
}
