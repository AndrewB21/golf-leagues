import { Player } from "./player.model";

export class League {
    constructor(
        name: string,
        description: string,
        players: Player[] = [],
        startDate: Date,
        endDate: Date
    ) {
        this.name = name;
        this.description = description;
        this.players = players;
        this.startDate = startDate;
        this.endDate = endDate;
    }

    public id?: number;
    public name: string;
    public description: string;
    public startDate: Date;
    public endDate: Date;
    public players: Player[];
}