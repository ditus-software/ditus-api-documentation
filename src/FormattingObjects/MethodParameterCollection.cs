// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
#pragma warning disable 1591
namespace Ditus.Api.Documentation.FormattingObjects
{
  using System.Collections.ObjectModel;

  /// <summary>
  /// Represents a collection of <see cref="MethodParameter"/> objects.
  /// </summary>
  public class MethodParameterCollection : Collection<MethodParameter>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MethodParameterCollection"/> class.
    /// </summary>
    public MethodParameterCollection()
    {
    }
  }
}
#pragma warning restore 1591
