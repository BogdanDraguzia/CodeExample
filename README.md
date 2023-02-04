# CodeExample

This repository shows how I refactored an existing class and covered it with unit-tests.
Tecnhologies used:
.NET 6, xUnit, Moq.

ExistingClass Looked like the following:

class HelperClass
{
    public async Task<string> TransformStringAsync(string input)
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input), "Provided string cannot be null");

        if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            throw new Exception("Method doesn't work on Mondays");

        if (input.Length > 3)
            return input;

        return input.ToUpper();
    }
} 
