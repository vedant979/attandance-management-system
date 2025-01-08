---

# Attendance Management System

This is a robust .NET-based console application designed for managing attendance in an organization. It includes features for authentication, authorization, and hierarchical management of users, along with detailed attendance tracking and reporting. The system leverages SQLite for data storage and Redis for caching frequently accessed data to improve performance.

---

## 🚀 Features

- **User Authentication & Authorization**:  
  Secure login with role-based access control (RBAC) for admin, managers, and employees.  
- **Hierarchical Management**:  
  Role hierarchy for managing attendance records across teams or departments.  
- **Attendance Tracking**:  
  Track employee check-in, check-out times, and total hours worked.  
- **Customizable Leave Management**:  
  Manage employee leaves with approval workflows.  
- **Reporting**:  
  Generate detailed attendance and leave reports.  
- **Caching**:  
  Redis caching for frequently queried data to improve performance.

---

## 🛠️ Tech Stack

- **Programming Language**: .NET Framework/Core  
- **Database**: SQLite  
- **Caching**: Redis  
- **Authentication & Authorization**: Role-based access control (RBAC)  
- **APIs**: REST APIs for interaction with attendance and user data  

---

## 📂 Project Structure

```
attendance-management-system/
├── ER/                     // Entity-Relationship (ER) diagrams
├── Project/                // Main project folder with source code
│   ├── Program.cs          // Main entry point for the console application
│   ├── Models/             // Models for users, roles, and attendance records
│   ├── Services/           // Authentication, authorization, and attendance services
│   ├── Repositories/       // Data access layer for SQLite
│   ├── Controllers/        // Business logic controllers
│   └── appsettings.json    // Configuration file (API keys, Redis, DB connection)
├── Project.Tests/          // Unit and integration tests
│   └── AttendanceServiceTests.cs
├── Project.sln             // Solution file for the .NET project
├── README.md               // Documentation for the project
└── .DS_Store               // System file (can be ignored)
```

---

## 🔧 Setup Instructions

### Prerequisites

1. Install [.NET SDK](https://dotnet.microsoft.com/download)  
2. Install [Redis](https://redis.io/docs/getting-started/)  
3. Ensure SQLite is available on your system  

### Steps

1. Clone the repository:  
   ```bash
   git clone https://github.com/vedant979/attendance-management-system.git
   cd attendance-management-system
   ```

2. Configure the application:  
   Update `appsettings.json` with your API keys, Redis, and SQLite connection details.

3. Restore dependencies:  
   ```bash
   dotnet restore
   ```

4. Apply database migrations:  
   ```bash
   dotnet ef database update
   ```

5. Run the application:  
   ```bash
   dotnet run
   ```

---

## 🌐 API Integration

The system uses REST APIs for managing attendance records and user roles. Update the necessary endpoints in `appsettings.json` or in the respective service files.

---

## 🗄️ Caching with Redis

- Redis is used to cache user roles, frequently accessed attendance records, and reports.  
- Cache invalidation occurs automatically on data updates to ensure consistency.

---

## 🗃️ Database Schema

### **Users Table**
- `Id` (int, Primary Key)  
- `Name` (string)  
- `Email` (string, unique)  
- `PasswordHash` (string)  
- `Role` (string)  

### **Attendance Table**
- `Id` (int, Primary Key)  
- `UserId` (int, Foreign Key)  
- `CheckIn` (datetime)  
- `CheckOut` (datetime)  
- `HoursWorked` (float)  

### **Roles Table**
- `Id` (int, Primary Key)  
- `RoleName` (string)  
- `Permissions` (string)  

---

## 🤝 Contributing

1. Fork the repository.  
2. Create a new branch:  
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes:  
   ```bash
   git commit -m "Description of changes"
   ```
4. Push to the branch:  
   ```bash
   git push origin feature-name
   ```
5. Open a pull request.

---

## 📧 Contact

For any inquiries, feel free to reach out:  
**GitHub**: [vedant979](https://github.com/vedant979)  

--- 

Let me know if you'd like to refine this further!
