# SWE30003-ObjectDesignImplementation-Books
![Static Badge](https://img.shields.io/badge/.NET-8-blue)
![GitHub License](https://img.shields.io/github/license/olibSwin/SWE30003-ObjectDesignImplementation-Books)


WPF implementation of My Favourite books, bookstore website for the Swinburne University of Technology unit SWE30003 - Software Architectures and Design.

## Getting Started
### Requirements
- Windows 10/11
- Visual Studio 2022/2026 with .NET desktop development workload
- .NET 8 SDK

### Running
1. Clone the repository
2. Open `./FavouriteBooks/Services/BookCatalogue.cs`
3. Uncomment line 16 (`//if(_books.Count == 0){SeedData();}`)
4. Run `dotnet run` in the `FavouriteBooks` folder
5. Once the program has opened, close it and re-comment line 16 of `./FavouriteBooks/Services/BookCatalogue.cs`
6. Run `dotnet run` in the `FavouriteBooks` folder again

## Usage
On the Catalogue page, the book catalogue can be viewed and added to the shopping cart. Users must log in before they can access the cart. Once logged in, users can view and manage their cart, as well as go to the checkout page. From the checkout page, a mock purchase can be made. The account page allows users to edit account information, and view their order history.