string[,] bookList = new string[5, 2];
int bookCount = 0;
static void AddBook(string[,] books)
{
    Console.WriteLine("Enter the title of the book");
    string? userInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(userInput))
    {
        if (books[books.GetLength(0) - 1, 0] != null)
        {
            Console.WriteLine("No more than five books can be added");
        }
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i, 0] == null || books[i, 0] == "")
            {
                books[i, 0] = userInput;
                break;
            }

        }
        
    }
    else
    {
        Console.WriteLine("Book title cannot be empty, Please enter a book title.");
    }
}
int ReturnBook(string[,] books, ref int count)
{
    string searchResult = FindBook(books);
    if (searchResult == "")
    {
        Console.WriteLine("The title" + searchResult + "is not present in the collection");
    }
    else
    {
        bool unChecked = false;

        for (int i = 0; i < books.GetLength(0); i++)
        {
            if (searchResult == books[i, 0] && string.IsNullOrEmpty(books[i, 1]))
            {
                unChecked = true;
                Console.WriteLine("The title " + searchResult + " isn't borrowed");
                return count;
            }
        }
        if (!unChecked)
        {
            Console.WriteLine("Would you like to return this book?");
            string? userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput))
            {
                if (userInput.ToLower() == "yes")
                {
                    for (int i = 0; i < books.GetLength(0); i++)
                    {
                        if (searchResult == books[i, 0])
                        {
                            books[i, 1] = "";
                            count -= 1;
                        }
                    }
                    return count;
                }
                else if (userInput.ToLower() == "no")
                {
                    return count;
                }
            }
        }
    }
    return count;
}
int BorrowBook(string[,] books, ref int count)
{
    string searchResult = FindBook(books);

    if (searchResult == "")
    {
        Console.WriteLine("The title" + searchResult + "is not present in the collection");
        return count;
    }
    else
    {
        if (count >= 3)
        {
            Console.WriteLine("Maximum book is borrowed already");
            return count;
        }
        for (int i = 0; i < books.GetLength(0); i++)
        {
            if (searchResult == books[i, 0] && books[i, 1] == "Checked")
            {
                Console.WriteLine("The title " + searchResult + " is already borrowed");
                return count;
            }
        }
        Console.WriteLine("Would you like to borrow this book?");
        string? userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            if (userInput.ToLower() == "yes")
            {
                for (int i = 0; i < books.GetLength(0); i++)
                {
                    if (searchResult == books[i, 0])
                    {
                        books[i, 1] = "Checked";
                        count += 1;
                    }
                }
                return count;
            }
            else if (userInput.ToLower() == "no")
            {
                return count;
            }
        }
        else
        {
            return BorrowBook(bookList, ref bookCount);
        }
    }
    return count;
}
static void RemoveBook(string[,] books)
{
    Console.WriteLine("Enter the title of the book you want to remove");
    string? userInput = Console.ReadLine();
    bool found = false;
    if (!string.IsNullOrEmpty(userInput))
    {
        for (int i = 0; i < books.GetLength(0); i++)
        {
            if (string.Equals(userInput, books[i, 0], StringComparison.OrdinalIgnoreCase))
            {
                books[i, 0] = "";
                books[i, 1] = "";
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine(userInput + "is not a valid book title in the list");
        }
    }

}

static void SearchBook(string[,] books)
{
    string searchResult = FindBook(books);

    if (searchResult == "")
    {
        Console.WriteLine("The title " + searchResult + " is not present in the collection");
    }
    else
    {
        Console.WriteLine("The title " + searchResult + " is available in the collection");
    }
}
static string FindBook(string[,] books)
{
    Console.WriteLine("Enter the book title");
    string? userInput = Console.ReadLine();
    bool found = false;
    if (!string.IsNullOrEmpty(userInput))
    {
        for (int i = 0; i < books.GetLength(0); i++)
        {
            if (string.Equals(userInput, books[i, 0], StringComparison.OrdinalIgnoreCase))
            {
                found = true;
                return books[i, 0];
            }
        }
        if (!found)
        {
            return "";
        }
    }
    return "";
}

void DisplayBooks(string[,] books)
{
    for (int i = 0; i < books.GetLength(0); i++)
    {
        if (!string.IsNullOrEmpty(books[i, 0]))
        {
            Console.WriteLine(books[i, 0]);
        }
    }
}
bool exit = false;
do
{
    Console.WriteLine("Please enter:\n- add\n- display\n- search\n- borrow\n- return\n- remove\n- exit to terminate");
    string? choice = Console.ReadLine();
    if (!string.IsNullOrEmpty(choice))
    {
        choice.ToLower().Trim();
        switch (choice)
        {
            case "add":
                AddBook(bookList);
                break;

            case "remove":
                RemoveBook(bookList);
                break;

            case "display":
                DisplayBooks(bookList);
                break;

            case "search":
                SearchBook(bookList);
                break;

            case "borrow":
                BorrowBook(bookList, ref bookCount);
                break;

            case "return":
                ReturnBook(bookList, ref bookCount);
                break;

            case "exit":
                exit = true;
                break;

            default:
                break;
        }
    }
} while (!exit);