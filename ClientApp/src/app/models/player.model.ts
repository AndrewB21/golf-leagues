import { League } from "./league.model";
import { PlayerPoints } from "./playerpoints.model";


export class Player {
    constructor(firstName: string, lastName: string, handicap: number, playerPoints?: PlayerPoints[], leagues?: League[], ) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.handicap = handicap;
        this.playerPoints = playerPoints;
        this.leagues = leagues;
    }

    public id?: number;
    public firstName: string;
    public lastName: string;
    public handicap: number;
    public playerPoints?: PlayerPoints[];
    public leagues?: League[];
}