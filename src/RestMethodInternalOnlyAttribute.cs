// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
namespace Ditus.Api.Documentation
{
  using System;

  /// <summary>
  /// Specifies whether a RESTful web service method is available to external callers.
  /// </summary>
  [AttributeUsage(AttributeTargets.Method)]
  public sealed class RestMethodInternalOnlyAttribute : Attribute
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RestMethodInternalOnlyAttribute"/> class.
    /// </summary>
    /// <param name="internalOnly">true if the method is only available internally; otherwise, false.</param>
    public RestMethodInternalOnlyAttribute(bool internalOnly)
    {
      InternalOnly = internalOnly;
    }

    /// <summary>
    /// Gets a value indicating whether the web service method is only available internally.
    /// </summary>
    /// <returns>true if the method is only available internally; otherwise, false.</returns>
    public bool InternalOnly
    {
      get;
    }
  }
}
