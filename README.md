# BicycleRentalApplication
Bicycle Rental Application is a four layers system.

1. BicycleRentalApplication: it's an ASP.MVC proyect only for the UI.
2. BicycleRentalApplication.Rent.Core: it's the logic layer. You'll find the business rules there.
3. BicycleRentalApplication.Rent.Dal: it's the data access layer. The CRUD and the Code First Settings are in this layer.
4. BicycleRentalApplication.Rent.Models: it's the models and context layer. The Rent Model is in this layer and the Context for its Code First too.

## TDD (Unit Tests)
I did this application with TDD methodology. It's a plus to Unit Tests.
The Code Coverage is really high but only for the BicycleRentalController and the Core layer. For technical reasons, the Dal layer usualy have a low level of Code Coverage (The DbContext classes can't be overloaded).

## Create Database (MS-SQL Server)

The application is made with Code First and Migrations.
Run the next command in your MS-Sql Server instance:

CREATE DATABASE BicycleRentalApplication;

### RabbitMQTest + Docker

While I was doing the application I realized this System is too small for implemente a Message Queue Model. Then I didn't do it.
However, if I have to chose one Message Queue Model, I would have chosen Rabbit.MQ with a RPC (Remote Procedure Call) schema.

RPC: https://www.rabbitmq.com/tutorials/tutorial-six-dotnet.html

C# Rabbit.MQ Client: https://www.rabbitmq.com/dotnet-api-guide.html

For download an run a Rabbit.Mq instance, run the following RabbitMQ docker image:

docker run -d -p 5672:5672 --hostname my-rabbit --name test-rabbit rabbitmq:3

and then the next command:

docker run rabbitmq
