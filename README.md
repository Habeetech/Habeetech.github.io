# Contact Management Application

This is a basic Contact Management Application built in C#. It allows users to:
- Add new contacts (name, phone number, email, and a note).
- View the list of saved contacts.
- Search for a contact by name or phone number.
- Edit contact details (name, phone number, email, or note).
- Delete a contact from the list.

## Features
- **Contact Storage**: Stores up to 10 contacts using a 2D array.
- **Input Validation**:
  - Phone numbers must be at least 10 digits and numeric.
  - Email addresses must contain `@` and `.` for basic validation.
  - Prevents empty or invalid inputs for names, phone numbers, and emails.
- **Menu-Driven Interface**: Simple and intuitive menu for navigation.
- **Error Handling**: Displays appropriate error messages for invalid inputs.
- **Case-Insensitive Search**: Allows searching for contacts without worrying about capitalization.

## How to Use
1. Run the application.
2. Use the menu options to:
   - Add a new contact.
   - View all saved contacts.
   - Search for a contact by name or phone number.
   - Edit the details of an existing contact.
   - Delete a contact from the list.
3. Enter 'exit' to quit the application.

## Menu Options
- **1: Add a New Contact**  
  Prompts the user to enter the contact's name, phone number, email, and a note. Validates the input before saving.
  
- **2: View Contact List**  
  Displays all saved contacts. If the contact list is empty, it notifies the user.

- **3: Search Contacts**  
  Allows searching for a contact by name or phone number. Displays the contact details if found.

- **4: Edit Contact Details**  
  Prompts the user to select a contact by name and edit its details (name, phone number, email, or note).

- **5: Delete a Contact**  
  Prompts the user to select a contact by name and confirm deletion.

- **Exit**  
  Exits the application.

## Future Improvements
- Expand the contact storage beyond 10 entries.
- Add authentication for secure access.
- Implement a database for persistent storage.
- Enhance input validation for international phone numbers and email formats.
- Add a graphical user interface (GUI) for better user experience.

## Requirements
- .NET SDK installed on your system.
- A C# compiler (e.g., Visual Studio or Visual Studio Code).

## How to Run
1. Clone this repository or download the source code.
2. Open the project in Visual Studio or Visual Studio Code.
3. Compile and run the application:
   - In Visual Studio Code, use the terminal and run:
     ```bash
     dotnet run
     ```
   - In Visual Studio, press `F5` to start debugging or `Ctrl + F5` to run without debugging.

## License
This project is open-source and available under the [MIT License](https://opensource.org/licenses/MIT).

## Contact
For questions or suggestions, feel free to reach out:
- **Author**: Habeeb Oluwanisola
- **Email**: o.h.olawaleofficial@gmail.com
- **GitHub**: [Habeetech](https://github.com/Habeetech)