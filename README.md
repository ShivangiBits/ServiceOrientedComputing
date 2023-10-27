# ServiceOrientedComputing
Assignment for SOC.
The Bookstore Management System is a prime example of a microservices architecture enhanced by the utilization of an API Gateway and robust JWT token-based authentication. This system is designed to efficiently manage bookstore operations while showcasing the following key elements of microservices:

   ## Microservices Components:
   
   ### UserManagement Service : 
   Responsible for user registration, authentication, and account management. Also, Ensures secure user authentication using JWT tokens.
   ### BookManagement Service: 
   Manages the bookstore's product catalog, inventory, and pricing.
   ### OrderManagement Service: 
   Handles order processing, shopping cart functionalities, and order fulfillment.


   ## API Gateway:
   
   Acts as the central entry point for clients, channeling and securing interactions with the microservices.
   Routes client requests to the appropriate microservices based on their endpoints.
   Manages user authentication and authorization.
   JWT Token Authentication:
   
   During user registration or login, the User Service generates a JWT token.
   This token is provided to the client upon successful authentication.
   The client includes the JWT token in request headers for subsequent interactions with the API Gateway.
   The API Gateway intercepts incoming requests, validates the JWT tokens, and forwards the requests to the relevant microservices.
   This microservices architecture offers several advantages, including scalability, maintainability, and security:

   ## Scalability: 
   Each microservice can be independently scaled to meet increased demand, ensuring optimal performance during peak times.
   
   ## Maintainability: 
   Updates and changes to individual microservices have minimal impact on the overall system, simplifying maintenance and development.
   
   ## Security: 
   Authentication and authorization are centralized in the API Gateway, providing a unified and secure access point to the system.

In summary, the Bookstore Management System exemplifies the power of microservices, an API Gateway, and JWT token authentication in modern software architecture. This approach enhances scalability, maintainability, and security, making it a suitable model for businesses seeking adaptable and secure systems.

# Bookstore Management System

The Bookstore Management System is a web-based application designed to manage a bookstore's inventory, process customer orders, and facilitate the smooth operation of a bookstore business. This README provides an overview of the project, its features, and instructions for setting up and running the system.

## Table of Contents
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [Usage](#usage)
- [License](#license)

## Features

The Bookstore Management System includes the following features:
- User registration and authentication.
- Inventory management, including adding, updating, and removing books.
- Order processing for customers, including shopping cart functionality.
- User roles (admin and customer) with different privileges.
- In-memory database for development and testing purposes.
- Responsive and user-friendly web interface.

## Prerequisites

Before you begin, ensure you have met the following requirements:
- .NET Core SDK
- Visual Studio or Visual Studio Code (or your preferred code editor)
- Web browser

## Getting Started

To get the Bookstore Management System up and running, follow these steps:

1. Clone the repository:
   ```bash
   git clone ...

1.  Navigate to the project directory:
   cd bookstore-management
2.  Build the application:
   dotnet build
3.  Run the application:
   dotnet run
4.  Open your web browser and access the application at https://localhost:7056 (or as configured).

# Configuration
Database Configuration: Update the database connection string in appsettings.json to use your preferred database system (e.g., SQL Server).
Authentication Configuration: Configure authentication options in Program.cs for production use.

# Usage
Register an admin or customer account to log in and start using the application.
Manage books in the inventory, add them to the shopping cart, and process orders.
Explore the user interface to familiarize yourself with the application's features.

# License
This project is licensed under the MIT License.

This README template provides a basic structure that you can expand upon to include more specific details about your project, such as system architecture, data models, and additional setup options. Remember to keep the README updated as your project evolves and include any information that helps users, contributors, and maintainers understand and interact with your application.



