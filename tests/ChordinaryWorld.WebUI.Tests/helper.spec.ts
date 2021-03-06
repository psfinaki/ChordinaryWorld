﻿/// <reference path="../../src/ChordinaryWorld.WebUI/helper.ts" />

describe('helper', () => {
    it("should make query", () => {
        const artist = "glass animals";
        const title = "pork soda";
        const expected = "artist=glass%20animals&title=pork%20soda";

        const result = makeQueryHarmonies(artist, title);

        expect(result).toBe(expected);
    });

    it("should make query when common punctuation", () => {
        const artist = "therapy?";
        const title = "diane";
        const expected = "artist=therapy%3F&title=diane";

        const result = makeQueryHarmonies(artist, title);

        expect(result).toBe(expected);
    });

    it("should make query when ampersand", () => {
        const artist = "london grammar";
        const title = "metal & dust";
        const expected = "artist=london%20grammar&title=metal%20%26%20dust";

        const result = makeQueryHarmonies(artist, title);

        expect(result).toBe(expected);
    });

    it("should make query when plus", () => {
        const artist = "brick + mortar";
        const title = "terrible things";
        const expected = "artist=brick%20%2B%20mortar&title=terrible%20things";

        const result = makeQueryHarmonies(artist, title);

        expect(result).toBe(expected);
    });

    it("should call correct server", () => {
        const expected: string = "chordinaryworld.azurewebsites.net";

        const result = chooseAuthority();

        expect(result).toBe(expected);
    });
});