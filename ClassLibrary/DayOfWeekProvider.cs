using ClassLibrary.Interfaces;

namespace ClassLibrary;

class DayOfWeekProvider : IDayOfWeekProvider
{
    public DayOfWeek CurrentDayOfWeek => DateTime.Today.DayOfWeek;
}