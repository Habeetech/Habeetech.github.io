# Automated Till Application

## Description
The Automated Till Application is a console-based program designed to handle customer orders, process transactions, and manage a till with a predefined amount of change. It provides functionality for recording transactions, giving change, and generating financial reports.

## Features
- **Customer Order Management**: Handles customer orders for drinks and cakes.
- **Transaction Processing**: Processes payments and provides change.
- **Change Management**: Ensures the till has enough money to provide change. Cancels transactions if change cannot be provided.
- **Transaction Records**: Keeps up to five records of processed transactions (customer ID and sale).
- **Financial Report**: Displays the financial report at the end of the program, showing the remaining money in the till and the profit made.
- **Till Reset**: Resets the till back to £150 after taking out the profit.

## Menu
The program offers the following menu items:

### Drinks:
- Americano (£3.49)
- Cappuccino (£4.50)
- Latte (£5.00)
- Frappuccino (£5.25)
- Tea (£2.55)

### Cakes:
- Croissant (£2.15)
- Carrot Cake (£3.89)
- Millionaire Slice (£2.75)
- Tiffin (£2.55)
- Tea Cake (£2.20)

## How It Works
1. **Start the Program**: The program initializes the till with £150 worth of change.
2. **Display Menu**: The menu of drinks and cakes is displayed to the customer.
3. **Order Processing**: Customers can order items by entering their names. Multiple items can be ordered.
4. **Payment**: Customers can pay using valid denominations (e.g., 50, 20, 10, etc.) and specify the count of each denomination (e.g., `20,2` for two £20 notes).
5. **Change**: The program calculates and provides change if possible. If the till cannot provide the required change, the transaction is canceled.
6. **Transaction Records**: Up to five transactions are recorded with customer IDs and sale amounts.
7. **Financial Report**: At the end of the program, a financial report is generated, showing the remaining money in the till and the profit made.

## Accepted Denominations
The program accepts the following denominations:
- £50, £20, £10, £5, £2, £1
- £0.50, £0.20, £0.10, £0.05, £0.02, £0.01

## Example Usage
1. **Order Items**:

   Welcome to Great Coffee. Here is our menu
   MENU
   Drinks List
   Americano              £3.49
   Cappuccino             £4.50
   Latte                  £5.00
   Frappuccino            £5.25
   Tea                    £2.55

   Cakes List
   Croissant              £2.15
   Carrot Cake            £3.89
   Millionaire Slice      £2.75
   Tiffin                 £2.55
   Tea Cake               £2.20

   Please enter the name of the item you'd like to buy or exit to quit:
   

2. **Payment**:
   
   Your item(s) cost is...£8.89
   Would you like to pay or cancel the transaction? (pay/cancel)
   pay
   Please enter the denomination (e.g 20) or/and how many of the same denomination separated by comma (e.g 20,1)
   Accepted denominations are: 50, 20, 10, 5, 2, 1, 0.50, 0.20, 0.10, 0.05, 0.02, and 0.01.


3. **Change**:
   
   Here is £1.00 (£1.00 * 1) Change, Your remaining change is £0.11.
   Here is £0.10 (£0.10 * 1) Change, Your remaining change is £0.01.
   Here is £0.01 (£0.01 * 1) Change, Your remaining change is £0.00.
   Change is fully given! Thank You
   Payment Successful. Thank You!
   

4. **Financial Report**:

   Financial Report (for admin only)
   Closing...report
   £10.00 * 5 has been taken out of the till
   Total amount taken out of the till is...£50.00, Therefore we made a total of...£50.00 profit
   Total Money in till is now...£150.00


## Error Handling
- Invalid inputs for denominations or item names are handled gracefully with appropriate error messages.
- Transactions are canceled if the till cannot provide the required change.

## Requirements
- .NET 6.0 or later
- Console application environment

## How to Run
1. Clone the repository or copy the program files to your local machine.
2. Open the project in Visual Studio or any C# IDE.
3. Build and run the program.

## License
This project is open-source and available under the MIT License.

## Contact
For questions or suggestions, feel free to reach out:
- **Author**: Habeeb Oluwanisola
- **Email**: o.h.olawaleofficial@gmail.com
- **GitHub**: [Habeetech](https://github.com/Habeetech)
- **Linkedin**: [linkedin.com/habeetech](https://www.linkedin.com/in/habeeb-oluwanisola-178029359?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=android_app)