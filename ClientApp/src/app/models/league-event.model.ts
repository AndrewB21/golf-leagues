export class LeagueEvent {
    constructor(
        date: Date,
        courseId: number | null,
        leagueId: number | null,
    ) {
        this.date = date;
        this.courseId = courseId;
        this.leagueId = leagueId;
    }

    public id?: number;
    public date: Date;
    public courseId: number | null;
    public leagueId: number | null;
}