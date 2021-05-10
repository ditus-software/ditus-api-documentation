# Ditus.Api.Documentation

Ditus.Api.Documentation provides attributes with which to adorn your Web API end-points and method parameters and an end-point which generates documentation based on those attributes.

## Usage

### Documenting Your API

#### Controllers

The `RestWebService` attribute describes the controller/service. It accepts the name of the service (as it should be displayed to the user), and a description of the service. For example:

```C#
[RestWebService("weather", "Contains web methods for forecasting the weather.")]
public class WeatherController : Controller
```

#### Internal vs. External Methods

The vast majority of methods are external methods. In other words, when the documentation for the API is generated, these methods will be included in the documentation and developers made aware that they exist. Some API methods however, may be experimental or may not be designed to be exposed to outside developers. This doesn't prevent them from being called, however, it informs developers who do stumble upon them that using them may mean that the method will be removed in a near future release or the functionality of the method may change. External applications and user interfaces should never use these methods.

A method is marked as internal or external by adorning the method with the `RestMethodInternalOnly` attribute. For example, the following method is marked as external:

```C#
[RestDescription("Creates a User or edits an existing one.")]
[RestMethodInternalOnly(false)]
[HttpPost("user")]
public IActionResult SetUser( ...etc...
```

#### Method Parameters

Method parameters are documented using the `RestMethodParameter` attribute. Each parameter can be marked as required (true) or optional (false). For example:

```C#
public IActionResult CalculateAge(
[RestMethodParameter("The UTC date on which the person was born.", true)]
DateTime birthDate,
```

### Including the Documentation End Point In Your Own API

A controller with end-points is provided that allows you to dynamically generate
and view the resulting documentation in JSON format, which you can then use to
display the documentation on a developer portal, for instance.

Modify the `ConfigureServices` method of the `StartUp` class. It will resemble
the following:

```C#
public void ConfigureServices(IServiceCollection services)
{
  ...etc...

  var assembly =
    System.Reflection.Assembly.GetAssembly(
      typeof(Ditus.Api.Documentation.Controllers.Api1Controller));

  ...etc...

  services.AddControllers().AddApplicationPart(assembly);
}
```

### Accessing the Documentation

To access a list of the services in your API:

```text
GET http://localhost/1/api/services
```

To access a list of the web methods within a service, use the following
end-point, replacing {serviceName} with the name of a service from the list
above.

```text
GET http://localhost/1/api/services/{serviceName}/methods
```

## Roadmap

See the open issues for a list of proposed features (and known issues).

## License

This project is licensed under the terms of the [MIT license](LICENSE.md).
