# Claims API
Proof of concept API endpoint for an insurance claims department

## Background
A new front end to an existing SQL Server database is needed and it has been decided that a restful DotNetCore API is to be created to allow access to the Claims and Company data.

For the purpose of this proof of concept, the data can be generated in code rather than coming from SQL server.

Whilst this is a proof of concept exercise, the level of detail and quality should represent something that is fit for production use.

## Requirements
+ Output from the API must be in JSON format
+ An endpoint is required that will give details of a single company. In the return object, a property **must** be returned that will tell us if the company has an active insurance policy
+ An endpoint is required that will provide a list of claims for one company
+ An endpoint is required that will give provbide details of one claim. The return object **must** contain a property that shows how old the claim is in days
+ An endpoint is required that will allow a claim to be updated
+ At least one unit test is to be created


## Database Structure
```SQL
CREATE TABLE Claims
(
  UCR VARCHAR(20),
  CompanyId INT,
  ClaimDate DATETIME,
  LossDate DATETIME,
  [Assured Name] VARCHAR(100),
  [Incurred Loss] DECIMAL(15,2),
  Closed BIT
)

CREATE TABLE ClaimType
(
  Id INT,
  Name VARCHAR(20)
)

CREATE TABLE Company
(
  Id INT,
  Name VARCHAR(200),
  Address1 VARCHAR(100),
  Address2 VARCHAR(100),
  Address3 VARCHAR(100),
  Postcode VARCHAR(20),
  Country VARCHAR(50),
  Active BIT,
  InsuranceEndDate DATETIME
)
```

## Development Considerations
1. As this is to be considered for a production environment, use of an LTS version of DotNetCore should be used. Therefore, this project shall use .NET v6.0
1. As this is to be an API endpoint, no additional front-end requirements are needed. However, for development purposes and internal / local testing, swagger shall be used to provide an OpenAPI definition and testable endpoint.
1. The table structures using the DDL listed is exactly as is appears in the database
    1. No primary key definitions (although this is inferred in the `ClaimType` and `Company` tables.
    1. No indexes are present on the tables
    1. No constraints are in place on any fields
    1. All fields are NULLable
    1. All character fields are `VARCHAR`, not `NVARCHAR`
    1. All `BIT` fields do not have a default value set on them
1. The DDL does not show any stored procedures being used for CRUD operations

##	Assumptions for development
1. The API is for internal consumption, over a private network / VPN connection and as such will not be required to perform any security / authentication checks for the API calls
1. The internal API is not required to perform any rate-limiting of calls into the API that would be expected for an API being publically consumed.
1. The internal API should, wherever possible and practical to do so, mitigate against enumeration attacks where an API endpoint refers to internal enities using simple identifiers, such as an single integer
1. Where any `DATETIME` fields are specified in the database, the value shall be taken as "local" to the system and contain time information as well.
1. When accessing data from the database, in the absence of any definitions for stored procedures to perform CRUD operations, direct access shall be utilised, using EntityFramework as an ORM

Using the above assumptions, an initial state for the database shall be created, including the initial migration state for EntityFramework. This work shall be tagged in git with `initial`