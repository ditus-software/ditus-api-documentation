// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
#pragma warning disable 1591
namespace Ditus.Api.Documentation.FormattingObjects
{
  /// <summary>
  /// Represents a web service.
  /// </summary>
  public class Service
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Service"/> class.
    /// </summary>
    public Service()
    {
    }

    /// <summary>
    /// Gets or sets the description of the service.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the human-readable description of the service.</returns>
    public string Description
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the name of the service.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the name of the service.</returns>
    public string Name
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the URL used to access the web service.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the URL used to access the web service.</returns>
    public string Url
    {
      get;
      set;
    }
  }
}
#pragma warning restore 1591
