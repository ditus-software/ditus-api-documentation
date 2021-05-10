// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
namespace Ditus.Api.Documentation.Common
{
  using System;

  /// <summary>
  /// Contains static methods for working with URLs.
  /// </summary>
  public static class UrlUtility
  {
    /// <summary>
    /// Gets the query string portion of a URL.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>The query string.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="url"/> is null.</exception>
    public static string GetQueryString(Uri url)
    {
      if (url == null)
      {
        throw new ArgumentNullException(nameof(url));
      }

      // Character position of the question mark within the URL.
      var questionMarkPosition = url.ToString().IndexOf("?", StringComparison.OrdinalIgnoreCase);
      if (questionMarkPosition == -1)
      {
        return string.Empty;
      }
      else
      {
        var position = questionMarkPosition + 1;
        return url.ToString()[position..];
      }
    }

    /// <summary>
    /// Gets the path portion of a relative URL.
    /// </summary>
    /// <param name="url">The relative URL.</param>
    /// <returns>The path portion without the query string.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="url"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if the <paramref name="url"/> only contains a query string portion.</exception>
    public static string GetRelativeUrlPath(Uri url)
    {
      if (url == null)
      {
        throw new ArgumentNullException(nameof(url));
      }

      // Character position of the question mark within the URL.
      var questionMarkPosition = url.ToString().IndexOf("?", StringComparison.OrdinalIgnoreCase);
      if (questionMarkPosition == -1)
      {
        return url.ToString();
      }
      else if (questionMarkPosition == 0)
      {
        throw new ArgumentException(null, nameof(url));
      }
      else
      {
        return url.ToString().Substring(0, questionMarkPosition);
      }
    }
  }
}
