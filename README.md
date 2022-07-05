# MedicApi

[<img src="https://img.shields.io/badge/.NET-6.0-blueviolet">](https://img.shields.io/badge/.NET-6.0-blueviolet)

## Summary
MedicApi powers [MedicWeb](https://github.com/wmoralesdev/medic-web), you can see further details there.

## Stack
This API has been deployed to a Heroku Container Registry, it's fully dockerized. The database provider is PostgreSQL working with EF Core 6.0 as it's ORM.

# API infrastructure

The development of this API is based on the design pattern called *Repository* and *Services*,
own and commonly implemented by developers of the .NET framework. For this, the API has been structured into three fundamental projects:

- [Medic.API](#`Medic.API`)
- [Medic.Application](#`Medic.Application`)
- [Medic.Domain](#`Medic.Domain`)

# Medic.API

This project's main function is to store the the controllers, dependencies, extensions and properties of the API. The main controllers are:
 | Controller | Functionality |
| ------ | ------ |
| Appointment Controller | Responsible for managing the logic of creating, viewing and updating appointments for each patient so that you can have control over each of your appointments. |
| Auth Controller | In charge of handling the logic of registration, login and authentication for each type of user within the application (patient or doctor). |
| Doctor Controller | In charge of managing all the logic around the functions and responsibilities of the doctor user within the application. You can obtain the availability of each doctor, update your personal information and academic training and other general aspects of creating the doctor user. |


# Medic.Application

 The main function of this project is to take care of the business layer, all of it's handling and mappings to viewmodels of each of the entities that are stored.

> This project stores the logic and implementation of the Repository and Services design pattern. In this you can see the use of interfaces that store the methods
> that are implemented within each repository assigned to each controller and/or service.

# Medic.Domain

Contains the models/entities that comprise the application. Among these are:

- Appointments
- Clinics
- Common:
    - Base Identity
    - Geolocation
    - Role
- Doctors:
    - Doctor
    - Experince
    - Formation
    - Schedule
    - Speciality
- Patients
- Time Measures:
    - Time Interval
    - Workday

## License

MIT

**Free Software, Hell Yeah!**


