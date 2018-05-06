# GeometricLayouts

Solution to the Geometric Layouts question.

## Requirements
Requires VS2017, ASP.NET, and .NET Core 2.0.

## Usage
Index.html provides a simple UI for calculating triangle coordinates and cells.

### Endpoint API

- GET: api/Triangle/Coordinates?row=`C`&column=`4`
- GET: api/Triangle/Cell?v1x=`10`&v1y=`20`&v2x=`20`&v2y=`20`&v3x=`20`&v3y=`30`
