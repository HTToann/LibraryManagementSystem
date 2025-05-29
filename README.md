# LibraryManagementSystem

A multi-layered library management system designed for tracking, managing, and operating a library's resources. This project follows a classic .NET/C# layered architecture with distinct separation of concerns.

## Features

- Book and resource management
- Borrowing and returning operations
- User and staff management
- Business rules encapsulated in a dedicated logic layer
- Modular architecture for easy extension and maintenance

## Project Structure

```
LibraryManagementSystem/
├── BusinessLayer/         # Business logic and service classes
├── DataLayer/             # Data access layer (repositories, database)
├── DTOs/                  # Data Transfer Objects
├── LibrarySystem/         # Likely entry point and main application code
├── PresentationLayer/     # UI components (Windows Forms, WPF, or similar)
├── Shared/                # Common/shared utilities and definitions
├── .vs/                   # Visual Studio settings
├── .gitignore
├── README.md
├── New Microsoft Word Document.docx  # Project documentation (optional)
└── ...
```
[View all files in the repository →](https://github.com/HTToann/LibraryManagementSystem/tree/main/)

## Getting Started

### Prerequisites

- .NET Framework (or .NET Core/5/6 if applicable)
- Visual Studio (recommended) or any compatible C# IDE

### Setup Instructions

1. **Clone the repository**
    ```sh
    git clone https://github.com/HTToann/LibraryManagementSystem.git
    cd LibraryManagementSystem
    ```

2. **Open the Solution**
    - Open the folder in Visual Studio.
    - Restore NuGet packages if prompted.

3. **Build and Run**
    - Build the solution.
    - Run the application from the main project (typically inside `LibrarySystem/` or `PresentationLayer/`).

4. **Configuration**
    - Update any local database connections or app settings as needed for your environment.

## Contribution

Contributions, suggestions, and bug reports are welcome. Please fork the repository and submit a pull request.

## License

This project is for academic or demonstration purposes. License details can be added here.

---

*Note: The above file listing may be incomplete. For a full, up-to-date list, view the repository contents on GitHub: [HTToann/LibraryManagementSystem](https://github.com/HTToann/LibraryManagementSystem/tree/main/)*
