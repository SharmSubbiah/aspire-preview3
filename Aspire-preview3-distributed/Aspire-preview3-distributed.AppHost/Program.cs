var builder = DistributedApplication.CreateBuilder(args);

var weatherApi = builder.AddProject<Projects.Aspire_preview3_Api>("aspire-preview3-api");

builder.AddNpmApp("react-weather", "../../AspireJavaScript.React")
    .WithReference(weatherApi)
    .WithServiceBinding(containerPort: 3001, scheme: "http", env: "PORT")
    .AsDockerfileInManifest();

builder.Build().Run();
