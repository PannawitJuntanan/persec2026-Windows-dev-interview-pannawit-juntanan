
# persec2026-Windows-dev-interview-pannawit-juntanan

  

This repository contains the technical assessment for the Windows Developer position at **Persec**. All applications are developed using **.NET 10**.

  

## 📂 Folder Structure

  

The solution is divided into source code (`src`) and unit tests (`tests`):


```text

├── src/

│ ├── App01/ # Source code for Task 01

│ ├── App02/ # Source code for Task 02

│ ├── App03/ # Source code for Task 03

│ ├── App04/ # Source code for Task 04

│ ├── App05/ # Source code for Task 05

│ └── App06/ # Source code for Task 06

└── tests/

├── App01Test/ # Tests for App 01

├── App02Test/ # Tests for App 02

├── App03Test/ # Tests for App 03

├── App04.Tests/ # Tests for App 04

├── App05Tests/ # Tests for App 05

└── App06Tests/ # Tests for App 06

  ```

## 🚀 Execution Instructions

Each project is a standalone Console Application. You can run them using the .NET CLI.

Running an Application

Navigate to the desired project folder and use dotnet run:
```bash
cd src/App01 
dotnet run
```
### Running Tests

To verify the logic, you can run the tests for each application:
```bash
cd tests/App01Test 
dotnet test
```