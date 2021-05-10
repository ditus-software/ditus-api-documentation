// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
namespace Ditus.Api.Documentation
{
  using System;

  /// <summary>
  /// Specifies the summary description for a RESTful web service method.
  /// </summary>
  [AttributeUsage(AttributeTargets.Method)]
  public sealed class RestMethodSummaryAttribute : Attribute
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RestMethodSummaryAttribute"/> class.
    /// </summary>
    /// <param name="summary">The summary.</param>
    public RestMethodSummaryAttribute(string summary)
    {
      this.Summary = summary;
    }

    /// <summary>
    /// Gets a summary of the method.
    /// </summary>
    /// <returns>The summary.</returns>
    public string Summary
    {
      get;
    }
  }
}
