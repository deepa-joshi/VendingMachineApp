

namespace VendingMachineApp.src
{
    public class VendingMachine
    {
       VendingMachineHelper  vendingMachineHelper= new VendingMachineHelper();
       public void startVendingMachine()
       {
            string? input;
            Console.WriteLine("Welcome to the Vending Machine!");
            vendingMachineHelper.DisplayMessage();

            do
            {
                Console.WriteLine("\nAvailable Commands:"+
                 "\n\tinsert [nickel/dime/quarter/penny]"+
                 "\n\tselect [cola/chips/candy]"+
                 "\n\treturn, exit");
                
                Console.Write("\nEnter command: ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("No input provided.");
                    continue;
                }

                input = input.ToLower();


                if (input.StartsWith("insert"))
                {
                    vendingMachineHelper.InsertCoin(input.Split(' ')[1]);
                }
                else if (input.StartsWith("select"))
                {
                    vendingMachineHelper.SelectProduct(input.Split(' ')[1]);
                }
                else if (input == "return" || input != "exit")
                {
                    vendingMachineHelper.ReturnCoinsAndExit(input);
                }

                vendingMachineHelper.DisplayMessage();

            } while (input != "exit");

            Console.WriteLine("Thank you for shopping, Bye!");
        }
    }
}
