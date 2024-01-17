
# SafeCampus Project

## Overview

The SafeCampus project is an application that utilizes MongoDB to manage information related to admin, students, guards, laptops, reports, and tracking activities. The application follows the MVC (Model-View-Controller) architecture and provides the necessary endpoints to interact with the MongoDB database.

## Project Structure

The project has a specific folder structure that should be maintained throughout the development process. Any proposed changes to the structure should be discussed and agreed upon.

```
SafeCampus
|-- Controllers
|-- Models
|-- Services
|-- Utils
|   |-- DbSettings.cs
|-- appsettings.json
|-- Program.cs
|-- README.md
|-- (other files and folders)
```
## Folder Structure Details

- Controllers: Contains MVC controller classes that handle HTTP requests and define the application's endpoints.

- Models: Contains classes representing the structure of MongoDB documents for collections like Student, Guard, Laptop, Report, and Track.

- Services: Houses service classes responsible for business logic and interactions with the MongoDB database.

- Utils: Contains classes related to setups, including the MongoDBContext and DatabaseSetting.

## Collaborative Development

### Collaborators

Collaborators involved in the project:
- [dagmaros27]
- [abenezer]

## Branching Strategy

- Each collaborator should work in their own branch.
- Branch names should be meaningful and related to the feature or task being worked on.
- Collaborators must not commit directly to the main branch.

## Coding Standards

- Use PascalCase for public identifiers or wherever other developers may access.
- Follow the defined project namespace, "SafeCampus," for application-specific classes.
- Do not change the folder structure without prior discussion and agreement.

## MongoDB Database Details

- Database Name: safeCampus
- Collections: Admin, Student, Guard, Laptop, Report, Track

## Getting Started

- Clone the repository to your local machine.
```
git clone [repository_url]
```
- Create your own branch for development.
```
git checkout -b [your_branch_name]
```
- Install the required NuGet packages.
```
dotnet restore
```
- Start coding and implement the required endpoints.
## Contribution Rules
- Make changes in your branch.
- Commit changes only to your branch.
- Push your changes to your branch.
- Create a pull request when your feature or task is complete for review and merging.
