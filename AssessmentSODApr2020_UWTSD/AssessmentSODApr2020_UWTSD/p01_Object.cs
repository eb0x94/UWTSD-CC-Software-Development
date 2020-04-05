using System;

namespace AssessmentSODApr2020_UWTSD
{
    class Customer
    {
        //Properties for the object customer.
        private string firstName;
        private string lastName;
        private double priceOfProduct;
        private int quantity;

        //Constructor for customer object
        public Customer(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        //Setter for the order 
        public void setOrder(double price, int quantity)
        {
            this.priceOfProduct = price;
            this.quantity = quantity;
        }

        //Getter for the order
        public double getOrder()
        {
            return this.priceOfProduct * this.quantity;
        }

        class p01_Object
        {
            static void Main(string[] args)
            {
                //Reading from console the information
                Console.Write("Enter customer's first name: ");
                string inputFirstName = Console.ReadLine();
                Console.Write("Enter customer's last name: ");
                string inputLastName = Console.ReadLine();
                Console.Write("Enter price of product: ");
                double productPrice = double.Parse(Console.ReadLine());
                Console.Write("Enter quantity of product: ");
                int productQuantity = int.Parse(Console.ReadLine());

                //Creating customer object and setting the order price
                Customer customer = new Customer(inputFirstName, inputLastName);
                customer.setOrder(productPrice, productQuantity);

                //Printing the order details on console
                Console.WriteLine("The total price of the order is: {0}", customer.getOrder());

            }
        }
    }
}
