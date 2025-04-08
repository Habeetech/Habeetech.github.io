/* Basic Contact Management Application.
- This is a Basic Contact Management Application
- This App uses an array to store the contact details, with a configurable maximum number of contacts
- Ensures Name and Phone number are not empty or null
- Validates input for phone number and email (email can be empty)
- Displays contact in alphabetical order
-Search, Edit and Delete contact (handles cases multiple contacts with the same name)
- This App will be review in the future for added features and authentication.
*/

// main menu display options to add contact, view contacts and search a contact using their name or phone number
const int MAX_CONTACTS = 10;
string[,] userContacts = new string[MAX_CONTACTS, 4];
string menuSelection = "";
string? userInput;
bool validInput = false;

do
{
    Console.WriteLine("This is a Basic Contact Management Application");
    Console.WriteLine("Please enter a selection (1, 2, 3 or exit) to navigate the menu");
    Console.WriteLine("1: Add a new contact");
    Console.WriteLine("2: View your contact list");
    Console.WriteLine("3: Search through your contact list");
    Console.WriteLine("4: Edit the details of your contact");
    Console.WriteLine("5: Delete contact from your contactlist");
    Console.WriteLine("Enter 'exit' to quit the app");
    userInput = Console.ReadLine();
    if (userInput == null)
    {
        Console.WriteLine("Input cannot be null. Please try again.");
        continue;
    }

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

                switch (choice)
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

            case "4":
                editContact(userContacts);
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                break;

            case "5":
                deleteContact(userContacts);
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                break;
        }
    }
} while (menuSelection != "exit");
// Adding new contacts - name, phone number, e-mail and a short note
void addNewContact(string[,] contact)
{
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
                userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput))
                {
                    userInput = userInput.Trim();

                    if (userInput.Length > 9 && long.TryParse(userInput, out long result))
                    {
                        contact[i, 1] = userInput;
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
                userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput) || (userInput.Contains('@') && userInput.Contains('.')))
                {
                    contact[i, 2] = userInput ?? string.Empty;
                    validInput = true;
                }
                else
                {
                    validInput = false;
                    Console.WriteLine($@"Invalid format: E-mail must contain '@' and '.'");
                }
            } while (validInput == false);

            Console.Write("Please add any additional note: ");
            userInput = Console.ReadLine() ?? string.Empty;
            contact[i, 3] = userInput;
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

void viewContact(string[,] contact)
{
    bool contactList = false;
    string[] contacts = new string[MAX_CONTACTS];
    for (int i = 0; i < contact.GetLength(0); i++)
    {

        if (!string.IsNullOrEmpty(contact[i, 0]))
        {

            contacts[i] = $"\nName: {contact[i, 0]}\nPhone Number: {contact[i, 1]}\nE-Mail: {contact[i, 2]}\nNote: {contact[i, 3]}";
        }
    }
    Array.Sort(contacts);


    foreach (var item in contacts)
    {
        if (!string.IsNullOrEmpty(item))
        {
            Console.WriteLine(item);
            contactList = true;
        }
    }
    if (!contactList)
    {
        Console.WriteLine("Your contact list is empty");
    }
}

//Searching through contacts using name and phone number

void searchName(string[,] contact)
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
            Console.WriteLine($"No contact found with the name: {searchTerm}");
        }
    }
    else
    {
        Console.WriteLine("Invalid input: Please enter a search term.");
    }
}

void searchNumber(string[,] contact)
{
    string searchTerm = "";

    Console.WriteLine("Enter the contact number you want to search for:");
    string? input = Console.ReadLine();

    if (!string.IsNullOrEmpty(input))
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
            Console.WriteLine($"No contact found with the phone number: {searchTerm}");
        }
    }
    else
    {
        Console.WriteLine("Invalid input: input a valid number.");
    }
}
void editContact(string[,] contact)
{
    Console.WriteLine("Please enter the name of the contact you'd like to edit:");
    userInput = Console.ReadLine();
    bool found = false;
    int matchCount = 0;

    if (!string.IsNullOrEmpty(userInput))
    {
        for (int i = 0; i < contact.GetLength(0); i++)
        {
            if (!string.IsNullOrEmpty(contact[i, 0]) && string.Equals(userInput, contact[i, 0], StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                matchCount++;
                Console.WriteLine($"\n{matchCount}\nName: {contact[i, 0]}\nPhone Number: {contact[i, 1]}\nE-Mail: {contact[i, 2]}\nNote: {contact[i, 3]}");
            }
        }
        if (!found)
        {
            Console.WriteLine($"No contact matches your search for {userInput}");
        }
        else
        {
            do
            {
                Console.WriteLine("Please enter the index of the contact you'd like to edit");
                string? inputIndex = Console.ReadLine();
                if (!string.IsNullOrEmpty(inputIndex) && int.TryParse(inputIndex, out int selectedIndex))
                {
                    matchCount = 0;
                    for (int i = 0; i < userContacts.GetLength(0); i++)
                    {
                        if (!string.IsNullOrEmpty(userContacts[i, 0]) && string.Equals(userInput, userContacts[i, 0], StringComparison.OrdinalIgnoreCase))
                        {
                            matchCount++;
                            if (matchCount == selectedIndex)
                            {
                                Console.WriteLine($"\nName: {contact[i, 0]}\nPhone Number: {contact[i, 1]}\nE-Mail: {contact[i, 2]}\nNote: {contact[i, 3]}");

                                Console.WriteLine(@$"Enter (name, number, email or note) to edit the details of this contact or 'back' to go back");
                                string? editDetails = Console.ReadLine();

                                if (!string.IsNullOrEmpty(editDetails))
                                {
                                    editDetails = editDetails.ToLower();
                                    switch (editDetails)
                                    {
                                        case "name":
                                            editName(ref userContacts[i, 0]);
                                            found = false;
                                            break;

                                        case "number":
                                            editNumber(ref userContacts[i, 1]);
                                            found = false;
                                            break;

                                        case "email":
                                            editEmail(ref userContacts[i, 2]);
                                            found = false;
                                            break;

                                        case "note":
                                            editNote(ref userContacts[i, 3]);
                                            found = false;
                                            break;

                                        case "back":
                                            found = false;
                                            break;

                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Please enter either (name, number, email or note)");
                                }
                            }
                            else if (matchCount < selectedIndex)
                            {
                                Console.WriteLine("Invalid Index: Please enter a valid index number");
                            }
                        }
                    }
                }
            } while (found == true);
        }
    }
}
void editName(ref string contactName)
{
    Console.WriteLine($"Please enter the new contact name:");
    userInput = Console.ReadLine();
    do
    {
        if (!string.IsNullOrEmpty(userInput))
        {
            contactName = userInput.Trim();
            Console.WriteLine("Contact name updated successfully");
            validInput = true;
        }
        else
        {
            Console.WriteLine($"Invalid input: Contact name cannot be empty");
            validInput = false;
        }
    } while (validInput == false);
}
void editNumber(ref string contactNumber)
{
    Console.WriteLine($"Please enter the new contact number:");
    userInput = Console.ReadLine();

    do
    {
        if (!string.IsNullOrEmpty(userInput))
        {
            userInput = userInput.Trim();

            if (userInput.Length > 9 && long.TryParse(userInput, out long result))
            {
                contactNumber = userInput;
                Console.WriteLine("Contact number updated successfully");
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
}
void editEmail(ref string eMail)
{
    do
    {
        Console.Write("Enter the new contact E-mail address: ");
        userInput = Console.ReadLine();

        if (string.IsNullOrEmpty(userInput) || (userInput.Contains('@') && userInput.Contains('.')))
        {
            eMail = userInput ?? string.Empty;
            Console.WriteLine("E-mail updated successfully");
            validInput = true;
        }
        else
        {
            validInput = false;
            Console.WriteLine($@"Invalid format: E-mail must contain '@' and '.'");
        }
    } while (validInput == false);
}
void editNote(ref string note)
{
    Console.Write("Please input the new note: ");
    userInput = Console.ReadLine() ?? string.Empty;
    note = userInput;
    Console.WriteLine("Note updated successfully");
}
void deleteContact(string[,] contact)
{
    Console.WriteLine("Enter the name of the contact you want to delete");
    userInput = Console.ReadLine();
    bool found = false;
    int matchCount = 0;
    if (!string.IsNullOrEmpty(userInput))
    {
        string name = userInput.ToLower();

        for (int i = 0; i < contact.GetLength(0); i++)
        {
            if (!string.IsNullOrEmpty(contact[i, 0]) && string.Equals(contact[i, 0], name, StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                matchCount++;
                Console.WriteLine($"\nIndex: {matchCount}\nName: {contact[i, 0]}");
                Console.WriteLine($"Phone Number: {contact[i, 1]}");
                Console.WriteLine($"E-Mail: {contact[i, 2]}");
                Console.WriteLine($"Note: {contact[i, 3]}");
            }
        }
        if (!found)
        {
            Console.WriteLine($"No contact matches {userInput}");

        }
        else
        {
            do
            {
                matchCount = 0;
                Console.WriteLine("Please input the index of the contact you'd like to delete");
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    if (int.TryParse(userInput, out int selectedIndex))
                    {
                        for (int i = 0; i < contact.GetLength(0); i++)
                        {
                            if (!string.IsNullOrEmpty(contact[i, 0]) && string.Equals(contact[i, 0], name, StringComparison.OrdinalIgnoreCase))
                            {
                                matchCount++;
                                if (selectedIndex == matchCount)
                                {

                                    Console.WriteLine($"\nName: {contact[i, 0]}");
                                    Console.WriteLine($"Phone Number: {contact[i, 1]}");
                                    Console.WriteLine($"E-Mail: {contact[i, 2]}");
                                    Console.WriteLine($"Note: {contact[i, 3]}");

                                    string? choice;

                                    Console.WriteLine("Please confirm if you want to delete this contact (yes/no):");
                                    choice = Console.ReadLine()?.Trim().ToLower();

                                    if (choice == "yes")
                                    {
                                        for (int j = i; j < contact.GetLength(0) - 1; j++)
                                        {
                                            for (int k = 0; k < contact.GetLength(1); k++)
                                            {
                                                contact[j, k] = contact[j + 1, k];
                                            }
                                        }
                                        for (int k = 0; k < contact.GetLength(1); k++)
                                        {
                                            contact[contact.GetLength(0) - 1, k] = "";
                                        }
                                        Console.WriteLine("Contact deleted successfully.");
                                        found = false;
                                        break;
                                    }
                                    else if (choice == "no")
                                    {
                                        Console.WriteLine("Contact deletion canceled.");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                                    }
                                }
                            }

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index, Please input a valid index number");
                }
            } while (found == true);
        }
    }
}