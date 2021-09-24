namespace MilitaryElite.Models.Soldiers.Interfaces
{
    public interface IRepair
    {
        string PartName { get; }

        int HoursWorked { get; }
    }
}
