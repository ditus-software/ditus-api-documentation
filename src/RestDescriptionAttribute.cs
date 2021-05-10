// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
namespace Ditus.Api.Documentation
{
  using System;

  /// <summary>
  /// Specifies a full description for a RESTful web service method or formatting object class or formatting object property.
  /// </summary>
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
  public sealed class RestDescriptionAttribute : Attribute
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RestDescriptionAttribute"/> class.
    /// </summary>
    /// <param name="description">The description.</param>
    public RestDescriptionAttribute(string description)
    {
      this.Description = description;
    }

    /// <summary>
    /// Gets a description of the method.
    /// </summary>
    /// <returns>The description.</returns>
    public string Description
    {
      get;
    }
  }
}
