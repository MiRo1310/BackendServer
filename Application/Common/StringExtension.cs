using System.Diagnostics.CodeAnalysis;

namespace BackendServer.Application.Common;

  public static class StringExtensions
  {
      [return: NotNullIfNotNull(nameof(value))]
      public static string? Truncate(this string? value, int maxLength)
      {
          if (value is null || value.Length <= maxLength) return value;
          return value[..maxLength];
      }
  }