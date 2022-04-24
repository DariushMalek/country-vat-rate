# country-vat-rate
Country VAT Rate Calculator

## Front-End Stacks
 * Angular 13.3.4
 * Angular Material 13.3.4

## Back-End Stacks
 * .Net 6
 * Microsoft.EntityFrameworkCore 6
 * SQLite
 * AutoFixture
 * xunit
 * NSubstitute
 * FluentAssertions
 * Microsoft.AspNetCore.Mvc.Testing
 * OpenApi


There are two ways to get countries vat infromation:
 * InMemory Data: Load data from memory. To use this featue please check "InMemory Data" checkbox in main page
 * Load Data From Api: Load data from Api and database. To use this feature, first run backend api source and then uncheck "InMemory Data" checkbox in main page.

 Sources folder:
 * ApiSource: Asp.Net Core 6 Web Api project. To load data via APIs please make sure this project is running on http://localhost:5035.
 * ClientApp: Front-end project with Angular 13 
