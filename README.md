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

