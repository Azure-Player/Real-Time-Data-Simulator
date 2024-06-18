# Real-Time Data Simulator
Windows Desktop application to generate and stream data into EventHub.

# Screenshot
<img src='https://pbs.twimg.com/media/GPQ0nj9WkAAlb7O?format=png&name=medium'>

# Main Features
- Configurable target EventHub
- Configurable size of workload (amount of messages to be sent)
- Easily editable JSON payload
- Sending defined payload into the target endpoint
- Load/Save payload as a file locally
- Runtime evaluation of pre-defined variables
- Runtime evaluation of expression in C# (slower)

# Scenarios
1. Generate dynamic data based on JSON template and send it to Microsoft Fabric EventHub (custom endpoint).
2. Generate dynamic data based on JSON template and send it to EventHub.

# Tokens
The biggest advantage of the application is the ability to generate value for the tokens listed in the PAYLOAD definition. Data generation takes place on the fly for each message prepared for sending.

## Variables
Format of a variable: `{{VariableName}}`  
The following examples depict predefined Variables you can use as Tokens:
|Variable | Generates |
|--|--|
| `{{UserId}}` | Numeric (int) value from range 5000-5100 |
| `{{ProductId}}` | Numeric (int) value from range 700-999 |
| `{{Device}}` | Random item from array of: mobile,tablet,pc |
| `{{DateTime.Now}}` | Current date & time (now) in [round-trip ("O") format](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#Roundtrip).  |
| `{{FuelType(MessageIndex)}}` | Value selected on `MessageIndex` from list: BIOMASS,CCGT,COAL,INTELEC,INTEW,INTFR,INTIFA2,INTIRL,INTNED,INTNEM,INTNSL,INTVKL,NPSHYD,NUCLEAR,OCGT,OIL,OTHER,PS,WIND |
| `{{SettlementPeriod}}` | Hardcoded Int value: `48` |

## C# Expressions
Format of an expression: `{{$Expression}}`  
Expressions are **slower** in generating values, but more flexible. Use can use any C# compatible code from preloaded namespaces (for example: `System`).
Expressions are being evaluated using [Microsoft.CodeAnalysis.CSharp.Scripting](https://github.com/dotnet/roslyn/blob/main/docs/wiki/Scripting-API-Samples.md).

   
|Expression | Generates |
|--|--|
| `{{$DateTime.Now}}` | Current date & time (now) |
| `{{$new Random().Next(100,200)}}` | Random numeric (int) value from range 100-199 |
| `{{$DateTime.Now.AddSeconds(-5).ToString("s")+"Z"}}` | Date & time 5 seconds ago in [Sortable date/time pattern](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings#Sortable) with 'Z' at the end. |
| `{{$DateTime.Now.ToString("dd/MM/yyyy")}}` | Current date & time formatted to `31/12/2020` |
| `{{$DateTime.Now.Hour*2+Math.Floor(DateTime.Now.Minute/30d)` | Calculation based on Current Time  |

# References
- [Get a custom endpoint without creating an EventHub for EventStreams](https://www.youtube.com/watch?v=ftb2nN3eukg)  
- Similar project: [Mockingbird](https://www.tinybird.co/blog-posts/mockingbird-announcement-mock-data-generator)
