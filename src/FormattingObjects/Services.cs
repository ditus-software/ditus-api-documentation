// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
#pragma warning disable 1591
namespace Ditus.Api.Documentation.FormattingObjects
{
  using System.Collections.ObjectModel;

  /// <summary>
  /// /// Represents a collection of web services.
  /// </summary>
  public class Services
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Services"/> class.
    /// </summary>
    public Services()
    {
      Items = new Collection<Service>();
    }

    /// <summary>
    /// Gets a collection of <see cref="Service"/> objects.
    /// </summary>
    /// <returns>A collection containing <see cref="Service"/> objects.</returns>
    public Collection<Service> Items
    {
      get;
    }
  }
}
#pragma warning restore 1591
