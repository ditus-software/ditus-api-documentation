// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
#pragma warning disable 1591
namespace Ditus.Api.Documentation.FormattingObjects
{
  /// <summary>
  /// Represents a web service method.
  /// </summary>
  public class Method
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Method"/> class.
    /// </summary>
    public Method()
    {
      Parameters = new MethodParameterCollection();
    }

    /// <summary>
    /// Gets or sets the description of the method.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the human-readable description of the method.</returns>
    public string Description
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the HTTP method used to call the method.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the HTTP method that is used to call the method.</returns>
    public string HttpMethod
    {
      get;
      set;
    }

    /// <summary>
    /// Gets or sets the name of the method.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the human-readable name of the method.</returns>
    public string Name
    {
      get;
      set;
    }

    /// <summary>
    /// Gets a collection used to specify parameters for the method.
    /// </summary>
    /// <returns>A <see cref="MethodParameterCollection"/> containing all parameters for the method.</returns>
    public MethodParameterCollection Parameters
    {
      get;
    }

    /// <summary>
    /// Gets or sets the URL used to call the method.
    /// </summary>
    /// <returns>A <see cref="string"/> representing the URL used to call the method with all possible parameters listed.</returns>
    public string Url
    {
      get;
      set;
    }
  }
}
#pragma warning restore 1591
