# CPH Half Ticket Notifier

This .NET 8 C# console application is a practical project developed to address a personal need for securing a ticket on the CPH Half Marathon resale platform. The program implements a naive polling approach, which involves scraping the website at a fixed interval to check the availability of tickets. Upon detecting an available ticket, the application sends a notification via Telegram, ensuring that the user is promptly informed and can proceed to purchase the ticket.

This is only possible as the resale platform is a public page without any user confirmation (eg. no captcha's or bearer tokens required) upon making requests to the page.

<p align="center">
  <img src="https://github.com/user-attachments/assets/cf400383-7d70-4f61-8776-26c97a8ae089" alt="notification" width="45%" />
  <img src="https://github.com/user-attachments/assets/0d1789b9-a60a-4731-8186-8c1b9e90d8ce" alt="chat" width="45%" />
</p>

## Features

- **Naive Polling Mechanism**: The application scrapes the [CPH Half Marathon resale platform](https://secure.onreg.com/onreg2/bibexchange/?eventid=6277) at regular intervals to monitor ticket availability.
- **Telegram Notifications**: Upon detecting an available ticket, the application sends an immediate notification to the user's Telegram account, including a direct link to the resale platform. This allows the user to act quickly and secure the ticket.

- **Console-Based Interface**: Simple and lightweight console-based application, easy to run and monitor.
- **Customizable Polling Interval**: The polling interval can be adjusted according to the user's preferences, balancing the frequency of checks with resource consumption.

## Motivation

As I was in need of a ticket for the CPH Half Marathon, I developed this program to automate the process of monitoring the resale platform. Instead of manually refreshing the website, the application continuously checks for available tickets and notifies me when one is found. The choice of Telegram for notifications was driven by its reliability and the convenience of receiving alerts directly on my phone.

## Ideal Enhancements

While the current implementation is functional and effective, an ideal solution would automate the purchase process entirely. Instead of merely notifying the user, the application could be enhanced to automatically click the "Buy" button upon detecting an available ticket. However, this approach presents several challenges:

- **Selector Knowledge**: Automating the purchase process requires precise knowledge of the HTML selectors for the "Buy" button.
- **Reservation Confirmation**: There may be additional steps required to confirm the ticket being reserved after clicking "Buy," which cannot be fully understood until a ticket has been required.

These unknowns led to the decision to notify the user instead of attempting to achieve ticket reservation programmatically.

## Prerequisites

- **.NET 8 SDK**: Ensure that the .NET 8 SDK is installed on your system to build and run the application.
- **Telegram Bot API**: Set up a Telegram bot and obtain an API token for sending notifications. Detailed instructions can be found in the [Telegram Bot API documentation](https://core.telegram.org/bots/api).

## Installation and Usage

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/rasmusloje/cph-half-notifier.git
   cd cph-half-notifier

2. **Configure the Application**:
   - Update the `appsettings.json` or environment variables with your Telegram Bot API token and the chat ID where you want to receive notifications.
   - Set the desired polling interval in the configuration.

3. **Build the Application**:
   ```bash
   dotnet build

4. **Run the Application**:
   ```bash
   dotnet run

## Future Work

Potential areas for future development include:

- Implementing an automated purchase mechanism by identifying and interacting with the "Buy" button on the resale platform.
- Enhancing the error handling and robustness of the scraping mechanism.
- Introducing a graphical user interface (GUI) for easier configuration and monitoring.

## Contributing

Contributions to this project are welcome. Please fork the repository and submit a pull request with your proposed changes.

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/rasmusloje/cph-half-notifier/blob/main/license.txt) file for more details.

---
