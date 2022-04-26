export class League {
    constructor(name: string, description: string) {
        this.name = name;
        this.description = description;
        //this.players = players;
    }

    public id?: number;
    public name: string;
    public description: string;
    // public List<Player> players;
}