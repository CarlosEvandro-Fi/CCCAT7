"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class User {
    constructor(email, password) {
        this.email = email;
        this.password = password;
    }
    getEmail() {
        return this.email;
    }
}
exports.default = User;
