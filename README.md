# Library

#### A web application that allows a user (librarian) to manage authors and books.

#### By Brian Scherner

## Technologies Used

* C#
* .NET
* ASP.NET MVC
* MySQL
* EF Core
* EF Migrations

## Description

This application presents users with a splash page containing lists for books and authors. Users can create, edit, and delete books, as well as add multiple authors, search for books by title/author, and checkout books. Users can also create authors, view their details, and add multiple books to an author.

Users can also create patrons and list their details. Each patron contains a history of all the books they have checked out and when the book is overdue. Users can navigate to a link to view overdue books, which list each overdue book with the name of the patron who checked them out.

## Setup Instructions

### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-0-lessons-1-5-getting-started-with-c/3-0-0-01-welcome-to-c).

### Set Up and Run Project

1. Select the green button that says `Code`, and clone this repository to your desktop.
2. Open the terminal and navigate to this project's production directory called `Library`.
3. Within the `Library` directory, create a new file called `appsettings.json`.
4. Within `appsettings.json`, put in the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL. For the LearnHowToProgram.com lessons, always assume the `uid` is `root` and the `pwd` is `epicodus`. You can use the database name below, or name it whatever you like.

```json
{
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=library_with_auth;uid=root;pwd=epicodus;"
    }
}
```

5. Open your terminal to the production directory called `Library` and run `dotnet ef database update`. This will create the database using the migrations located inside this project's `Migrations` folder. You should now see the database in your MySQL workbench.
    * If you need to create your own migration, run the command `dotnet ef migrations add MigrationName`. The migration name should be specific and in UpperCamelCaseFormat.
6. Within the production directory called `Library`, run `dotnet watch run` in the command line to start the project in development mode with a watcher.
7. Open the browser to [https://localhost:5001](https://localhost:5001). If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this LearnHowToProgram.com lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://old.learnhowtoprogram.com/fidgetech-3-c-and-net/3-2-basic-web-applications/3-2-0-17-redirecting-to-https-and-issuing-a-security-certificate).

## Known Bugs

All of the features in the application are functional. However, I currently do not have a way to allow different users to do different things. Currently, a user can create an account and log in as a librarian or patron. There is no differentation between the two in terms of what they can access and what they cannot yet, though.

## License

MIT

Copyright(c) 2023 Brian Scherner