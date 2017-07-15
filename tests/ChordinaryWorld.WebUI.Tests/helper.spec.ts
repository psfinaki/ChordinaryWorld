/// <reference path="../../src/ChordinaryWorld.WebUI/helper.ts" />

describe('helper', () => {
    it("should make query", () => {
        const artist = "glass animals";
        const title = "pork soda";
        const expected = "artist=glass animals&title=pork soda";

        const result = makeQuery(artist, title);

        expect(result).toBe(expected);
    });
});