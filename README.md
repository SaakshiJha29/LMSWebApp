Library Management System (LMSWebApp)

A modern, role-based Library Management System built using ASP.NET Core MVC, designed to streamline book management, student requests, and librarian workflows with a clean and intuitive UI.

🚀 Overview

The Library Management System (LMSWebApp) is a web-based application that simplifies how libraries operate by digitizing:

Book inventory management
Student book requests
Approval and return workflows

The system supports two primary roles: Students and Librarians (Admin), each with dedicated dashboards and functionalities.

🛠️ Tech Stack
Framework: ASP.NET Core MVC (.NET)
ORM: Entity Framework Core (Code-First)
Frontend: Razor Views (.cshtml), Bootstrap 5, Custom CSS
Icons: Bootstrap Icons
Architecture:
2-Tier Architecture
Repository Pattern
Dependency Injection (Scoped / Transient / Singleton)
🧱 Database Models
📘 Book
BookId (Primary Key)
Title
Category
Author
AvailableCopies
👩‍🎓 Student
StudentID (Primary Key)
RollNo
FullName
Department
🔄 BookRequest
Id (Primary Key)
FromDate
ToDate
RequestStatus (Pending, Approved, Rejected, Returned)
StudentID (Foreign Key)
BookId (Foreign Key)
👥 User Roles & Features
🎓 Student
🔐 Authentication
Login & Registration system
📊 Dashboard
Quick overview with action cards
📚 Browse Books
View all available books and stock status
📝 Request Book
Submit book request with date range
📌 My Requests
Track request status:
Pending
Approved
Rejected
Returned
📖 Librarian (Admin)
📦 Inventory Management
Add, update, view, and search books
📊 Request Management
View all student requests
✅ Approve / Reject Requests
Approve → decreases available copies
Return → increases available copies
🎨 UI / UX Highlights
✨ Modern, premium UI with custom CSS
🎨 Gradient-based navbar (Indigo → Teal)
🧊 Glassmorphism cards for forms and dashboards
📊 Interactive dashboard cards with hover effects
🏷️ Custom status badges:
🟡 Pending
🟢 Approved
🔴 Rejected
🔵 Returned
📱 Responsive layout using Bootstrap 5
🧩 Layout Structure
_Layout.cshtml → Public pages (Landing)
_StudentLayout.cshtml → Student dashboard
_LibrarianLayout.cshtml → Admin dashboard
⚙️ Key Features
Role-based access control (Student / Admin)
Session-based authentication
Clean separation of concerns using Repository Pattern
Dynamic book availability tracking
Real-time request status updates
📌 Future Enhancements
🔒 JWT-based authentication
📊 Analytics dashboard for librarians
🔔 Email/notification system
📱 Mobile-first UI improvements
🌙 Dark mode support
🧑‍💻 Getting Started
Prerequisites
.NET SDK installed
SQL Server / LocalDB
Setup
git clone https://github.com/your-username/LMSWebApp.git
cd LMSWebApp
Run the Application
dotnet restore
dotnet build
dotnet run
💡 Inspiration

Built to transform traditional library systems into a modern, user-friendly digital experience with clean UI and efficient workflows.

📬 Contact

If you have suggestions or feedback, feel free to reach out!
