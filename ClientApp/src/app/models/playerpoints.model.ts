import { League } from "./league.model";


export class PlayerPoints {
    constructor(leagueId: number, points: number, playerId?: number) {
        this.playerId = playerId;
        this.leagueId = leagueId;
        this.points = points;
    }

    public id?: number;
    public playerId?: number;
    public leagueId: number;
    public points: number;
}