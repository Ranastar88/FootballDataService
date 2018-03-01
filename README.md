# FootballDataService

Small library that implements some functionalities of football-data.org's API (http://football-data.org/).

## Install
NuGet Package
```
PM> Install-Package FootballDataService -Version 1.0.0
```
https://www.nuget.org/packages/FootballDataService/1.1.0

## Usage
More about filters, structure and API:
http://api.football-data.org/documentation

```
string APIKey = "XXXXXXXXXXXXXXXXXXXXXXXXX"
var football_ds = = new FootballData(APIKey);

//Example: Get all competitions of 2017
var c = football_ds.GetCompetitions(2017);
```
Register here for a free API key:
https://api.football-data.org/client/register
