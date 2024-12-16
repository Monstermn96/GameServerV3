# GameServerV3

### Purpose

This project, _GameServerV3_, is my third attempt at building a server in C#. The primary goals are:

- **Learning C#:** Improving my understanding of C# concepts like Dependency Injection (DI), SOLID principles, and asynchronous programming.
- **Refactoring:** Avoiding monolithic structures and properly splitting responsibilities into clean, maintainable components.
- **Having Fun:** Enjoying the development process without a defined end goal. The focus is on learning as I go and iterating based on experience.

---

### Current Features

- **Separation of Concerns:**  
  Components have been split into distinct classes and interfaces:

  - `GameServerForm`: Manages the UI and delegates server logic to other classes.
  - `NetworkManager`: Handles the server lifecycle (start, stop) and accepts client connections.
  - `ClientHandler`: Manages individual client connections and their communication.
  - `Logger`: Provides centralized logging for both the console and UI.

- **Dependency Injection (DI):**  
  The project uses Microsoft.Extensions.DependencyInjection to manage dependencies, ensuring flexibility and testability.

- **Asynchronous Client Handling:**  
  Clients are managed concurrently using `async/await` to ensure smooth server performance.

---

### Project Structure

```
GameServerV3/
│-- Interfaces/
│   │-- IClientHandler.cs      # Interface for handling individual clients
│   │-- INetworkManager.cs     # Interface for managing the server lifecycle
│   │-- ILogger.cs             # Interface for logging
│
│-- Utils/
│   │-- ClientHandler.cs       # Handles client-specific logic
│   │-- NetworkManager.cs      # Accepts clients and delegates to ClientHandler
│   │-- Logger.cs              # Logs messages to the console and UI
│
│-- GameServerForm.cs          # UI layer to start/stop the server
│-- Program.cs                 # Entry point and DI setup
│-- GameServerForm.Designer.cs # UI components layout
│
│-- README.md                  # Project documentation
```

---

### Key Technologies

- **C#**
- **.NET Core / .NET Framework**
- **Microsoft.Extensions.DependencyInjection** (for DI)
- **TCP Communication** (`System.Net.Sockets`)
- **Asynchronous Programming** (`async/await`)
- **WinForms** (for UI)

---

### Running the Server

1. Clone the repository:

   ```bash
   git clone <repository-url>
   cd GameServerV3
   ```

2. Build the project using Visual Studio or the .NET CLI:

   ```bash
   dotnet build
   ```

3. Run the project:

   ```bash
   dotnet run
   ```

4. Use the UI to **start** or **stop** the server.

---

### Learning Process

This project is built iteratively:

- Early attempts were monolithic, which led to challenges with scalability and maintainability.
- The current version follows a modular architecture, leveraging **interfaces**, **DI**, and **SOLID principles**.
- There’s no fixed end goal—this project evolves as I learn new concepts and experiment with ideas.

---

### Future Goals

- Add unit tests to ensure components work as expected.
- Implement additional server features like client authentication, messaging, or a command system.
- Explore scalability improvements (e.g., multi-threading, load balancing).

---

### Notes

This project is a work in progress and primarily for learning purposes. Feedback and suggestions are always welcome!
