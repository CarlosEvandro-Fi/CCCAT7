namespace Aula01Lib;

public sealed class Segment
{
    private const decimal OVERNIGHT_START = 22;
    private const decimal OVERNIGHT_END = 6;

    public DateTime Date { get; }

    public Decimal Distance { get; }

    public Segment(Decimal distance, DateTime date)
    {
        Date = date;
        Distance = distance;

        if (!IsValidDate()) throw new Exception("Invalid Date!");
        if (!IsValidDistance()) throw new Exception("Invalid Distance!");
    }

    public Boolean IsOvernight() => Date.Hour >= OVERNIGHT_START || Date.Hour <= OVERNIGHT_END;

    public Boolean IsSunday() => Date.DayOfWeek == DayOfWeek.Sunday;

    private Boolean IsValidDate() => Date != default;

    private Boolean IsValidDistance() => Distance > 0;
}

//export default class Segment
//{
//	OVERNIGHT_START = 22;
//	OVERNIGHT_END = 6;

//	constructor(readonly distance: number, readonly date: Date) {
//		if (!this.isValidDistance()) throw new Error("Invalid Distance");
//		if (!this.isValidDate()) throw new Error("Invalid Date");
//}

//isOvernight() {
//	return this.date.getHours() >= this.OVERNIGHT_START || this.date.getHours() <= this.OVERNIGHT_END;
//}

//isSunday() {
//	return this.date.getDay() === 0;
//}

//isValidDistance() {
//	return this.distance != null && this.distance != undefined && typeof this.distance === "number" && this.distance > 0;
//}

//isValidDate() {
//	return this.date != null && this.date != undefined && this.date instanceof Date && this.date.toString() !== "Invalid Date";
//}
//}