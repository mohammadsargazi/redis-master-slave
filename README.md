# Redis Master-Slave Example with ASP.NET Core and Docker Compose

This project demonstrates how to implement a **Redis Master-Slave** setup using **ASP.NET Core** and **Docker Compose**. The application showcases Redis replication and exposes APIs to set and retrieve key-value pairs from both the master and slave nodes.

## Features

- **Master-Slave Replication**: Write operations are directed to the master, while read operations can be directed to the slave nodes.
- **ASP.NET Core API**:
  - `POST /api/redis/set`: Sets a key-value pair in the Redis master.
  - `GET /api/redis/get-master`: Retrieves a value from the Redis master.
  - `GET /api/redis/get-slave`: Retrieves a value from a Redis slave.
- **Docker Compose**: Provides a containerized setup for Redis with one master and two replicas (slaves).
- **Configurable Redis Endpoints**: Easily configure the Redis master and slave endpoints via `appsettings.json`.

---

## Prerequisites

Before running the project, ensure that you have the following installed:

- **.NET SDK**: [Download here](https://dotnet.microsoft.com/download)
- **Docker**: [Install Docker](https://www.docker.com/products/docker-desktop)
- **Docker Compose**: Included with Docker Desktop.

---

## Getting Started

Follow these steps to get the project up and running:

### Clone the Repository

```bash
git clone https://github.com/yourusername/redis-master-slave-example.git
cd redis-master-slave-example
```

## Build and Run with Docker Compose

Ensure Docker is running on your system.

Build and start the services using Docker Compose:

```bash
docker-compose up --build
```


