// Product Management System
string? userInput = "";
bool validInput = false;
bool exit = false;
List<Product> products = new List<Product>();

do
{
    DisplayMenu();
    userInput = Console.ReadLine();

    if (!string.IsNullOrEmpty(userInput))
    {
        string menuSelection = userInput.Trim();

        switch (menuSelection)
        {
            case "1":
                AddProduct();
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                break;

            case "2":
                UpdateStock();
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                break;

            case "3":
                ViewProduct();
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                break;

            case "4":
                DeleteStock();
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                break;

            case "5":
            case "exit":
                exit = true;
                break;

            default:
                Console.WriteLine("Invalid selection. Please select (1, 2, 3, 4) or 'exit' to terminate");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                break;
        }
    }

} while (!exit);

// Menu selection
void DisplayMenu()
{
    Console.WriteLine("Product Management System");
    Console.WriteLine("Enter a selection (1, 2, 3, 4) or 'exit' to terminate");
    Console.WriteLine("1. Add product\n2. Update stock\n3. View all products\n4. Remove product\n5. 'exit' to terminate");
}

// Add new product
void AddProduct()
{
    string name = "";
    int price = 0;
    int quantity = 0;

    do
    {
        Console.WriteLine("Enter product name: ");
        userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            name = userInput.Trim();
            validInput = true;
        }
        else
        {
            Console.WriteLine("Product name cannot be empty");
        }
    } while (!validInput);

    validInput = false;
    do
    {
        Console.WriteLine("Enter product price: ");
        userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            userInput = userInput.Trim();
            if (int.TryParse(userInput, out price))
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Value must be numeric");
            }
        }
        else
        {
            Console.WriteLine("Product price cannot be empty");
        }
    } while (!validInput);

    validInput = false;
    do
    {
        Console.WriteLine("Enter product quantity: ");
        userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            userInput = userInput.Trim();
            if (int.TryParse(userInput, out quantity))
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Value must be numeric");
            }
        }
        else
        {
            Console.WriteLine("Product quantity cannot be empty");
        }
    } while (!validInput);

    Console.WriteLine("product added successfully");
    string id = name + "#" + (products.Count + 1).ToString();
    products.Add(new Product(id, name, quantity, price));
}

// Display list of products
void ViewProduct()
{
    if (products.Count == 0)
    {
        Console.WriteLine("No products available.");
        return;
    }

    foreach (var product in products)
    {
        Console.WriteLine($"\nProduct ID: {product.ID}\nName: {product.Name}\nQuantity: {product.Quantity}\nPrice: {product.Price:C}\n");
    }
}

// Update stock (when sold or restocked)

void UpdateStock()
{
    string searchResult = SearchProduct();
    if (!string.IsNullOrEmpty(searchResult))
    {
        Console.WriteLine($"Did you sell or restock Product: {searchResult}? (sold/restock)");
        userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            if (userInput == "sold")
            {
                foreach (var product in products)
                {
                    if (product.ID == searchResult)
                    {
                        Console.WriteLine($"Enter the number of products sold for Product {product.ID}");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int quantity))
                        {
                            if (quantity > product.Quantity)
                            {
                                Console.WriteLine($"Error: Cannot sell {quantity} units. Only {product.Quantity} units available in stock.");
                            }
                            else
                            {
                                product.Quantity -= quantity;
                                Console.WriteLine($"{product.ID} updated successfully");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Value must be a numeric character");
                        }

                    }
                }
            }
            else if (userInput == "restock")
            {
                foreach (var product in products)
                {
                    if (product.ID == searchResult)
                    {
                        Console.WriteLine($"Enter the number of products added for Product {product.ID}");
                        userInput = Console.ReadLine();
                        if (int.TryParse(userInput, out int quantity))
                        {
                            product.Quantity += quantity;
                            Console.WriteLine($"{product.ID} updated succesfully");
                        }
                        else
                        {
                            Console.WriteLine("Value must be a numeric character");
                        }

                    }
                }

            }
            else
            {
                Console.WriteLine("Please enter either (sold or restock)");
            }
        }
        else
        {
            Console.WriteLine("Input cannot be empty");
        }
    }
    else
    {
        Console.WriteLine("Product cannot be found");
    }
}

// Remove stock from list
void DeleteStock()
{
    if (products == null || products.Count == 0)
    {
        Console.WriteLine("No products available to delete.");
        return;
    }

    string searchResult = SearchProduct();
    if (!string.IsNullOrEmpty(searchResult))
    {
        var productToDelete = products.FirstOrDefault(p => p.ID == searchResult);
        if (productToDelete != null)
        {
            Console.WriteLine($"Product ID: {productToDelete.ID}\nName: {productToDelete.Name}\nQuantity: {productToDelete.Quantity}\nPrice: {productToDelete.Price}");
            Console.WriteLine($"Do you want to delete this product with ID {productToDelete.ID}? (yes/no)");
            userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput) && userInput.ToLower() == "yes")
            {
                products.Remove(productToDelete);
                Console.WriteLine($"Product with ID {productToDelete.ID} deleted successfully.");
            }
            else
            {
                Console.WriteLine("Deletion canceled.");
            }
        }
    }
    else
    {
        Console.WriteLine("Product not found.");
    }
}

// search through product list using id
string SearchProduct()
{
    Console.WriteLine("Enter the product ID");
    userInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(userInput))
    {
        string search = userInput.Trim();
        foreach (var product in products)
        {
            if (product.ID.Equals(search, StringComparison.OrdinalIgnoreCase))
            {
                return product.ID;
            }
        }
        Console.WriteLine("Product not found.");
    }
    else
    {
        Console.WriteLine("Product ID cannot be empty");
    }
    return "";
}

public class Product
{
    public string ID { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }

    public Product(string id, string name, int quantity, int price)
    {
        ID = id;
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}