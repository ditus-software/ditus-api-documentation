// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
namespace Ditus.Api.Documentation
{
  using System;

  /// <summary>
  /// Specifies settings for a REST web service.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public sealed class RestWebServiceAttribute : Attribute
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RestWebServiceAttribute"/> class.
    /// </summary>
    /// <param name="name">Name of the web service.</param>
    /// <param name="description">Description of the web service.</param>
    public RestWebServiceAttribute(string name, string description)
    {
      Description = description;
      Name = name;
    }

    /// <summary>
    /// Gets the description of the web service.
    /// </summary>
    /// <returns>The description of the web service.</returns>
    public string Description
    {
      get;
    }

    /// <summary>
    /// Gets the name of the web service.
    /// </summary>
    /// <returns>The name of the web service.</returns>
    public string Name
    {
      get;
    }
  }
}
