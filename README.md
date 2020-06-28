# Novia Financial Recruitment Test - ASP.Net Developer

This repo contains an ASP.Net Core project that defines an API for interacting with some fake funds.  The funds are stored in a JSON file at the path `\DataFiles\funds.json`.

There are three technical debt items for you to remedy and then a user story for you to complete.

If you want to test the API as you go you can use a browser or Powershell:

``` powershell
Invoke-RestMethod "http://localhost:5000/"
```

Feel free to use the internet and to install any Nuget package to the API that you see fit.

# The Test

In all cases here you may make any changes to the Fund Controller that you think necessary,
or which you consider would make the Controller more maintainable in the future.

## Technical Debts

### 1) Add Unit Tests

Add a Unit Test project to the solution and implement some checks on the functionality of the underlying models and API calls.

### 2) RESTful API

Refactor the `FundsController` to expose an API that you would consider "RESTful" for the operations that currently exist:

- Retrieve a single Fund identified by its `MarketCode`.
- Retrieve all Funds.
- Retrieve all Funds from a given Fund Manager.

You should adhere to SOLID principles throughout the refactoring process.

### 3) Add Logging

Add some logging to record API call requests.  You may use whichever logging mechanism you are comfortable with to provide this functionality.

## User Stories

### 1) Format Fund Data for 3rd Parties

> As a Consumer of the API
>
> So that I can use Novia Fund data
>
> I want a the API to respond with the data in a prescribed format.

##### Acceptance Criteria
* The format of the fund file should not change.
* The `CurrentUnitPrice` should be rounded to 2 decimal places.
* The `Id` field should not be exposed via the API.
* The `MarketCode` field should be exposed via the API as `Code`.