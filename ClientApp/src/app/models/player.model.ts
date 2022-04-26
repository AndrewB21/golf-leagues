import { League } from "./league.model";


export class Player {
    constructor(firstName: string, lastName: string, handicap: number, leagues: League[] = []) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.handicap = handicap;
        this.leagues = leagues;
    }

    public id?: number;
    public firstName: string;
    public lastName: string;
    public handicap: number;
    public leagues: League[];
}