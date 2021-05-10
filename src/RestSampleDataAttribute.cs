// Copyright (c) DITUS INC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for
// details.
namespace Ditus.Api.Documentation
{
  using System;

  /// <summary>
  /// Specifies sample data for a property in a formatting object.
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class RestSampleDataAttribute : Attribute
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RestSampleDataAttribute"/> class.
    /// </summary>
    /// <param name="sampleData">An example of a valid value.</param>
    public RestSampleDataAttribute(object sampleData)
    {
      this.SampleData = sampleData;
    }

    /// <summary>
    /// Gets an example of a valid value.
    /// </summary>
    /// <returns>A <see cref="object"/>.</returns>
    public object SampleData
    {
      get;
    }
  }
}
