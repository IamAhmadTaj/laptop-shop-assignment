using System;
namespace LaptopShop {
    class Laptop {
        public string Model { get; set; }

        public Laptop(string model) {
            Model = model;
        }
    }

    class ShoppingCart {
        private List<Laptop> cartItems = new List<Laptop>();

        public void AddToCart(Laptop laptop) {
            cartItems.Add(laptop);
            Console.WriteLine($"Laptop '{laptop.Model}' added to the cart.");
        }

        public void ViewCart() {
            Console.WriteLine("Shopping Cart:");
            foreach (var item in cartItems) {
                Console.WriteLine($"- {item.Model}");
            }
        }

        public void Checkout() {
            Console.WriteLine("Thank you for your purchase!");
            cartItems.Clear();
            Console.WriteLine("Press any key to return to the Main Menu...");
            Console.ReadKey();
        }
    }

    class LaptopShop {
        private List<Laptop> laptops = new List<Laptop>();
        private ShoppingCart cart = new ShoppingCart();

        public void Run() {
            InitializeLaptops();

            while (true) {
                DisplayMainMenu();
                int choice = GetUserChoice(1, 4);

                switch (choice) {
                    case 1:
                        ListAvailableLaptops();
                        break;
                    case 2:
                        cart.ViewCart();
                        break;
                    case 3:
                        cart.Checkout();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for shopping with us. Goodbye!");
                        return;
                }
            }
        }

        private void DisplayMainMenu() {
            Console.WriteLine("Laptop Shop");
            Console.WriteLine("1. List Available Laptops");
            Console.WriteLine("2. View Cart");
            Console.WriteLine("3. Checkout");
            Console.WriteLine("4. Exit");
        }

        private void InitializeLaptops() {
            laptops.Add(new Laptop("Dell Inspiron"));
            laptops.Add(new Laptop("HP Pavilion"));
            laptops.Add(new Laptop("Lenovo ThinkPad"));
        }

        private void ListAvailableLaptops() {
            Console.WriteLine("Available Laptops:");
            for (int i = 0; i < laptops.Count; i++) {
                Console.WriteLine($"{i + 1}. {laptops[i].Model}");
            }

            Console.WriteLine("0. Back to Main Menu");

            int choice = GetUserChoice(0, laptops.Count);

            if (choice == 0) {
                return;
            }

            Laptop selectedLaptop = laptops[choice - 1];
            Console.WriteLine($"Selected Laptop: {selectedLaptop.Model}");

            Console.WriteLine("1. Add to Cart");
            Console.WriteLine("2. Back to Laptops");

            int option = GetUserChoice(1, 2);

            if (option == 1) {
                cart.AddToCart(selectedLaptop);
            } else if (option == 2) {
                ListAvailableLaptops();
            }
        }

        private int GetUserChoice(int minValue, int maxValue) {
            int choice;
            while (true) {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue) {
                    return choice;
                } else {
                    Console.WriteLine($"Please enter a number between {minValue} and {maxValue}.");
                }
            }
        }
    }

    class Program {
        static void Main() {
            LaptopShop shop = new LaptopShop();
            shop.Run();
        }
    }
}

