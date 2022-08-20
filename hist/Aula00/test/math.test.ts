import { sum } from "../src/math";

test("deve somar 2 + 2", function() {
    const result = sum(2, 2);
    expect(result).toBe(4);
})