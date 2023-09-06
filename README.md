# FunctionAppRequestWeatherData

## Description

This Function App is designed to automatically fetch weather data from the OpenWeatherMap API and store it in an Azure Blob Storage account. The function runs every hour, making it a reliable way to collect weather data over time.

## Table of Contents

1. [Features](#features)
2. [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
    - [Configuration](#configuration)
3. [Deployment](#deployment)
4. [Built With](#built-with)
5. [Contributing](#contributing)
6. [License](#license)
7. [Contact](#contact)

## Features

- Automated data collection every hour
- Secure storage in Azure Blob Storage
- Written in C#, deployed on Azure

## Getting Started

### Prerequisites

- .NET SDK
- Azure CLI
- An Azure account
- OpenWeatherMap API key

### Installation

1. Clone the repository

   ```bash
   git clone https://github.com/yourusername/WeatherDataCollectorFunctionApp.git
   ```

2. Navigate to the project directory

    ```bash
    cd WeatherDataCollectorFunctionApp
    ```

3. Restore the NuGet packages

    ```bash
    dotnet restore
    ```

### Configuration

1. Rename `appsettings.sample.json` to `appsettings.json`.
   
2. Insert your OpenWeatherMap API key and Azure Blob Storage details into `appsettings.json`.

    ```json
    {
        "OpenWeatherMapApiKey": "<YOUR_API_KEY>",
        "BlobStorageConnectionString": "<YOUR_CONNECTION_STRING>"
    }
    ```

## Deployment

To deploy this Function App to Azure, follow these steps:

1. Login to Azure

    ```bash
    az login
    ```

2. Deploy the function app

    ```bash
    az functionapp create --name <YourFunctionAppName> --resource-group <YourResourceGroupName> --os-type Windows --runtime dotnet --consumption-plan-location <YourLocation>
    ```

3. Deploy the code

    ```bash
    func azure functionapp publish <YourFunctionAppName>
    ```

## Built With

- [.NET](https://dotnet.microsoft.com/)
- [Azure Functions](https://azure.microsoft.com/en-us/services/functions/)
- [Azure Blob Storage](https://azure.microsoft.com/en-us/services/storage/blobs/)
- [OpenWeatherMap API](https://openweathermap.org/api)

## Contributing

Since this is a private repository, contributing guidelines may not be applicable. However, if you wish to contribute, please contact the repository owner.

## License

This project is private and unlicensed.

## Contact

- Your Name - henrik-gb@hotmail.com
