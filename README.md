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