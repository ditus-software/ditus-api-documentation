// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
namespace Ditus.Api.Documentation
{
  using System;

  /// <summary>
  /// Specifies a description for a parameter in a RESTful web service method.
  /// </summary>
  [AttributeUsage(AttributeTargets.Parameter)]
  public sealed class RestMethodParameterAttribute : Attribute
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RestMethodParameterAttribute"/> class.
    /// </summary>
    /// <param name="description">The description.</param>
    /// <param name="required">true if the parameter is required; otherwise, false.</param>
    public RestMethodParameterAttribute(string description, bool required)
    {
      this.Description = description;
      this.Required = required;
    }

    /// <summary>
    /// Gets a description of the parameter.
    /// </summary>
    /// <returns>The description.</returns>
    public string Description
    {
      get;
    }

    /// <summary>
    /// Gets a value indicating whether the parameter is required.
    /// </summary>
    /// <returns>true if the parameter is required; otherwise, false.</returns>
    public bool Required
    {
      get;
    }
  }
}
