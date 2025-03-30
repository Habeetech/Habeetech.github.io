/* Basic Contact Management Application.
- This is a Basic Contact Management Application
- This App use array to store the contact details and can only store 10 contact
- Validates input for phone number and email
- This App will be review in the future for added features and authentication.
*/

// main menu display options to add contact, view contacts and search a contact using their name or phone number
string[,] userContacts = new string[10, 4];
string menuSelection = "";
string? userInput;


do
{
    Console.WriteLine("This is a Basic Contact Management Application");
    Console.WriteLine("Please enter a selection (1, 2, 3 or exit) to navigate the menu");
    Console.WriteLine("1: Add a new contact");
    Console.WriteLine("2: View your contact list");
    Console.WriteLine("3: Search through your contact list");
    Console.WriteLine("Enter 'exit' to quit the app");
    userInput = Console.ReadLine();
    
    if (userInput != null)
    {
        menuSelection = userInput.ToLower();
        switch (menuSelection)
        {
            case "1":
            addNewContact(userContacts);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            break;

            case "2":
            viewContact(userContacts);
             
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            break;

            case "3":
            Console.WriteLine("Please Enter:\n1. To search by name or\n2. To search by phone number");
            string? searchChoice = Console.ReadLine();
            int.TryParse(searchChoice, out int choice);

            switch(choice)
            {
                case 1: 
                searchName(userContacts);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                break;

                case 2:
                searchNumber(userContacts);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                break;

                default:
                break;
            }
            break;

            default:
            break;
        }
    }
} while (menuSelection != "exit");
// Adding new contacts - name, phone number, e-mail and a short note
void addNewContact(string[,] contact)
{
    bool validInput = false;
    for (int i = 0; i < contact.GetLength(0); i++)
    {
        if (string.IsNullOrEmpty(contact[i, 0]))
        {
            do
            {
                Console.Write("Enter the contact name: ");
                string? name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    contact[i, 0] = name.Trim();
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input! Contact name cannot be empty");
                    validInput = false;
                }
            } while (validInput == false);

            do
            {
                Console.Write("Enter contact phone number: ");
                string? number = Console.ReadLine();
                
                if (!string.IsNullOrEmpty(number))
                {
                    number = number.Trim();
                    Console.WriteLine($"{number} with legnth: {number.Length}");
                    if (number.Length > 9 && long.TryParse(number, out long result))
                    {
                        contact[i, 1] = number;
                        validInput = true;
                    }
                    else
                    {
                        validInput = false;
                        Console.WriteLine("Phone number must be at least 10 digit and contain numeric characters.");
                    }
                }
                else
                {
                   Console.WriteLine("Invalid input! Contact number cannot be empty");
                    validInput = false;
                }
            } while (validInput == false);
            do
            {
                Console.Write("Enter the Contact E-mail address: ");
                string? eMail = Console.ReadLine();
                
                if (string.IsNullOrEmpty(eMail) || (eMail.Contains('@') && eMail.Contains('.')))
                {
                    contact[i, 2] = eMail ?? string.Empty;
                    validInput = true;
                }
                else
                {
                    validInput = false;
                    Console.WriteLine($@"Invalid format: E-mail must contain '@' and '.'");
                }
            } while (validInput == false);
        
            Console.Write("Please add any additional note: ");
            string note = Console.ReadLine() ?? string.Empty;                contact[i, 3] = note;

            Console.WriteLine("Contact added successfully!");
            break;
        }
        if (i == contact.GetLength(0) - 1)
        {
            Console.WriteLine("Contact list is full. Cannot add more contacts.");
        }
    }
}
// Viewing added contacts

void viewContact(string [,] contact)
{
    bool contactList = false;
    for (int i = 0; i < contact.GetLength(0); i++)
    {
        if (!string.IsNullOrEmpty(contact[i, 0]))
        {
            contactList = true;
            Console.WriteLine($"Name: {contact[i, 0]}");
            Console.WriteLine($"Phone Number: {contact[i, 1]}");
            Console.WriteLine($"E-Mail: {contact[i, 2]}");
            Console.WriteLine($"Note: {contact[i, 3]}");
            Console.WriteLine();
        }
    }
    if(!contactList)
        {
            Console.WriteLine("Your contact list is empty");
        }
}

//Searching through contacts using name and phone number

void searchName (string [,] contact)
{
    string searchTerm = "";

    Console.WriteLine("Enter the name of the contact: ");
    string? input = Console.ReadLine();
    

    if (!string.IsNullOrEmpty(input))
    {
        searchTerm = input.Trim().ToLower();
        bool found = false;

        for (int i = 0; i < contact.GetLength(0); i++)
        {
            if (!string.IsNullOrEmpty(contact[i, 0]) && searchTerm == contact[i, 0].ToLower())
            {
                found = true;
                Console.WriteLine($"Name: {contact[i, 0]}\nPhone Number: {contact[i, 1]}\nE-Mail: {contact[i, 2]}\nNote: {contact[i, 3]}");
            }
        }

        if (!found)
        {
            Console.WriteLine($"No contact matches your search name: {searchTerm}");
        }
    }
    else
    {
        Console.WriteLine("Invalid input: Please enter a search term.");
    }
}

void searchNumber (string [,] contact)
{
    string searchTerm = "";

    Console.WriteLine("Enter the contact number you want to search for:");
    string? input = Console.ReadLine();

    if (input != null)
    {
        searchTerm = input.Trim();
        bool found = false;
        for (int i = 0; i < contact.GetLength(0); i++)
        {
            if (!string.IsNullOrEmpty(contact[i, 1]) && searchTerm == contact[i, 1].Trim())
            {
                found = true;
                Console.WriteLine($"Name: {contact[i, 0]}\nPhone Number: {contact[i, 1]}\nE-Mail: {contact[i, 2]}\nNote: {contact[i, 3]}");
            }
        }
        if (!found)
        {
            Console.WriteLine($"No contact match ({searchTerm}) the phone number you searched for");
        }
    }
    else
    {
        Console.WriteLine("Invalid input: input a valid number.");
    }
}