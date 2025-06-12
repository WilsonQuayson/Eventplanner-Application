# Eventplanner-Application 🗓️

A backend API for planning and managing events. Built with **ASP.NET Core Web API**, this project supports secure user authentication, authorization, and basic event CRUD operations. A **Next.js frontend** will be added in the future.

---

## 🚀 Features

- ✅ User registration and login
- ✅ JWT-based authentication
- ✅ Secure endpoints for authorized users
- ✅ Create, read, update, and delete events
- ✅ Swagger UI for API testing
- 🔒 Protected routes with role-based access planned
- 🌱 Scalable structure for future features like:
  - Inviting users to events
  - Event RSVPs and reminders
  - Calendar integrations

---

## 🛠 Tech Stack

| Layer       | Tech                          |
|-------------|-------------------------------|
| Backend     | ASP.NET Core Web API          |
| ORM         | Entity Framework Core (EFCore)|
| Auth        | JWT, ASP.NET Core Identity    |
| Docs        | Swagger / Swashbuckle         |
| Database    | SQL Server                    |
| Frontend    | (Planned) Next.js + React     |

---

## 🔐 Authentication

All API endpoints (except `/register` and `/login`) require a valid JWT token in the `Authorization` header:

```
Authorization: Bearer <your_token_here>
```

---

## 📦 Setup Instructions

### 1. Clone the repo

```bash
git clone https://github.com/yourusername/Eventplanner-Application.git
cd Eventplanner-Application
```

### 2. Configure local environment

Create your own `appsettings.Development.json` in the root directory (it's excluded from Git):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<server-name>;Database=<database-name>;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "JwtConfig": {
    "ValidAudiences": "https://localhost:<port ur backend runs on>",
    "ValidIssuer": "https://localhost:<port ur backend runs on>",
    "Secret": "<your-super-secret-jwt-key>"
  }
}
```

Make sure you:
- Have SQL Server running
- Replace the connection string if needed
- Set your own secure JWT secret

### 3. Run the app

Using Visual Studio:
- Press `F5` or click `Run` to launch the API.
- Swagger UI will open at: `https://localhost:7173/swagger/index.html`

---

## 📮 API Endpoints (Examples)

| Method | Endpoint        | Auth Required | Description           |
|--------|-----------------|----------------|-----------------------|
| POST   | `/register`     | ❌             | Register a new user   |
| POST   | `/login`        | ❌             | Login and get JWT     |
| GET    | `/events`       | ✅             | Get all events        |
| POST   | `/events`       | ✅             | Create a new event    |
| PUT    | `/events/{id}`  | ✅             | Update an event       |
| DELETE | `/events/{id}`  | ✅             | Delete an event       |

---

## 🧪 Testing with Swagger or Postman

- Use Swagger UI to test endpoints. After logging in, click "Authorize" and paste your JWT token.
- For Postman, include the `Authorization: Bearer <token>` header in protected requests.

---

## 🗂 Future Plans

- ✅ Backend CRUD API
- ⏳ Frontend in Next.js
- ⏳ Invite other users to events
- ⏳ Deployment (Vercel + Azure, maybe)
- ⏳ CI/CD integration

---

## 📄 License

MIT - Feel free to fork and use.

---

## 🙋‍♂️ Author

Developed by Wilson Quayson as a hands-on portfolio project.
