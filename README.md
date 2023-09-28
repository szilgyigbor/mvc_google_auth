# MVCGoogleAuth - A News Management Application

## Overview

MVCGoogleAuth is a C# ASP.NET MVC application designed for news management. This project serves both as an API and a web application where users can perform CRUD (Create, Read, Update, Delete) operations on news items.

## Features

- **Google Authentication**: The application utilizes Google's OAuth 2.0 mechanism for authentication. Only authenticated users can manage news items.
  
- **Web Interface**: Includes a Manage News page at `https://localhost:7108/ManageNews` where authenticated users can manipulate news.

- **API Access**: The application exposes its functionalities through a RESTful API, which is also documented using Swagger. API docs can be accessed at `https://localhost:7108/swagger/index.html`.

- **Unit Testing**: The project includes a test suite named `MVCGoogleAuth.Tests` that contains tests for the ApiController.

## Prerequisites

To get the application up and running, you'll need:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/)

## Getting Started

1. **Clone the Repository**
  
    \`\`\`
    git clone https://github.com/your-repository-url.git
    \`\`\`

2. **Set up Google API keys**

    - Visit [Google API Console](https://console.developers.google.com/) to generate your API keys.
  
    - Create a `.env` file in the `MVCGoogleAuth` folder and add your API keys like so:
      
      GOOGLE_CLIENT_ID=your-google-client-id
      
      GOOGLE_CLIENT_SECRET=your-google-client-secret

3. **Open and Build the Project**

    - Open the solution file in Visual Studio.
  
    - Dependencies will be restored automatically. If prompted to accept some NuGet packages, click "Accept."

4. **Run the Application**

    - You can run the application using `Ctrl + F5` or by clicking the green play button in Visual Studio.

## Testing

To run the unit tests, navigate to the `MVCGoogleAuth.Tests` project and execute the tests.

## Disabling Google Authentication

If for some reason you want to bypass Google Authentication, simply remove the `[Authorize]` attribute in the `ApiController.cs` file on line 11.

## Contributing

Feel free to fork this project, open a pull request or an issue.

## License

This project is licensed under the MIT License.
