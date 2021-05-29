# Factory.Solution

## A web app to manage your Machines and engineers

#### By Nick Reeder

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Technologies Used

- c#
- .Net
- Microsoft.NET.Test
- Razor
- Entity
- MVC architecture
- ASP.NET
- EF Core

# Get Started

- Open your favorite Terminal

## Installation

```sh
git clone https://github.com/reeder32/Factory.Solution.git
```

#### Install Database

[Download MySqlWorkBench](https://dev.mysql.com/downloads/workbench/)

##### Open in VS Code

```sh
cd Factory.Solution
code .
```

```sh
cd Factory
dotnet ef migrations add Initial
```

```sh
dotnet ef database update
```

**IMPORTANT**

1. In the root folder create a file 'appsettings.json'
2. Copy text below:

```sh
{
  "ConnectionStrings" : {
    "DefaultConnection" : "Server=localhost;Port=3306;database=nick_reeder;uid=root;pwd=epicodus;"
  }
}
```

#### Run on Browser

```sh
cd Factory
dotnet run
```

[Open your browser here](http://localhost:5000)

## License

[MIT License](https://opensource.org/licenses/MIT)
&copy; 2021 Nick Reeder

## Contact Information

[email me](mailto:nickreeder32@gmail.com)

### Other projects

#### iOS work

- [Moody Weather](https://apps.apple.com/us/app/moody-weather/id1506337317)

- [Find My Mailbox](https://apps.apple.com/us/app/find-my-mailbox/id1530700085)
