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

# References
[Get a custom endpoint without creating an EventHub for EventStreams](https://www.youtube.com/watch?v=ftb2nN3eukg)
Similar project: [Mockingbird](https://www.tinybird.co/blog-posts/mockingbird-announcement-mock-data-generator)
