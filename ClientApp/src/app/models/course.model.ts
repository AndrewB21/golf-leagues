export class Course {
    constructor(
        name: string,
        address: string
    ) {
        this.name = name;
        this.address = address;
    }

    public id?: number;
    public name: string;
    public address: string;
}