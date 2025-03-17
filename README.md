# Mayhem.TDSVersionApi

## Overview

Mayhem.TDSVersionApi is a .NET 6 Web API project designed to provide game version details. It includes an endpoint to retrieve the latest game version and its build URL.

## Features

- Retrieve the latest game version details.
- Built with ASP.NET Core and C# 10.0.

## Installation

1. Clone the repository:
    
git clone https://github.com/your-repo/Mayhem.TDSVersionApi.git

2. Navigate to the project directory:

cd Mayhem.TDSVersionApi

3. Restore the dependencies:

dotnet restore

## Usage

1. Build the project:

dotnet build
	
2. Run the project:
    dotnet run
	
3. Access the API endpoint:
    - `GET /api/GameVersion/GameVersion`: Retrieves the latest game version details.

## API Endpoints

### Get Game Version

- **URL:** `/api/GameVersion/GameVersion`
- **Method:** `GET`
- **Response:**
    
{
    "latestGameVersion": "string",
    "buildURL": "string"
}


## Dependencies

- .NET 6
- ASP.NET Core

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes.

## License

This project is licensed under the MIT License. The license belongs to Mayhem Games OÜ.
