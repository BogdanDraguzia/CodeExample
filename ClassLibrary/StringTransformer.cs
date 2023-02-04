using ClassLibrary.Exceptions;
using ClassLibrary.Interfaces;

namespace ClassLibrary;

public class StringTransformer
{
    IDayOfWeekProvider dayOfWeekProvider;

    public StringTransformer(IDayOfWeekProvider dayOfWeekProvider)
    {
        this.dayOfWeekProvider = dayOfWeekProvider;
    }

    public string Transform(string? input)
    {
        GuardAgainstNull(input);

        ThrowOnMonday();

        if (input.Length <= 3)
            return input.ToUpper();

        return input;
    }

    static void GuardAgainstNull(string? input)
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input), "Provided string cannot be null");
    }

    void ThrowOnMonday()
    {
        if (dayOfWeekProvider.CurrentDayOfWeek == DayOfWeek.Monday)
            throw new MondayException();
    }
}