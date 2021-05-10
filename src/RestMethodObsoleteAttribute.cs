// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
namespace Ditus.Api.Documentation
{
  using System;

  /// <summary>
  /// Specifies that a RESTful web service method is deprecated.
  /// </summary>
  [AttributeUsage(AttributeTargets.Method)]
  public sealed class RestMethodObsoleteAttribute : Attribute
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RestMethodObsoleteAttribute"/> class.
    /// </summary>
    public RestMethodObsoleteAttribute()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RestMethodObsoleteAttribute"/> class.
    /// </summary>
    /// <param name="date">The date on which the method became obsolete.</param>
    public RestMethodObsoleteAttribute(DateTime date)
    {
      this.Date = date;
    }

    /// <summary>
    /// Gets the date the method became obsolete.
    /// </summary>
    /// <returns>The date.</returns>
    public DateTime Date
    {
      get;
    }
  }
}
