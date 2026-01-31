# Touch Bistro Clone

ASP.NET Core MVC application mimicking the TouchBistro POS system.

## Features

- **Interactive Menu**: Browse menu items by category (Mains, Sides, Drinks).
- **Table Management**: Visual representation of table status (Occupied/Free) and detailed order views.
- **Order Processing**: Real-time calculation of order totals including tax.
- **Responsive Design**: Optimized for different screen sizes.

## Project Structure

```text
Touch_Bistro_App/
│
├── Controllers/
│   ├── MenuController.cs
│   ├── TablesController.cs
│   ├── OrdersController.cs
│   └── HomeController.cs
│
├── Models/
│   ├── MenuItem.cs
│   ├── Table.cs
│   ├── Order.cs
│   └── OrderItem.cs
│
├── Views/
│   ├── Menu/
│   ├── Tables/
│   ├── Orders/
│   └── Home/
│
├── Data/ (Persistence Layer)
│   ├── TouchBistroContext.cs
│   ├── DbInitializer.cs
│   └── Migrations/
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── screenshots/
│
├── appsettings.json
├── Program.cs
├── Touch_Bistro_App.csproj
└── README.md
```

## Tech Stack

- **Framework**: ASP.NET Core MVC (.NET 10.0)
- **Database**: Entity Framework Core with SQLite
- **Styling**: Custom CSS & Bootstrap
- **Tools**: Visual Studio / VS Code

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/nicolefagan54/Touch_Bistro_App.git
   cd Touch_Bistro_App
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```
   The application will be available at `http://localhost:5251` (or the port specified in the output).

## Screenshots

### Menu View

![Menu View](wwwroot/screenshots/menu_view.png)

### Tables View

![Tables View](wwwroot/screenshots/tables_view.png)

### Order Details View

![Order Details View](wwwroot/screenshots/order_details_view.png)

