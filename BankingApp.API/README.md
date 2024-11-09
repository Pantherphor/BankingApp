# Bank Withdrawal Processing System

## Overview

This project is designed to process bank withdrawals while ensuring the account has sufficient funds. Upon successful withdrawal, a notification is sent to the user via AWS SNS. The application uses a clean architecture to provide scalability, maintainability, and robust error handling.

## Features
- **Withdrawal Processing**: Ensures that sufficient funds are available before processing the withdrawal.
- **Notification System**: Sends notifications to bank account users via AWS SNS about the status of their withdrawals.
- **Error Handling**: Provides appropriate error responses such as "Account Not Found" and "Insufficient Funds."
- **Logging**: All events are logged for traceability and debugging purposes using Serilog.

## Architecture

The application follows **clean architecture** principles, separating concerns into multiple layers:

- **Core**: Contains the business logic and domain entities (e.g., `BankAccount`, `WithdrawalEvent`).
- **Infrastructure**: Handles the external services such as AWS SNS and logging.
- **API**: The entry point for interaction with the system, exposed via HTTP endpoints.
  
The main components include:
1. **BankAccountService**: Manages withdrawal logic and account validation.
2. **SnsNotificationService**: Handles sending withdrawal status notifications via AWS SNS.
3. **LoggingDecorator**: Provides logging for every action executed in the services.

## API Endpoints

### POST /withdraw

This endpoint processes a withdrawal request for a specific account. The account is validated for sufficient funds, and if successful, a notification is sent.

#### Request
```json
{
  "accountNumber": "1234567890",
  "amount": 1000
}
```
