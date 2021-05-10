// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
#pragma warning disable 1591
namespace Ditus.Api.Documentation.Controllers
{
  using System;
  using System.Diagnostics.CodeAnalysis;
  using System.Linq;
  using System.Reflection;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Mvc;
  using Ditus.Api.Documentation;
  using Ditus.Api.Documentation.FormattingObjects;
  using Ditus.Api.Documentation.Common;

  [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Templated.")]
  [RestWebService("api", "Contains web methods related to web service meta-data.")]
  [Route("1/api")]
  public class Api1Controller : Controller
  {
    /// <summary>
    /// Generates the meta-data for the specified web service.
    /// </summary>
    /// <param name="webService">The <see cref="Type"/> of the web
    /// service.</param>
    /// <returns>A <see cref="Methods"/> containing the meta-data for the web
    /// service.</returns>
    public static Methods GenerateMetadata(Type webService)
    {
      if (webService == null)
      {
        throw new ArgumentNullException(nameof(webService));
      }

      var metadata = new Methods();

      foreach (MethodInfo method in webService.GetMethods())
      {
        if (!GetMethodInternalOnly(method))
        {
          var urlTemplate = GetUrlTemplate(method);
          if (!urlTemplate.ToString().StartsWith("Help", StringComparison.OrdinalIgnoreCase))
          {
            if (!GetMethodInternalOnly(method))
            {
              var metadataMethod = new Method
              {
                Description = GetMethodDescription(method),
                HttpMethod = GetHttpMethod(method),
                Name = GetMethodName(urlTemplate),
              };

              foreach (ParameterInfo parameter in method.GetParameters())
              {
                var metadataParameter = new MethodParameter
                {
                  Description = GetParameterDescription(parameter),
                };
                if (string.Equals(parameter.Name, "data", StringComparison.OrdinalIgnoreCase))
                {
                  metadataParameter.Name = "data";
                  metadataParameter.IsRequired = true;
                }
                else
                {
                  metadataParameter.IsRequired = GetParameterRequired(parameter);
                  metadataParameter.Name = parameter.Name;
                }

                metadataMethod.Parameters.Add(metadataParameter);
              }

              metadataMethod.Url = GetWebServiceMethodUrl(webService, urlTemplate);
              metadata.Items.Add(metadataMethod);
            }
          }
        }
      }

      return metadata;
    }

    /// <summary>
    /// Gets the HTTP Method used by the web service method.
    /// </summary>
    /// <param name="method">A <see cref="MemberInfo"/> representing the web
    /// service method.</param>
    /// <returns>One of GET, POST, or DELETE, specifying the HTTP
    /// Method.</returns>
    public static string GetHttpMethod(MemberInfo method)
    {
      if (!(method.GetCustomAttribute(typeof(HttpGetAttribute)) is HttpGetAttribute))
      {
        if (!(method.GetCustomAttribute(typeof(HttpPostAttribute)) is HttpPostAttribute))
        {
          return "DELETE";
        }
        else
        {
          return "POST";
        }
      }
      else
      {
        return "GET";
      }
    }

    /// <summary>
    /// Gets a description of the web service method.
    /// </summary>
    /// <param name="method">A <see cref="MemberInfo"/> representing the web
    /// service method.</param>
    /// <returns>A description of the web service method; otherwise, an empty
    /// string if the method does not have a description.</returns>
    public static string GetMethodDescription(MemberInfo method)
    {
      if (method.GetCustomAttribute(typeof(RestDescriptionAttribute)) is RestDescriptionAttribute attribute)
      {
        return attribute.Description;
      }

      return string.Empty;
    }

    /// <summary>
    /// Gets a value indicating whether the web service method is only
    /// accessible internally.
    /// </summary>
    /// <param name="method">A <see cref="MemberInfo"/> representing the web
    /// service method.</param>
    /// <returns>true if the web service method is only accessible internally;
    /// otherwise, false.</returns>
    /// <remarks>If this attribute is omitted, the default is internal-only to
    /// prevent methods from being accidentally exposed externally.</remarks>
    public static bool GetMethodInternalOnly(MemberInfo method)
    {
      if (method.GetCustomAttribute(typeof(RestMethodInternalOnlyAttribute)) is not RestMethodInternalOnlyAttribute attribute)
      {
        return true;
      }
      else
      {
        return attribute.InternalOnly;
      }
    }

    /// <summary>
    /// Gets the name of a web service method from a URI template.
    /// </summary>
    /// <param name="uriTemplate">Contains the relative URL of the web service method.</param>
    /// <returns>The name of the web service method.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="uriTemplate"/> is null.</exception>
    public static string GetMethodName(Uri uriTemplate)
    {
      if (uriTemplate == null)
      {
        throw new ArgumentNullException(nameof(uriTemplate));
      }

      return UrlUtility.GetRelativeUrlPath(uriTemplate);
    }

    /// <summary>
    /// Gets a description of the web service method parameter.
    /// </summary>
    /// <param name="parameter">A <see cref="ParameterInfo"/> representing the parameter.</param>
    /// <returns>A description of the parameter.</returns>
    /// <exception cref="NotImplementedException">Thrown if the parameter is not decorated with the <see cref="RestMethodParameterAttribute"/> attribute.</exception>
    public static string GetParameterDescription(ParameterInfo parameter)
    {
      if (parameter == null)
      {
        throw new ArgumentNullException(nameof(parameter));
      }

      if (parameter.GetCustomAttribute(typeof(RestMethodParameterAttribute)) is RestMethodParameterAttribute attribute)
      {
        return attribute.Description;
      }

      return null;
    }

    /// <summary>
    /// Gets a value indicating whether the web service method parameter is
    /// required.
    /// </summary>
    /// <param name="parameter">A <see cref="ParameterInfo"/> representing the
    /// parameter.</param>
    /// <returns>true if the parameter is required; otherwise, false. If the
    /// parameter is not adorned with this attribute, then false will be
    /// returned.</returns>
    public static bool GetParameterRequired(ParameterInfo parameter)
    {
      if (parameter == null)
      {
        throw new ArgumentNullException(nameof(parameter));
      }

      if (parameter.GetCustomAttribute(typeof(RestMethodParameterAttribute)) is RestMethodParameterAttribute attribute)
      {
        return attribute.Required;
      }

      return false;
    }

    /// <summary>
    /// Gets the URL template used by the web service method.
    /// </summary>
    /// <param name="method">A <see cref="MemberInfo"/> representing the web service method.</param>
    /// <returns>A <see cref="Uri"/> containing the relative URL of the web service method.</returns>
    public static Uri GetUrlTemplate(MemberInfo method)
    {
      if (method.GetCustomAttribute(typeof(HttpGetAttribute)) is not HttpGetAttribute getAttribute)
      {
        if (method.GetCustomAttribute(typeof(HttpPostAttribute)) is not HttpPostAttribute postAttribute)
        {
          var deleteAttribute = method.GetCustomAttribute(typeof(HttpDeleteAttribute)) as HttpDeleteAttribute;
          return new Uri(deleteAttribute.Template, UriKind.Relative);
        }
        else
        {
          return new Uri(postAttribute.Template, UriKind.Relative);
        }
      }
      else
      {
        return new Uri(getAttribute.Template, UriKind.Relative);
      }
    }

    /// <summary>
    /// Gets the <see cref="Uri"/> for a web service method.
    /// </summary>
    /// <param name="webService">The web service.</param>
    /// <param name="urlTemplate">The URL template for the web service method.</param>
    /// <returns>The relative URL of the web service method.</returns>
    public static string GetWebServiceMethodUrl(Type webService, Uri urlTemplate)
    {
      var routeAttribute = webService.GetTypeInfo().GetCustomAttribute<RouteAttribute>();

      return string.Concat("/", routeAttribute.Template, "/", UrlUtility.GetRelativeUrlPath(urlTemplate));
    }

    [RestDescription("Retrieves Methods or a specific Method for the specified Service.")]
    [RestMethodInternalOnly(false)]
    [HttpGet("services/{serviceName}/methods")]
    public IActionResult GetServiceMethods(
      [RestMethodParameter("The name of the service.", true)]
      string serviceName,
      [RestMethodParameter("The HTTP method used to invoke the method (GET, POST, or DELETE).", false)]
      string httpMethod,
      [RestMethodParameter("The name of the method.", false)]
      string methodName)
    {
      var methods = new Methods();

      var assembly = Assembly.GetEntryAssembly();
      foreach (var webServiceType in assembly.GetTypes())
      {
        if (webServiceType.GetTypeInfo().BaseType == typeof(Controller))
        {
          var webServiceAttribute = webServiceType.GetTypeInfo().GetCustomAttribute<RestWebServiceAttribute>();
          if (webServiceAttribute != null && string.Equals(webServiceAttribute.Name, serviceName, StringComparison.OrdinalIgnoreCase))
          {
            methods = GenerateMetadata(webServiceType);

            if (!string.IsNullOrWhiteSpace(httpMethod) && !string.IsNullOrWhiteSpace(methodName))
            {
              var method = (from x in methods.Items where string.Equals(x.HttpMethod, httpMethod, StringComparison.OrdinalIgnoreCase) && string.Equals(x.Name, methodName) select x).SingleOrDefault();
              methods.Items.Clear();
              methods.Items.Add(method);
            }

            break;
          }
        }
      }

      return StatusCode(StatusCodes.Status200OK, methods);
    }

    [RestDescription("Retrieves services.")]
    [RestMethodInternalOnly(false)]
    [HttpGet("services")]
    public IActionResult GetServices()
    {
      var services = new Services();

      var assembly = Assembly.GetEntryAssembly();
      foreach (var webServiceType in assembly.GetTypes())
      {
        if (webServiceType.GetTypeInfo().BaseType == typeof(Controller))
        {
          var webServiceAttribute = webServiceType.GetTypeInfo().GetCustomAttribute<RestWebServiceAttribute>();
          var routeAttribute = webServiceType.GetTypeInfo().GetCustomAttribute<RouteAttribute>();

          if (webServiceAttribute != null && routeAttribute != null)
          {
            var service = new Service()
            {
              Description = webServiceAttribute.Description,
              Name = webServiceAttribute.Name,
              Url = routeAttribute.Template,
            };
            services.Items.Add(service);
          }
        }
      }

      return StatusCode(StatusCodes.Status200OK, services);
    }
  }
}
#pragma warning restore 1591
