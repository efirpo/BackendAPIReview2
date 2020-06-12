# _Pet Shelter API_

#### Epicodus Project for backend API review, 6/12/20

#### by Ethan Firpo

## Description

A simple API created to test knowledge of backend API functions and ability to include further functions like Swagger API documentation, token authentication, pagination, and other tools available in the development of APIs.

## Setup

1. Clone this repository from GitHub.
2. Open the downloaded directory in a text editor of your choice (Atom, VSCode, etc).
3. If you do not have MySQL Community Server installed, go to https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql and follow along with the instructions for your operating system.
4. In your terminal, navigate to the main project directory("`PetShelter/`"), and create an appsettings file by using the command `touch appsettings.json`.
5. Populate `appsettings.json` with the following code:
  `{
  "Logging": {  
    "LogLevel": {  
      "Default": "Warning"  
    }  
  },  
  "AllowedHosts": "*",  
  "ConnectionStrings": {  
    "DefaultConnection": "Server=localhost;Port=3306;database=pet_shelter;uid=root;pwd=[YourPasswordHere];"  
  }  
  }`  
  6. Replace `[YourPasswordHere]` within `appsettings.json` with the password you created for MySql in step 3.
  7. While still navigated to the `PetShelter` directory, type `dotnet ef database update` in your terminal to create and populate a new pet_shelter database.
  8. While still navigated to the `PetShelter/` directory, run the program by typing the command `dotnet run` in your terminal.

  ## Technology

  #### C#
  #### .NET Core
  #### Entity Core Framework
  #### ASP.NET Core
  #### SQL
  #### Swagger

  ## Legal

#### MIT License

### Copyright (c) 2020 Ethan Alexander Firpo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
