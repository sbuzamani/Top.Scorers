# Top.Scorers

This Project is used to track and display Top Scorers

## Top.Scorers.Api
REST Api side of the project to add person, get by id, and get top scorers

## Top.Scorers.Console
Console App is used to see the top scorers names and the top score from the csv file.

Both Client applications make use of the PersonService to access exclusively person related functions
### Running Application
Set either the Console or Api project to the start up project and run it. Also ensure that you have added the TestData.csv added to the projects.

# Desgin
The design of the solution follows a layered architecture, onion, hexagonal. Making it easy to change out data sources or add other expansion packages.
There was also a focus to use interfaces to make the project classes less coupled and make handling of and injection of dependencies smoother.
Giving classes a single responsibility classes was also a major focus.

# Database
The Database of choice for this solutions was SQLite, as it was the easiest to get up and ready to go quickest. As mentioned before, because of the structure of the project it can be swapped out with little effort.

# API Security
We could add authentication bearer tokens for the API to ensuring that only users authenticated users can make API calls.
Additionally we can also introduce some roles for users and introduce Authorization too. To manage which users can make certain API calls, say adding users to be done by Admins only.
