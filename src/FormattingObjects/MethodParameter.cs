// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
#pragma warning disable 1591
namespace Ditus.Api.Documentation.FormattingObjects
{
  /// <summary>
  /// Represents a parameter passed to a web service method.
  /// </summary>
  public class MethodParameter
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MethodParameter"/> class.
    /// </summary>
    public MethodParameter()
    {
    }

    /// <summary>
    /// Gets or sets the description of the parameter.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the human-readable description of the parameter.</returns>
    public string Description
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the parameter is required.
    /// </summary>
    /// <returns>true if the parameter is required; false if the parameter is not required; otherwise, null.</returns>
    public bool? IsRequired
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the name of the parameter.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the name of the parameter.</returns>
    public string Name
    {
      get;
      set;
    }
  }
}
#pragma warning restore 1591
