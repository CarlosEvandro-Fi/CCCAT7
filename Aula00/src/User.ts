export default class User {
    constructor (readonly email: string, readonly password: string) {
    }
    
    getEmail () {
        return this.email;
    }
}