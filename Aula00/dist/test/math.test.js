"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const math_1 = require("../src/math");
test("deve somar 2 + 2", function () {
    const result = (0, math_1.sum)(2, 2);
    expect(result).toBe(4);
});
