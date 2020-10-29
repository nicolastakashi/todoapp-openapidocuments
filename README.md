# Todo App - OpenAPI Documents

![CI](https://github.com/nicolastakashi/todoapp-openapidocuments/workflows/CI/badge.svg?branch=master)

This repository contains examples that were used in the post I made on my Medium account, showing how to design an API using an API-First strategy, you can check the post [here.](https://medium.com/@nicolastakashi/restful-using-api-first-cd305e59305d?sk=c7e0e73751dbd62ddea2cf9928dec49c)

## Runing

If you want to lint and run a mock server, you must to install the dependencies before, as you can see below.

```
yarn 
```

## Linting OpenAPI Documents

Check if your APIs are being designed following the proposed guidelines by your company, which could be a difficult job to do manually.
Thereby we can ask for a tool like Spectral to help us and create an autonomous process, to do this job.

Spectral is an open-source project that works like a linter to OpenAPI documents and has a lot of rules to ensure very common guidelines in the software industry to develop RESTFul APIs.

To run Spectral you can just run the command below. 

```
yarn lint
```

## Running Mock Server

Give a Mock Server with dynamic data to your clients taste your API Design and provide fast feedback about the Developer Experience.

Prism is an open-source project that provides us a mock server based on the OpenAPI documents and its structure.

To run Prism you can just run the command below.

```
yarn mock
```

## Contract Testing
Even after the API was made available, it keeps evolving, and one of the biggest challenges during an API Life-cycle is the API evolution, in order to detect breaking changes and avoid a contract break, we must have a strategy to be notified as soon as possible.

Before you start to test the contracts you must ensure that you have the dotnet installed, since the API used in this repository is an ASP.NET Project.
After you install Dotnet in your computer, you can install Swashbuclle CLI, running the command below.

```bash
dotnet tool install Swashbuckle.AspNetCore.Cli -g
```
OpenAPI Diff is an open-source project that compares two OpenAPI documents and shows differences between those files, and you can start to test your contracts running the commands below.

```bash
dotnet build ./api/TodoApp.Api/TodoApp.Api.csproj --configuration Release
swagger tofile --yaml --output ./bin/swagger.yaml ./api/TodoApp.Api/bin/Release/netcoreapp3.1/TodoApp.Api.dll v1
yarn contract-test
```

