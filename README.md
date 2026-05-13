# 📚 Library Management System (LMSWebApp)

A modern, role-based Library Management System built using ASP.NET Core MVC, designed to streamline book management, student requests, and librarian workflows with a clean and intuitive UI.

---

## 🚀 Overview

The LMSWebApp is a web-based application that digitizes core library operations and simplifies:

- Book inventory management  
- Student book requests  
- Approval and return workflows  

The system supports two main roles:
- Students  
- Librarians (Admin)  

---

## 🛠️ Tech Stack

- Framework: ASP.NET Core MVC (.NET)  
- ORM: Entity Framework Core (Code-First)  
- Frontend: Razor Views (.cshtml), Bootstrap 5, Custom CSS  
- Icons: Bootstrap Icons  

### Architecture
- 2-Tier Architecture  
- Repository Pattern  
- Dependency Injection (Scoped / Transient / Singleton)  

---

## 🧱 Database Models

### Book
- BookId (Primary Key)  
- Title  
- Category  
- Author  
- AvailableCopies  

### Student
- StudentID (Primary Key)  
- RollNo  
- FullName  
- Department  

### BookRequest
- Id (Primary Key)  
- FromDate  
- ToDate  
- RequestStatus (Pending, Approved, Rejected, Returned)  
- StudentID (Foreign Key)  
- BookId (Foreign Key)  

---

## 👥 User Roles & Features

### Student

- Authentication: Login & Registration  
- Dashboard: Overview with action cards  
- Browse Books: View available books  
- Request Book: Submit request with date range  
- My Requests: Track status (Pending, Approved, Rejected, Returned)  

---

### Librarian (Admin)

- Inventory Management: Add, update, search books  
- Request Management: View all requests  
- Approve / Reject Requests  
  - Approve → decreases available copies  
  - Return → increases available copies  

---

## 🎨 UI / UX Highlights

- Modern UI with custom CSS  
- Gradient navbar (Indigo → Teal)  
- Glassmorphism cards  
- Interactive dashboard with hover effects  
- Status badges:
  - Pending  
  - Approved  
  - Rejected  
  - Returned  
- Fully responsive design  

---

## 🧩 Layout Structure

- _Layout.cshtml → Public pages  
- _StudentLayout.cshtml → Student dashboard  
- _LibrarianLayout.cshtml → Admin dashboard  

---

## ⚙️ Key Features

- Role-based access control  
- Session-based authentication  
- Repository pattern implementation  
- Dynamic book availability tracking  
- Real-time request status updates  

---

## 📌 Future Enhancements

- JWT-based authentication  
- Analytics dashboard  
- Email/notification system  
- Mobile-first improvements  
- Dark mode  

---

## 🧑‍💻 Getting Started

### Prerequisites
- .NET SDK  
- SQL Server / LocalDB  

### Setup

git clone https://github.com/your-username/LMSWebApp.git  
cd LMSWebApp  

### Run

dotnet restore  
dotnet build  
dotnet run  

---

## 💡 Inspiration

Built to modernize traditional library systems with better UI and efficient workflows.

---

## 📬 Contact

Feel free to reach out for suggestions or feedback!
