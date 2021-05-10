// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
#pragma warning disable 1591
namespace Ditus.Api.Documentation.FormattingObjects
{
  using System.Collections.ObjectModel;

  /// <summary>
  /// Represents a collection of web service methods.
  /// </summary>
  public class Methods
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Methods"/> class.
    /// </summary>
    public Methods()
    {
      Items = new Collection<Method>();
    }

    /// <summary>
    /// Gets a collection of <see cref="Method"/> objects.
    /// </summary>
    /// <returns>A collection containing <see cref="Method"/> objects.</returns>
    public Collection<Method> Items
    {
      get;
    }
  }
}
#pragma warning restore 1591
