function chooseAuthority() {
    //const authority = "localhost:48213";
    //const authority = "chordinaryworld-test.azurewebsites.net";
    const authority = "chordinaryworld.azurewebsites.net";

    return authority;
}

function makeQuery(artist: string, title: string) {
    const sanitizedArtist = encodeURIComponent(artist);
    const sanitizedTitle = encodeURIComponent(title);

    return `artist=${sanitizedArtist}&title=${sanitizedTitle}`;
}

function makeUrlHarmonies(artist: string, title: string) {
    const authority = chooseAuthority();
    const query = makeQuery(artist, title);

    return `http://${authority}/api/harmonies?${query}`;
}

function makeUrlTop() {
    const authority = chooseAuthority();

    return `http://${authority}/api/top?count=6`;
}

function formatSuccess(harmonies: number) {
    return `Number of harmonies here is ${harmonies}.`;
}

function formatFailure(status: number): string {
    switch (status) {
        case 404:
            return "Chords to this song were not found.";
        case 400:
            return "Empty input is not allowed.";
        case 500:
            return "There is a problem with the chords found. This will be fixed soon."
        default:
            return "Something went wrong. Sorry for bad diagnostics!";
    }
}

function formatTopLine(item: [string, string, number]) {
    return `${item[0]} - ${item[1]} (${item[2]})`;
}